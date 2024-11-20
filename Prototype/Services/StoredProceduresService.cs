using APIPrototype.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static APIPrototype.Models.StoredProcedures_Model;

namespace APIPrototype.Services
{
    public class StoredProceduresService
    {
        private readonly AppDbContext _db;

        public StoredProceduresService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<int> ExecuteStoredProcedureAsync(ProcedureRequest request)
        {
            var parameters = new List<SqlParameter>();

            foreach (var param in request.Parameters)
            {
                // ตรวจสอบและแปลงค่าจาก JsonElement เป็นชนิดข้อมูลที่รองรับ
                object value = param.Value is JsonElement jsonElement ? jsonElement.ValueKind switch
                {
                    JsonValueKind.String => jsonElement.GetString(),
                    JsonValueKind.Number => jsonElement.TryGetInt32(out int intValue) ? intValue : (object)jsonElement.GetDouble(),
                    JsonValueKind.True => true,
                    JsonValueKind.False => false,
                    JsonValueKind.Null => DBNull.Value,
                    _ => throw new InvalidOperationException("Unsupported JSON value type.")
                } : param.Value;

                parameters.Add(new SqlParameter($"@{param.Param}", value ?? DBNull.Value));
            }

            var result = await _db.Database.ExecuteSqlRawAsync(
                $"EXEC {request.Name} {string.Join(", ", parameters.Select(p => p.ParameterName))}",
                parameters.ToArray()
            );

            return result;
        }
    }
}
