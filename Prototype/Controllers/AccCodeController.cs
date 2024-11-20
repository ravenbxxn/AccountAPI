using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class AccCodeController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AccCodeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAccCode(string accCode = null, int? accTypeId = null, string accMainCode = null)
        {
            try
            {
                var queryable = _db.Mas_AccCode.AsQueryable();
                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(accCode))
                {
                    queryable = queryable.Where(item => item.AccCode == accCode);
                    hasCriteria = true;
                }

                if (accTypeId.HasValue)
                {
                    queryable = queryable.Where(item => item.AccTypeID == accTypeId.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(accMainCode))
                {
                    queryable = queryable.Where(item => item.AccMainCode == accMainCode);
                    hasCriteria = true;
                        
                }

                var accCodeItems = queryable.ToList();

                if (hasCriteria && !accCodeItems.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !accCodeItems.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(accCodeItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

        [HttpPost]
        public IActionResult SetAccCode([FromBody] List<Mas_AccCode> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No AccCodes were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_AccCode.Where(item => item.AccCode == obj.AccCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_AccCode.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"AccCode : [{obj.AccCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("AccCodes Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAccCode(Mas_AccCode obj)
        {
            try
            {
                if(obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                var existingAccCode = _db.Mas_AccCode.Find(obj.AccCode);
                if (existingAccCode == null)
                {
                    return BadRequest($"AccCode not found with AccCode: {obj.AccCode}.");
                }

                foreach (PropertyInfo property in typeof(Mas_AccCode).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingAccCode, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("AccCode datail updated.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accCoode}")]
        public IActionResult DeleteAccCode(string accCoode)
        {
            try
            {
                if(accCoode == null)
                {
                    return BadRequest("AccCode is null or empty.");
                }
                var acccode = _db.Mas_AccCode.Find(accCoode);
                if (acccode == null)
                {
                    return BadRequest($"AccCode not found with AccCode: {accCoode}.");
                }
                _db.Mas_AccCode.Remove(acccode);
                _db.SaveChanges();
                return Ok("AccCode deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
