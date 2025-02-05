using APIPrototype.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

                // ✅ 2. สร้าง WHERE Clause
                List<string> whereConditions = new();
                List<SqlParameter> sqlParameters = new();

                if (request.Parameters != null && request.Parameters.Any())
                {
                    foreach (var param in request.Parameters)
                    {
                        string paramName = $"@{param.Field.Replace(".", "_")}";
                        whereConditions.Add($"a.{param.Field} = {paramName}");
                        sqlParameters.Add(new SqlParameter(paramName, param.Value ?? (object)DBNull.Value));
                    }
                }

                // ✅ 3. สร้าง JOIN Clauses
                string joinClause = "";
                List<string> nullConditions = new(); // เก็บ `IS NULL` ไปใช้ใน `WHERE`

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
                var result = await ExecuteDynamicQueryAsync(sql, request.Parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        private async Task<IEnumerable<Dictionary<string, object>>> ExecuteDynamicQueryAsync(
            string sql, IEnumerable<Parameter> parameters)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(sql, connection);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue($"@{param.Field}", param.Value);
                }
            }

            var result = new List<Dictionary<string, object>>();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = Enumerable.Range(0, reader.FieldCount)
                    .ToDictionary(reader.GetName, reader.GetValue);
                result.Add(row);
            }

            return result;
        }
    }
}
