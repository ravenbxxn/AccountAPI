using APIPrototype.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using static APIPrototype.Models.View_Model;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ViewController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> GetViewResult([FromBody] ViewRequest request)
        {
            if (string.IsNullOrEmpty(request.ViewName))
            {
                return BadRequest("ViewName is required.");
            }

            try
            {
                // ✅ 1. ใช้ SELECT * หากไม่ได้ส่ง Results มา
                string selectClause = request.Results == null || !request.Results.Any()
                    ? "a.*"
                    : string.Join(", ", request.Results.Select(r => $"a.{r.SourceField} AS {r.Alias ?? r.SourceField}"));

                // ✅ 2. สร้าง WHERE Clause รองรับ Operator
                List<string> whereConditions = new();
                List<SqlParameter> sqlParameters = new();

                if (request.Parameters != null && request.Parameters.Any())
                {
                    foreach (var param in request.Parameters)
                    {
                        string paramName = $"@{param.Field.Replace(".", "_")}";

                        // ✅ ตรวจสอบว่า Operator ที่ส่งมาเป็นตัวที่รองรับหรือไม่
                        string validOperator = param.UseOperator switch
                        {
                            "!=" => "!=",
                            ">" => ">",
                            "<" => "<",
                            ">=" => ">=",
                            "<=" => "<=",
                            "LIKE" => "LIKE",
                            "NOT LIKE" => "NOT LIKE",
                            _ => "=" // ถ้าไม่ได้ระบุให้ใช้ '=' เป็นค่าเริ่มต้น
                        };

                        whereConditions.Add($"a.{param.Field} {validOperator} {paramName}");

                        // ถ้าใช้ LIKE ให้เพิ่ม Wildcard (%)
                        object paramValue = param.Value;
                        if (param.UseOperator == "LIKE" || param.UseOperator == "NOT LIKE")
                        {
                            paramValue = $"%{param.Value}%";
                        }

                        sqlParameters.Add(new SqlParameter(paramName, paramValue ?? (object)DBNull.Value));
                    }
                }

                // ✅ 3. สร้าง JOIN Clauses
                string joinClause = "";
                List<string> nullConditions = new();

                if (request.Joins != null && request.Joins.Any())
                {
                    foreach (var join in request.Joins)
                    {
                        var joinConditions = string.Join(" AND ", join.Conditions.Select(c => $"a.{c.LeftField} = {join.Alias}.{c.RightField}"));
                        joinClause += $" {join.JoinType} {join.Table} AS {join.Alias} ON {joinConditions}";

                        // ✅ ดึงเงื่อนไข `IS NULL` ออกไปใส่ใน WHERE
                        if (join.NullConditions != null && join.NullConditions.Any())
                        {
                            nullConditions.AddRange(join.NullConditions.Select(field => $"{join.Alias}.{field} IS NULL"));
                        }
                    }
                }

                // ✅ 4. รวม NullConditions เข้าไปใน WHERE
                whereConditions.AddRange(nullConditions);
                string whereClause = whereConditions.Any() ? "WHERE " + string.Join(" AND ", whereConditions) : "";

                // ✅ 5. ประกอบ SQL Statement
                string sql = $"SELECT {selectClause} FROM {request.ViewName} AS a {joinClause} {whereClause}";

                // ✅ 6. Execute SQL
                var result = await ExecuteDynamicQueryAsync(sql, sqlParameters, request.Results);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


        private async Task<IEnumerable<Dictionary<string, object>>> ExecuteDynamicQueryAsync(
    string sql, List<SqlParameter> parameters, List<ResultField>? resultFields)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(sql, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            var result = new List<Dictionary<string, object>>();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    object value = reader.GetValue(i);

                    // ✅ ตรวจสอบค่าที่เป็น `DBNull`
                    if (value is DBNull)
                    {
                        value = "";
                    }

                    // ✅ ตรวจสอบว่ามีการกำหนด `Type` หรือไม่ แล้วแปลงค่าตามต้องการ
                    var fieldType = resultFields?.FirstOrDefault(f => f.Alias == columnName || f.SourceField == columnName)?.Type;
                    if (!string.IsNullOrEmpty(fieldType))
                    {
                        value = fieldType.ToLower() switch
                        {
                            "int" => Convert.ToInt32(value),
                            "double" => Convert.ToDouble(value),
                            "decimal" => Convert.ToDecimal(value),
                            _ => value
                        };
                    }

                    row[columnName] = value;
                }

                result.Add(row);
            }

            return result;
        }

    }
}
