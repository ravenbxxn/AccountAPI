using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class HRPositionController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HRPositionController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult GetHRPosition(int? positionID = null, int? levelID = null, int? departmentID = null)
        {
            try
            {

                var queryable = _db.Mas_HRPosition.AsQueryable();
                bool hasCriteria = false;

                if (positionID.HasValue)
                {
                    queryable = queryable.Where(item => item.PositionId == positionID.Value);
                    hasCriteria = true;
                }

                if (levelID.HasValue)
                {
                    queryable = queryable.Where(item => item.LevelId == levelID.Value);
                    hasCriteria = true;
                }

                if (departmentID.HasValue)
                {
                    queryable = queryable.Where(item => item.DepartmentId == departmentID.Value);
                    hasCriteria = true;
                }

                var hrLevels = queryable.ToList();

                if (hasCriteria && !hrLevels.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !hrLevels.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(hrLevels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult SetHRPosition([FromBody] List<Mas_HRPosition> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Positions were provided.");
                }

                foreach (var obj in objs)
                {
                    _db.Mas_HRPosition.Add(obj);
                }

                _db.SaveChanges();
                return Ok("Positions Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditHRPosition(Mas_HRPosition obj)
        {
            try
            {
                if (obj == null || obj.PositionId == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.PositionId == 0)
                    {
                        return BadRequest($"PositionID: {obj.PositionId} is invalid.");
                    }
                }

                var HRposition = _db.Mas_HRPosition.Find(obj.PositionId);
                if (HRposition == null)
                {
                    return NotFound($"Position not found with PositionID: {obj.PositionId}.");
                }

                foreach (PropertyInfo property in typeof(Mas_HRPosition).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(HRposition, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Position details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{positionID}")]
        public IActionResult DeleteHRPosition(int? positionID)
        {
            try
            {
                if (positionID == null || positionID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var staff = _db.Mas_HRPosition.Find(positionID);
                if (staff == null)
                {
                    return NotFound($"Position not found with PositionID: {positionID}.");
                }
                _db.Mas_HRPosition.Remove(staff);
                _db.SaveChanges();
                return Ok("Position Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
