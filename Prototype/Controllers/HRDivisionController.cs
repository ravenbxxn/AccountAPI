using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class HRDivisionController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HRDivisionController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetHRDivision(int? divisionID = null, int? companyID = null)
        {
            try
            {

                var queryable = _db.Mas_HRDivision.AsQueryable();
                bool hasCriteria = false;

                if (divisionID.HasValue)
                {
                    queryable = queryable.Where(item => item.DivisionId == divisionID.Value);
                    hasCriteria = true;
                }

                if (companyID.HasValue)
                {
                    queryable = queryable.Where(item => item.CompanyId == companyID.Value);
                    hasCriteria = true;
                }

                var hrDivisions = queryable.ToList();

                if (hasCriteria && !hrDivisions.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !hrDivisions.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(hrDivisions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult SetHRDivision([FromBody] List<Mas_HRDivision> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No HRDivisions were provided.");
                }

                foreach (var obj in objs)
                {
                    _db.Mas_HRDivision.Add(obj);
                }

                _db.SaveChanges();
                return Ok("HRDivisions Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditHRDivision(Mas_HRDivision obj)
        {
            try
            {
                if (obj == null || obj.DivisionId == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.DivisionId == 0)
                    {
                        return BadRequest($"HRDivision: {obj.DivisionId} is invalid.");
                    }
                }

                var HRdivision= _db.Mas_HRDivision.Find(obj.DivisionId);
                if (HRdivision == null)
                {
                    return NotFound($"HRDivision not found with DivisionId: {obj.DivisionId}.");
                }

                foreach (PropertyInfo property in typeof(Mas_HRDivision).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(HRdivision, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("HRDivision details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{divisionID}")]
        public IActionResult DeleteHRDivision(int? divisionID)
        {
            try
            {
                if (divisionID == null || divisionID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var HRdivision = _db.Mas_HRDivision.Find(divisionID);
                if (HRdivision == null)
                {
                    return NotFound($"HRDivision not found with DivisionID: {divisionID}.");
                }
                _db.Mas_HRDivision.Remove(HRdivision);
                _db.SaveChanges();
                return Ok("HRDivision Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
