using APIPrototype.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        public async Task<IActionResult> GetResult([FromBody] ProcedureRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                // เรียกใช้ service และรับผลลัพธ์
                var result = await _service.ExecuteStoredProcedureAsync(request);

                // ส่งผลลัพธ์กลับเป็น OK
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
