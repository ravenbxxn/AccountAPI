using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetUser(string userName = null,int? id = null)
        {
            try
            {

                var queryable = _db.Mas_User.AsQueryable();

                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(userName))
                {
                    queryable = queryable.Where(e => e.Username == userName);
                    hasCriteria = true;
                }

                if (id.HasValue)
                {
                    queryable = queryable.Where(item => item.Id == id.Value);
                    hasCriteria = true;
                }

                var users = queryable.ToList();

                if (hasCriteria && !users.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !users.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetUser([FromBody] RegisterModel obj)
        {
            var existingUser = _db.Mas_User.SingleOrDefault(u => u.Username == obj.Username);
            if (existingUser != null)
            {
                return Conflict("Username already exists.");
            }

            var passwordHash = HashPassword(obj.Password);


            var newUser = new Mas_User
            {
                Username = obj.Username,
                PasswordHash = passwordHash
            };

            _db.Mas_User.Add(newUser);
            _db.SaveChanges();

            return Ok("User Created.");
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hash);
            }
        }


        [HttpPut]
        public IActionResult EditUser(Mas_User obj)
        {
            try
            {
                if (obj == null || obj.Id == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.Id <= 0)
                    {
                        return BadRequest($"ID: {obj.Id} is invalid.");
                    }
                }

                var exisitingUser = _db.Mas_User.Find(obj.Id);
                if (exisitingUser == null)
                {
                    return NotFound($"User not found with ID: {obj.Id}.");
                }

                if (exisitingUser.Username != obj.Username)
                {
                    var duplicateUse = _db.Mas_User.Any(item => item.Username == obj.Username && item.Id != obj.Id);
                    if (duplicateUse)
                    {
                        return BadRequest("UserName is already exist.");
                    }
                }

                // ตรวจสอบว่ามีการเปลี่ยนแปลง password และทำการ hash ถ้าจำเป็น
                if (!string.IsNullOrEmpty(obj.PasswordHash) && exisitingUser.PasswordHash != obj.PasswordHash)
                {
                    obj.PasswordHash = HashPassword(obj.PasswordHash); // ฟังก์ชันสำหรับ hash password
                }

                // ทำการอัปเดต property ทั้งหมดใน exisitingUser ด้วยค่าใหม่
                foreach (PropertyInfo property in typeof(Mas_User).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(exisitingUser, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("User details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _db.Mas_User.Find(id);
                if (user == null)
                {
                    return NotFound($"User not found with ID: {id}.");
                }
                _db.Mas_User.Remove(user);
                _db.SaveChanges();
                return Ok("User Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserRole(string roleID = null)
        {
            try
            {

                var queryable = _db.Mas_UserRole.AsQueryable();
                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(roleID))
                {
                    queryable = queryable.Where(e => e.RoleID == roleID);
                    hasCriteria = true;
                }


                var userRoles = queryable.ToList();

                if (hasCriteria && !userRoles.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !userRoles.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetUserRole([FromBody] List<Mas_UserRole> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No UserRoles were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_UserRole.Where(item => item.RoleID == obj.RoleID);
                    if (!checkobj.Any())
                    {
                        _db.Mas_UserRole.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"RoleID : [{obj.RoleID}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("UserRoles Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditUserRole(Mas_UserRole obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                var existingUserRole = _db.Mas_UserRole.Find(obj.RoleID);
                if (existingUserRole == null)
                {
                    return BadRequest($"UserRole not found with ID: {obj.RoleID}.");
                }

                foreach (PropertyInfo property in typeof(Mas_UserRole).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingUserRole, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("UserRole datail updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{roleID}")]
        public IActionResult DeleteUserRole(string roleID)
        {
            try
            {
                var userRole = _db.Mas_UserRole.Find(roleID);
                if (userRole == null)
                {
                    return NotFound($"UserRole not found with ID: {roleID}.");
                }
                _db.Mas_UserRole.Remove(userRole);
                _db.SaveChanges();
                return Ok("UserRole Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserRoleAssign(string roleID = null,string userID = null, int? active = null)
        {
            try
            {

                var queryable = _db.Mas_UserRoleAssign.AsQueryable();

                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(roleID))
                {
                    queryable = queryable.Where(item => item.RoleID == roleID);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(userID))
                {
                    queryable = queryable.Where(item => item.UserID == userID);
                    hasCriteria = true;
                }

                if (active.HasValue)
                {
                    queryable = queryable.Where(item => item.Active == active.Value);
                    hasCriteria = true;
                }

                var userRoleAssigns = queryable.ToList();

                if (hasCriteria && !userRoleAssigns.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !userRoleAssigns.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(userRoleAssigns);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetUserRoleAssgin([FromBody] List<Mas_UserRoleAssign> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No UserRoleAssigns were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_UserRoleAssign.Where(item => item.RoleID == obj.RoleID && item.UserID == obj.UserID);
                    if (!checkobj.Any())
                    {
                        _db.Mas_UserRoleAssign.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"RoleID : [{obj.RoleID}],UserID : [{obj.UserID}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("UserRoleAssigns Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditUserRoleAssign(Mas_UserRoleAssign obj)
        {
            try
            {
                if (obj == null || obj.RoleID == "" || obj.UserID == "")
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.RoleID == "")
                    {
                        return BadRequest("RoleID is invalid.");
                    }
                    else if (obj.UserID == "")
                    {
                        return BadRequest("UserID is invalid.");
                    }
                }
                var userRoleAssign = _db.Mas_UserRoleAssign.Find(obj.RoleID, obj.UserID);
                if (userRoleAssign == null)
                {
                    return NotFound($"UserRoleAssign not found with RoleID: {obj.RoleID}, UserID: {obj.UserID}.");
                }
                foreach (PropertyInfo property in typeof(Mas_UserRoleAssign).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(userRoleAssign, property.GetValue(obj, null));
                }


                _db.SaveChanges();
                return Ok("UserRoleAssign details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{roleID}")]
        public IActionResult DeleteUserRoleAssign(string roleID, string userID)
        {
            try
            {
                var userRoleAssign = _db.Mas_UserRoleAssign.Find(roleID,userID);
                if (userRoleAssign == null)
                {
                    return NotFound($"UserRoleAssign not found with RoleID: {roleID}, UserID: {userID}.");
                }
                _db.Mas_UserRoleAssign.Remove(userRoleAssign);
                _db.SaveChanges();
                return Ok("UserRoleAssign Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserRoleAuthor(string roleID = null, string moduleID = null, string menuID = null)
        {
            try
            {

                var queryable = _db.Mas_UserRoleAuthor.AsQueryable();

                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(roleID))
                {
                    queryable = queryable.Where(item => item.RoleID == roleID);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(moduleID))
                {
                    queryable = queryable.Where(item => item.ModuleID == moduleID);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(menuID))
                {
                    queryable = queryable.Where(item => item.MenuID == menuID);
                    hasCriteria = true;
                }

                var userRoleAuthors = queryable.ToList();

                if (hasCriteria && !userRoleAuthors.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !userRoleAuthors.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(userRoleAuthors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetUserRoleAuthor([FromBody] List<Mas_UserRoleAuthor> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No UserRoleAuthors were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_UserRoleAuthor.Where(item => item.RoleID == obj.RoleID && item.ModuleID == obj.ModuleID && item.MenuID == obj.MenuID);
                    if (!checkobj.Any())
                    {
                        _db.Mas_UserRoleAuthor.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"RoleID : [{obj.RoleID}],ModuleID : [{obj.ModuleID}],MenuID : [{obj.MenuID}]  is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("UserRoleAuthors Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditUserRoleAuthor(Mas_UserRoleAuthor obj)
        {
            try
            {
                if (obj == null || obj.RoleID == "" || obj.ModuleID == "" || obj.MenuID == "")
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.RoleID == "")
                    {
                        return BadRequest("RoleID is invalid.");
                    }
                    else if (obj.ModuleID == "")
                    {
                        return BadRequest("ModuleID is invalid.");
                    }
                    else if (obj.MenuID == "")
                    {
                        return BadRequest("MenuID is invalid.");
                    }
                }
                var userRoleAuthor = _db.Mas_UserRoleAuthor.Find(obj.RoleID, obj.ModuleID, obj.MenuID);
                if (userRoleAuthor == null)
                {
                    return NotFound($"UserRoleAuthor not found with RoleID: {obj.RoleID}, ModuleID: {obj.ModuleID}, MenuID: {obj.MenuID}.");
                }
                foreach (PropertyInfo property in typeof(Mas_UserRoleAuthor).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(userRoleAuthor, property.GetValue(obj, null));
                }


                _db.SaveChanges();
                return Ok("UserRoleAuthor details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{roleID}")]
        public IActionResult DeleteUserRoleAuthor(string roleID, string moduleID, string menuID)
        {
            try
            {
                var userRoleAuthor = _db.Mas_UserRoleAuthor.Find(roleID, moduleID, menuID);
                if (userRoleAuthor == null)
                {
                    return NotFound($"userRoleAuthor not found with RoleID: {roleID}, ModuleID: {moduleID}, MenuID: {menuID}.");
                }
                _db.Mas_UserRoleAuthor.Remove(userRoleAuthor);
                _db.SaveChanges();
                return Ok("userRoleAuthor Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
