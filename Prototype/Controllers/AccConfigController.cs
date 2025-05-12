using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class AccConfigController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AccConfigController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAccConfig(string configCode = null, string configKey = null, string configValue = null)
        {
            try
            {

                var queryable = _db.Mas_AccConfig.AsQueryable();
                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(configCode))
                {
                    queryable = queryable.Where(item => item.ConfigCode == configCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(configKey))
                {
                    queryable = queryable.Where(item => item.ConfigKey == configKey);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(configValue))
                {
                    queryable = queryable.Where(item => item.ConfigValue == configValue);
                    hasCriteria = true;
                }

                var accConfigs = queryable.ToList();

                if (hasCriteria && !accConfigs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !accConfigs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(accConfigs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult SetAccConfig([FromBody] List<Mas_AccConfig> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No data were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_AccConfig.Where(item => item.ConfigCode == obj.ConfigCode && item.ConfigKey == obj.ConfigKey);
                    if (!checkobj.Any())
                    {
                        _db.Mas_AccConfig.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"ConfigCode : [{obj.ConfigCode}] , ConfigKey : [{obj.ConfigKey}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("AccConfig created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAccConfig(Mas_AccConfig obj)
        {

            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ConfigCode) || string.IsNullOrEmpty(obj.ConfigKey))
                {
                    return BadRequest("ConfigCode or ConfigKey is invalid.");
                }

                var existingAccConfig = _db.Mas_AccConfig.Find(obj.ConfigCode,obj.ConfigKey);
                if (existingAccConfig == null)
                {
                    // ถ้าไม่เจอ ให้เพิ่มใหม่
                    _db.Mas_AccConfig.Add(obj);
                    _db.SaveChanges();
                    return Ok("AccConfig created.");
                }

                // ถ้าเจอ ให้ update (ไม่อัปเดต primary key)
                var keyProps = new[] { "ConfigCode", "ConfigKey" };
                foreach (PropertyInfo property in typeof(Mas_AccConfig).GetProperties().Where(p => p.CanRead && !keyProps.Contains(p.Name)))
                {
                    property.SetValue(existingAccConfig, property.GetValue(obj));
                }

                _db.SaveChanges();
                return Ok("AccConfig updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{configCode}")]
        public IActionResult DeleteAccConfigT(string configCode, string configKey)
        {
            try
            {
                var accConfig = _db.Mas_AccConfig.Find(configCode, configKey);
                if (accConfig == null)
                {
                    return NotFound($"AccConfig not found with ConfigCode: {configCode}, ConfigKey: {configKey}.");
                }
                _db.Mas_AccConfig.Remove(accConfig);
                _db.SaveChanges();
                return Ok("AccConfig Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
