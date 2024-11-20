using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class HRLevelController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HRLevelController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetHRLevel(int? levelID = null)
        {
            try
            {

                var queryable = _db.Mas_HRLevel.AsQueryable();
                bool hasCriteria = false;

                if (levelID.HasValue)
                {
                    queryable = queryable.Where(item => item.LevelId == levelID.Value);
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
        public IActionResult SetHRLevel([FromBody] List<Mas_HRLevel> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No HRLevels were provided.");
                }

                foreach (var obj in objs)
                {
                    _db.Mas_HRLevel.Add(obj);
                }

                _db.SaveChanges();
                return Ok("HRLevels Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditHRLevel(Mas_HRLevel obj)
        {
            try
            {
                if (obj == null || obj.LevelId == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.LevelId == 0)
                    {
                        return BadRequest($"HRLevelID: {obj.LevelId} is invalid.");
                    }
                }

                var HRlevel = _db.Mas_HRLevel.Find(obj.LevelId);
                if (HRlevel == null)
                {
                    return NotFound($"HRLevel not found with PositionID: {obj.LevelId}.");
                }

                foreach (PropertyInfo property in typeof(Mas_HRLevel).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(HRlevel, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("HRLevel details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{levelID}")]
        public IActionResult DeleteHRLevel(int? levelID)
        {
            try
            {
                if (levelID == null || levelID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var HRlevel = _db.Mas_HRLevel.Find(levelID);
                if (HRlevel == null)
                {
                    return NotFound($"HRLevel not found with LevelID: {levelID}.");
                }
                _db.Mas_HRLevel.Remove(HRlevel);
                _db.SaveChanges();
                return Ok("HRLevel Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
