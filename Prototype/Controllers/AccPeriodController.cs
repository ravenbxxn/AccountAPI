/*using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class AccPeriodController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AccPeriodController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAccPeriods()
        {
            try
            {
                var APs = _db.Mas_AccPeriod.ToList();
                if (APs.Count== 0)
                {
                    return NotFound("AccPeriod not available.");
                }
                return Ok(APs);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccPeriod(int id)
        {
            try
            {
                var AP = _db.Mas_AccPeriod.Find(id);
                if (AP == null)
                {
                    return NotFound($"AccPeriod not found with ID: {id}.");
                }
                return Ok(AP);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetAccPeriod(Mas_AccPeriod obj)
        {
            try
            {
                _db.Mas_AccPeriod.Add(obj);
                _db.SaveChanges();
                return Ok("AccPeriod Created.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAccPeriod(Mas_AccPeriod obj)
        {
            if (obj == null || obj.PeriodID == 0)
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                else if (obj.PeriodID == 0)
                {
                    return BadRequest($"AccPeriod ID: {obj.PeriodID} is invalid.");
                }
            }
            try
            {
                var AP = _db.Mas_AccPeriod.Find(obj.PeriodID);
                if (AP == null)
                {
                    return NotFound($"AccPeriod not found with ID: {obj.PeriodID}.");
                }
                AP.PeriodID = obj.PeriodID;
                AP.PeriodEndDate = obj.PeriodEndDate;
                _db.SaveChanges();
                return Ok("AccPeriod details updated.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        
    }
}
*/