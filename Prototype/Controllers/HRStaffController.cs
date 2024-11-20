using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class HRStaffController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HRStaffController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetHRStaff(
            int? staffID = null,
            string staffCode = null,
            int? staffType = null,
            int? citizenType = null,
            string title = null,
            string nationality = null,
            string staffCitizenID = null,
            string staffAddrZipCode = null)
        {
            try
            {
                var queryable = _db.Mas_HRStaff.AsQueryable();

                bool hasCriteria = false;

                if (staffID.HasValue)
                {
                    queryable = queryable.Where(item => item.StaffId == staffID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(staffCode))
                {
                    queryable = queryable.Where(item => item.StaffCode == staffCode);
                    hasCriteria = true;
                }

                if (staffType.HasValue)
                {
                    queryable = queryable.Where(item => item.StaffType == staffType.Value);
                    hasCriteria = true;
                }

                if (citizenType.HasValue)
                {
                    queryable = queryable.Where(item => item.CitizenType == citizenType.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(title))
                {
                    queryable = queryable.Where(item => item.Title == title);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(nationality))
                {
                    queryable = queryable.Where(item => item.Nationality == nationality);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(staffCitizenID))
                {
                    queryable = queryable.Where(item => item.StaffCitizenID == staffCitizenID);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(staffAddrZipCode))
                {
                    queryable = queryable.Where(item => item.StaffAddrZipcode == staffAddrZipCode);
                    hasCriteria = true;
                }

                var hrStaffs = queryable.ToList();

                if (hasCriteria && !hrStaffs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !hrStaffs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(hrStaffs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetHRStaff([FromBody] List<Mas_HRStaff> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Staffs were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_HRStaff.Where(item => item.StaffCode == obj.StaffCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_HRStaff.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"StaffCode {obj.StaffCode} is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Staffs Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditHRStaff(Mas_HRStaff obj)
        {

            try
            {
                if (obj == null || obj.StaffId == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.StaffId == 0)
                    {
                        return BadRequest($"StaffID: {obj.StaffId} is invalid.");
                    }
                }

                var existingStaff = _db.Mas_HRStaff.Find(obj.StaffId);
                if (existingStaff == null)
                {
                    return NotFound($"Staff not found with StaffID: {obj.StaffId}.");
                }

                if (existingStaff.StaffCode != obj.StaffCode)
                {
                    var duplicateStaff = _db.Mas_HRStaff.Any(item => item.StaffCode == obj.StaffCode && item.StaffId != obj.StaffId);
                    if (duplicateStaff)
                    {
                        return BadRequest("StaffCode is already exist.");
                    }
                }
                foreach (PropertyInfo property in typeof(Mas_HRStaff).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingStaff, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Staff details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{staffID}")]
        public IActionResult DeleteHRStaff(int? staffID)
        {
            try
            {
                if (staffID == null || staffID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var staff = _db.Mas_HRStaff.Find(staffID);
                if (staff == null)
                {
                    return NotFound($"Staff not found with StaffID: {staffID}.");
                }
                _db.Mas_HRStaff.Remove(staff);
                _db.SaveChanges();
                return Ok("Staff Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
