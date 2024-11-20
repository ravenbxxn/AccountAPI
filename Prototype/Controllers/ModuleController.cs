using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ModuleController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetModule(string moduleID = null)
        {
            try
            {

                var queryable = _db.Mas_Module.AsQueryable();
                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(moduleID))
                {
                    queryable = queryable.Where(item => item.ModuleID == moduleID);
                    hasCriteria = true;
                }

                var modules = queryable.ToList();

                if (hasCriteria && !modules.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !modules.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(modules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult SetModule([FromBody] List<Mas_Module> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Modules were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Module.Where(item => item.ModuleID == obj.ModuleID);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Module.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"ModuleID : [{obj.ModuleID}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Modules Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditModule(Mas_Module obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                var existingModule = _db.Mas_Module.Find(obj.ModuleID);
                if (existingModule == null)
                {
                    return BadRequest($"Module not found with ID: {obj.ModuleID}.");
                }

                foreach (PropertyInfo property in typeof(Mas_Module).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingModule, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("Module datail updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{moduleID}")]
        public IActionResult DeleteModule(string moduleID)
        {
            try
            {
                var module = _db.Mas_Module.Find(moduleID);
                if (module == null)
                {
                    return NotFound($"Module not found with ID: {moduleID}.");
                }
                _db.Mas_Module.Remove(module);
                _db.SaveChanges();
                return Ok("Module Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetModuleMenu(string moduleID = null,string menuID = null)
        {
            try
            {
                var queryable = _db.Mas_ModuleMenu.AsQueryable();
                bool hasCriteria = false;

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

                var moduleMenus = queryable.ToList();

                if (hasCriteria && !moduleMenus.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !moduleMenus.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(moduleMenus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetModuleMenu([FromBody] List<Mas_ModuleMenu> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No ModuleMenus were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_ModuleMenu.Where(item => item.ModuleID == obj.ModuleID && item.MenuID == obj.MenuID);
                    if (!checkobj.Any())
                    {
                        _db.Mas_ModuleMenu.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"ModuleID : [{obj.ModuleID}],MenuID : [{obj.MenuID}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("ModuleMenus Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditModuleMenu(Mas_ModuleMenu obj)
        {
            try
            {
                if (obj == null || obj.ModuleID == "" || obj.MenuID == "")
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
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
                var moduleMenu = _db.Mas_ModuleMenu.Find(obj.ModuleID, obj.MenuID);
                if (moduleMenu == null)
                {
                    return NotFound($"ModuleMenu not found with ModuleID: {obj.ModuleID}, MenuID: {obj.MenuID}.");
                }
                foreach (PropertyInfo property in typeof(Mas_ModuleMenu).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(moduleMenu, property.GetValue(obj, null));
                }


                _db.SaveChanges();
                return Ok("ModuleMenu details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{moduleID}")]
        public IActionResult DeleteModuleMenu(string moduleID, string menuId)
        {
            try
            {
                var moduleMenu = _db.Mas_ModuleMenu.Find(moduleID, menuId);
                if (moduleMenu == null)
                {
                    return NotFound($"ModuleMenu not found with ModuleID: {moduleID}, MenuId: {menuId}.");
                }
                _db.Mas_ModuleMenu.Remove(moduleMenu);
                _db.SaveChanges();
                return Ok("ModuleMenu Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
