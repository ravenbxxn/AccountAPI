using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class DocConfigController : ControllerBase
    {
        private readonly AppDbContext _db;

        public DocConfigController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult GetDocConfig(int? docConfigId = null, string category = null)
        {
            try
            {

                var queryable = _db.Mas_DocConfig.AsQueryable();
                bool hasCriteria = false;

                if (docConfigId.HasValue)
                {
                    queryable = queryable.Where(item => item.DocConfigID == docConfigId.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(category))
                {
                    queryable = queryable.Where(item => item.Category == category);
                    hasCriteria = true;
                }


                var docConfigs = queryable.ToList();

                if (hasCriteria && !docConfigs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !docConfigs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(docConfigs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetDocConfig([FromBody] List<Mas_DocConfig> objs)
        {
            try
            {

                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No DocConfigs were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_DocConfig.Where(item => item.DocConfigID == obj.DocConfigID);
                    if (!checkobj.Any())
                    {
                        _db.Mas_DocConfig.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"DocConfig : [{obj.DocConfigID}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("DocConfigs Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditDocConfig(Mas_DocConfig obj)
        {
            try
            {
                if (obj == null || obj.DocConfigID <= 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.DocConfigID <= 0)
                    {
                        return BadRequest($"DocConfig ID: {obj.DocConfigID} is invalid.");
                    }
                }

                var existingDocConfig = _db.Mas_DocConfig.Find(obj.DocConfigID);
                if (existingDocConfig == null)
                {
                    return NotFound($"DocConfig not found with ID: {obj.DocConfigID}.");
                }

                if (existingDocConfig.Prefix != obj.Prefix)
                {
                    var duplicateDocConfig = _db.Mas_DocConfig.Any(item => item.Prefix == obj.Prefix && item.DocConfigID != obj.DocConfigID);
                    if (duplicateDocConfig)
                    {
                        return BadRequest("PrefixCode is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_DocConfig).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingDocConfig, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("DocConfig details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{docConfigID}")]
        public IActionResult DeleteDocConfig(int docConfigID)
        {
            try
            {
                if (docConfigID == null || docConfigID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }

                var DocConfig = _db.Mas_DocConfig.Find(docConfigID);
                if (DocConfig == null)
                {
                    return NotFound($"DocConfig not found with DocConfigID: {docConfigID}.");
                }
                _db.Mas_DocConfig.Remove(DocConfig);
                _db.SaveChanges();
                return Ok("DocConfig Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetDocConfigSchema(int? docConfigId = null ,int? configType = null)
        {
            try
            {

                var queryable = _db.Mas_DocConfigSchema.AsQueryable();
                bool hasCriteria = false;

                if (docConfigId.HasValue)
                {
                    queryable = queryable.Where(item => item.DocConfigID == docConfigId.Value);
                    hasCriteria = true;
                }

                if (configType.HasValue)
                {
                    queryable = queryable.Where(item => item.ConfigType == configType.Value);
                    hasCriteria = true;
                }

                var docConfigSchemas = queryable.ToList();

                if (hasCriteria && !docConfigSchemas.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !docConfigSchemas.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(docConfigSchemas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetDocConfigSchema([FromBody] List<Mas_DocConfigSchema> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No DocConfigSchemas were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_DocConfigSchema.Where(item => item.DocConfigID == obj.DocConfigID && item.ConfigType == obj.ConfigType);
                    if (!checkobj.Any())
                    {
                        _db.Mas_DocConfigSchema.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"DocConfigID : [{obj.DocConfigID}],ConfigType : [{obj.ConfigType}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("DocConfigSchema Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditDocConfigSchema(Mas_DocConfigSchema obj)
        {
            try
            {
                if (obj == null || obj.DocConfigID <= 0 )
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.DocConfigID <= 0 || obj.ConfigType < 0)
                    {
                        return BadRequest($"DocConfigSchema DocConfigID: {obj.DocConfigID} or ConfigType: {obj.ConfigType} is invalid.");
                    }
                }
                var docConfigSchema = _db.Mas_DocConfigSchema.Find(obj.DocConfigID, obj.ConfigType);
                if (docConfigSchema == null)
                {
                    return NotFound($"DocConfigSchema not found with DocConfigID: {obj.DocConfigID}, ConfigType: {obj.ConfigType}.");
                }
                foreach (PropertyInfo property in typeof(Mas_DocConfigSchema).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(docConfigSchema, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("DocConfigSchema details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{docConfigID}")]
        public IActionResult DeleteDocConfigSchema(int docConfigID, int configType)
        {
            try
            {
                var docConfigSchema = _db.Mas_DocConfigSchema.Find(docConfigID, configType);
                if (docConfigSchema == null)
                {
                    return NotFound($"DocConfigSchema not found with DocConfigID: {docConfigID}, ConfigType: {configType}.");
                }
                _db.Mas_DocConfigSchema.Remove(docConfigSchema);
                _db.SaveChanges();
                return Ok("DocConfigSchema Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
