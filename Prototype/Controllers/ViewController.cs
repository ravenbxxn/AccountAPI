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
                // ใช้ SELECT * หากไม่ได้ส่ง Results มา
                string selectClause = request.Results == null || !request.Results.Any()
                    ? "*"
                    : string.Join(", ", request.Results.Select(r => $"{r.SourceField} AS {r.Alias ?? r.SourceField}"));

                // ไม่มี WHERE Clause หาก Parameters เป็น null หรือว่าง
                string whereClause = request.Parameters != null && request.Parameters.Any()
                    ? "WHERE " + string.Join(" AND ",
                        request.Parameters.Select(p => $"{p.Field} = @{p.Field}"))
                    : string.Empty;

                // สร้าง SQL
                string sql = $"SELECT {selectClause} FROM {request.ViewName} {whereClause}";

                // ดึงข้อมูลจากฐานข้อมูล
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
