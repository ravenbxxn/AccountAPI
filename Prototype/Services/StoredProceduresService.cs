/*using APIPrototype.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Dynamic;
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

        public async Task<dynamic> ExecuteStoredProcedureAsync(ProcedureRequest request)
        {
            var parameters = new List<SqlParameter>();

            foreach (var param in request.Parameters)
            {
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

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"EXEC {request.Name} {string.Join(", ", parameters.Select(p => p.ParameterName))}";
                command.CommandType = CommandType.Text;

                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }

                if (command.Connection.State != ConnectionState.Open)
                    await command.Connection.OpenAsync();

                // อ่านข้อมูลจาก SELECT (ExecuteReaderAsync)
                var resultList = new List<dynamic>();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new ExpandoObject() as IDictionary<string, Object>;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                        }

                        resultList.Add(row);
                    }
                }

                // ตอนนี้ปิด DataReader แล้ว เราสามารถใช้ ExecuteNonQueryAsync
                var rowsAffected = await command.ExecuteNonQueryAsync();

                // ส่งข้อมูลทั้งสอง (Data + RowsAffected)
                var resultWithDataAndCount = new
                {
                    RowsAffected = rowsAffected,  // จำนวนแถวที่ถูกเพิ่มหรืออัพเดต
                    Data = resultList,            // ข้อมูลจาก SELECT
                    Message = "Stored procedure executed successfully."
                };

                return resultWithDataAndCount;
            }
        }
    }
}
*/

using APIPrototype.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Dynamic;
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

        public async Task<dynamic> ExecuteStoredProcedureAsync(ProcedureRequest request)
        {
            var parameters = new List<SqlParameter>();

            foreach (var param in request.Parameters)
            {
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

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"EXEC {request.Name} {string.Join(", ", parameters.Select(p => p.ParameterName))}";
                command.CommandType = CommandType.Text;

                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }

                if (command.Connection.State != ConnectionState.Open)
                    await command.Connection.OpenAsync();

                var resultList = new List<dynamic>();

                // อ่านข้อมูลจาก SELECT (ExecuteReaderAsync)
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new ExpandoObject() as IDictionary<string, Object>;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                        }

                        resultList.Add(row);
                    }
                }

                // ส่งข้อมูลที่ได้จาก SELECT กลับไป
                var result = new
                {
                    Data = resultList,
                    Message = "Stored procedure executed successfully."
                };

                return result;
            }
        }
    }
}
