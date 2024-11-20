/*using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProfileController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            try
            {
                var profile = _db.Acc_Profile.ToList();
                if (profile.Count == 0)
                {
                    return NotFound("Profile not available.");
                }
                return Ok(profile);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {
            try
            {
                var profile = _db.Acc_Profile.Find(id);
                if (profile == null)
                {
                    return NotFound($"Profile detail not found with ID: {id}.");
                }
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetProfile(Acc_Profile obj)
        {
            try
            {
                var profile = _db.Acc_Profile;
                if (profile.Count() > 0)
                {
                    return BadRequest("Already have Profile.");
                }
                else
                {
                    obj.ID = 1;
                    _db.Acc_Profile.Add(obj);
                    _db.SaveChanges();
                    return Ok("Profile Created.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditProfile(Acc_Profile obj)
        {
            try
            {
                var profile = _db.Acc_Profile.Find(obj.ID);
                if (profile == null)
                {
                    return NotFound($"Profile not found with {obj.ID}.");
                }
                profile.ID = obj.ID;
                profile.THName = obj.THName;
                profile.THAddress1 = obj.THAddress1;
                profile.THAddress2 = obj.THAddress2;
                profile.ENName = obj.ENName;
                profile.EAddress1 = obj.EAddress1;
                profile.EAddress2 = obj.EAddress2;
                profile.TelPhoneFax = obj.TelPhoneFax;
                profile.ProfileType = obj.ProfileType;
                profile.TaxNumber = obj.TaxNumber;
                profile.Branch = obj.Branch;
                profile.BusRegisNum = obj.BusRegisNum;

                _db.SaveChanges();
                return Ok("Profile details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("ID is null or empty.");
                }
                var profile = _db.Acc_Profile.Find(id);
                if (profile == null)
                {
                    return NotFound($"Profile not found with ID: {id}.");
                }
                _db.Acc_Profile.Remove(profile);
                _db.SaveChanges();
                return Ok("Profile Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
*/