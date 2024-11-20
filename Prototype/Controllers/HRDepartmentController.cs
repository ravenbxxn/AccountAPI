using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class HRDepartmentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HRDepartmentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetHRDepartment(int? departmentID = null, int? divisionID = null)
        {
            try
            {

                var queryable = _db.Mas_HRDepartment.AsQueryable();
                bool hasCriteria = false;

                if (departmentID.HasValue)
                {
                    queryable = queryable.Where(item => item.DepartmentId == departmentID.Value);
                    hasCriteria = true;
                }

                if (divisionID.HasValue)
                {
                    queryable = queryable.Where(item => item.DivisionId == divisionID.Value);
                    hasCriteria = true;
                }

                var hrDepartments = queryable.ToList();

                if (hasCriteria && !hrDepartments.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !hrDepartments.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(hrDepartments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetHRDepartment([FromBody] List<Mas_HRDepartment> objs)
        {
            try
            {

                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No HRDepartments were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_HRDepartment.Where(item => item.DepartmentId == obj.DepartmentId);
                    if (!checkobj.Any())
                    {
                        _db.Mas_HRDepartment.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"DepartmentID : [{obj.DepartmentId}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("HRDepartments Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditHRDepartment(Mas_HRDepartment obj)
        {
            try
            {
                if (obj == null || obj.DepartmentId <= 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.DepartmentId <= 0)
                    {
                        return BadRequest($"HRDepartment ID: {obj.DepartmentId} is invalid.");
                    }
                }
                var hrDepartment = _db.Mas_HRDepartment.Find(obj.DepartmentId);
                if (hrDepartment == null)
                {
                    return NotFound($"HRDepartment not found with ID: {obj.DepartmentId}.");
                }
                foreach (PropertyInfo property in typeof(Mas_HRDepartment).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(hrDepartment, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("HRDepartment details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{departmentID}")]
        public IActionResult DeleteHRDepartment(int departmentID)
        {
            try
            {
                var hrDepartment = _db.Mas_HRDepartment.Find(departmentID);
                if (hrDepartment == null)
                {
                    return NotFound($"HRDepartment not found with ID: {departmentID}.");
                }
                _db.Mas_HRDepartment.Remove(hrDepartment);
                _db.SaveChanges();
                return Ok("HRDepartment Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
