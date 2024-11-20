using APIPrototype.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static APIPrototype.Models.StoredProcedures_Model;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class StoredProceduresController : ControllerBase
    {
        private readonly StoredProceduresService _service;

        public StoredProceduresController(StoredProceduresService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetResult ([FromBody] ProcedureRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                var result = await _service.ExecuteStoredProcedureAsync(request);
                return Ok($"Stored procedure executed successfully. Rows affected: {result}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
