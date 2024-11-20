using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class HREmploymentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HREmploymentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetHREmployment(
            int? companyID = null,
            int? positionID = null,
            int? staffID = null)
        {
            try
            {
                var queryable = _db.Mas_HREmployment.AsQueryable();

                bool hasCriteria = false;

                if (companyID.HasValue)
                {
                    queryable = queryable.Where(item => item.CompanyId == companyID.Value);
                    hasCriteria = true;
                }

                if (positionID.HasValue)
                {
                    queryable = queryable.Where(item => item.PositionId == positionID.Value);
                    hasCriteria = true;
                }

                if (staffID.HasValue)
                {
                    queryable = queryable.Where(item => item.StaffId == staffID.Value);
                    hasCriteria = true;
                }

                var hrEmployments = queryable.ToList();

                if (hasCriteria && !hrEmployments.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !hrEmployments.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(hrEmployments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetHREmployment([FromBody] List<Mas_HREmployment> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No HREmployment were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_HREmployment.Where(item => item.CompanyId == obj.CompanyId && item.PositionId == obj.PositionId && item.StaffId == obj.StaffId);
                    if (!checkobj.Any())
                    {
                        _db.Mas_HREmployment.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"HREmployment -> CompanyID : [{obj.CompanyId}],PositionID : [{obj.PositionId}],StaffID : [{obj.StaffId}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("HREmployment Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditHREmployment(Mas_HREmployment obj)
        {
            try
            {
                if (obj == null || obj.CompanyId <= 0 || obj.PositionId <= 0 || obj.StaffId <= 0 )
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.CompanyId <= 0 || obj.PositionId < 0 || obj.StaffId <= 0)
                    {
                        return BadRequest($"HREmployment -> CompanyId: {obj.CompanyId}, PositionId: {obj.PositionId} or StaffId: {obj.StaffId} is invalid.");
                    }
                }
                var hrEmployment = _db.Mas_HREmployment.Find(obj.CompanyId, obj.PositionId, obj.StaffId);
                if (hrEmployment == null)
                {
                    return NotFound($"HREmployment not found with CompanyId: {obj.CompanyId}, PositionId: {obj.PositionId}, StaffId: {obj.StaffId}.");
                }
                foreach (PropertyInfo property in typeof(Mas_HREmployment).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(hrEmployment, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("HREmployment details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{companyID}")]
        public IActionResult DeleteHREmployment(int companyID, int positionID, int staffID)
        {
            try
            {
                var hrEmployment = _db.Mas_HREmployment.Find(companyID, positionID, staffID);
                if (hrEmployment == null)
                {
                    return NotFound($"HREmployment not found with CompanyId: {companyID}, PositionId: {positionID}, StaffId: {staffID}.");
                }
                _db.Mas_HREmployment.Remove(hrEmployment);
                _db.SaveChanges();
                return Ok("HREmployment Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
