using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class AccTypeController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AccTypeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAccType(int? accTypeID = null, string accType = null, string accSide = null)
        {
            try
            {
                var queryable = _db.Mas_AccType.AsQueryable();
                bool hasCriteria = false;

                if (accTypeID.HasValue)
                {
                    queryable = queryable.Where(item => item.AccTypeID == accTypeID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(accType))
                {
                    queryable = queryable.Where(item => item.AccType == accType);
                    hasCriteria = true;

                }

                if (!string.IsNullOrEmpty(accSide))
                {
                    queryable = queryable.Where(item => item.AccSide == accSide);
                    hasCriteria = true;
                }

                var accTypes = queryable.ToList();

                if (hasCriteria && !accTypes.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !accTypes.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(accTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetAccType(Mas_AccType obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                var checkobj = _db.Mas_AccType.Where(item => item.AccType == obj.AccType);
                if (!checkobj.Any())
                {
                    _db.Mas_AccType.Add(obj);
                    _db.SaveChanges();
                    return Ok("AccType Create.");
                }
                else
                {
                    return BadRequest("AccType is already exsist.");
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAccType(Mas_AccType obj)
        {
            try
            {
                if (obj == null || obj.AccTypeID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.AccTypeID == 0)
                    {
                        return BadRequest($"AccType ID: {obj.AccTypeID} is invalid.");
                    }
                }
                var existingAcctype = _db.Mas_AccType.Find(obj.AccTypeID);
                if (existingAcctype == null)
                {
                    return BadRequest($"AccType not found with ID: {obj.AccTypeID}.");
                }

                if (existingAcctype.AccType != obj.AccType)
                {
                    var duplicateAcctype = _db.Mas_AccType.Any(item => item.AccType == obj.AccType && item.AccTypeID != obj.AccTypeID);
                    if (duplicateAcctype)
                    {
                        return BadRequest("AccType is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_AccType).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingAcctype, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("AccType detail updated.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accTypeID}")]
        public IActionResult DeleteAccType(int? accTypeID)
        {
            try
            {
                if (accTypeID == null || accTypeID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var acctype = _db.Mas_AccType.Find(accTypeID);
                if (acctype == null)
                {
                    return BadRequest($"AccType not found with ID: {accTypeID}.");
                }
                _db.Mas_AccType.Remove(acctype);
                _db.SaveChanges();
                return Ok("AccType deleted successfully.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
