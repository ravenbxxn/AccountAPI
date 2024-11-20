/*using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            try
            {
                var departments = _db.Mas_Department.ToList();
                if (departments.Count == 0)
                {
                    return NotFound("Departments not available.");
                }
                return Ok(departments);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id) 
        { 
            try
            {
                var department = _db.Mas_Department.Find(id);
                if (department == null)
                {
                    return NotFound($"Department detail not found with ID: {id}.");
                }
                return Ok(department);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult SearchDepartment([FromQuery] string searchTerm)
        {
            try
            {
                var Department = _db.Mas_Department.ToList()
                    .Where(dp => (dp.DPCODE?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)
                    || (dp.TShortName?.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ?? false)
                    || (dp.EShortName?.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ?? false)
                    || (dp.TFullName?.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ?? false)
                    || (dp.EFullName?.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ?? false)
                    || (dp.Department?.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ?? false))
                    .ToList();

                return Ok(Department);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetDepartment(Mas_Department obj)
        {
            try
            {
                var checkobj = _db.Mas_Department.Where(item => item.DPCODE == obj.DPCODE);
                if (!checkobj.Any())
                {
                    _db.Mas_Department.Add(obj);
                    _db.SaveChanges();
                    return Ok("Department Created.");
                }
                else
                {
                    return BadRequest("DepartmentCode is already exsist.");
                }

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditDepartment(Mas_Department obj)
        {
            try
            {
                if (obj == null || obj.DPID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.DPID == 0)
                    {
                        return BadRequest($"Department ID: {obj.DPID} is invalid.");
                    }
                }
                var existingDepartment = _db.Mas_Department.Find(obj.DPID);
                if (existingDepartment == null)
                {
                    return NotFound($"Department not found with ID: {obj.DPID}.");
                }

                if (existingDepartment.DPCODE != obj.DPCODE)
                {
                    var duplicateDepartment = _db.Mas_Department.Any(item => item.DPCODE == obj.DPCODE && item.DPID != obj.DPID);
                    if (duplicateDepartment)
                    {
                        return BadRequest("DepartmentCode is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_Department).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingDepartment, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("Department details updated.");

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int? id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var department = _db.Mas_Department.Find(id);
                if (department == null)
                {
                    return NotFound($"Department not found with ID: {id}.");
                }
                _db.Mas_Department.Remove(department);
                _db.SaveChanges();
                return Ok("Department Deleted successfully.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
*/