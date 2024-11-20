using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APIPrototype.Controllers
{
   
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public WarehousesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetWarehouse(
            int? warehouseID = null,
            string warehouseCode = null,
            string assetAccCode = null,
            string incomeAccCode = null,
            string expenseAccCode = null)
        {
            try
            {

                var queryable = _db.Mas_Warehouse.AsQueryable();
                bool hasCriteria = false;

                if (warehouseID.HasValue)
                {
                    queryable = queryable.Where(item => item.WarehouseID == warehouseID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(warehouseCode))
                {
                    queryable = queryable.Where(item => item.WarehouseCode == warehouseCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(assetAccCode))
                {
                    queryable = queryable.Where(item => item.AssetAccCode == assetAccCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(incomeAccCode))
                {
                    queryable = queryable.Where(item => item.IncomeAccCode == incomeAccCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(expenseAccCode))
                {
                    queryable = queryable.Where(item => item.ExpenseAccCode == expenseAccCode);
                    hasCriteria = true;
                }

                var wawrehouses = queryable.ToList();

                if (hasCriteria && !wawrehouses.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !wawrehouses.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(wawrehouses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetWarehouse([FromBody] List<Mas_Warehouse> objs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessages = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .SelectMany(kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
                        .ToArray();

                    return BadRequest(errorMessages);
                }

                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Warehouses were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Warehouse.Where(item => item.WarehouseCode == obj.WarehouseCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Warehouse.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"WarehouseCode : [{obj.WarehouseCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Warehouses Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditWarehouse(Mas_Warehouse obj)
        {
            try
            {
                if (obj == null || obj.WarehouseID <= 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.WarehouseID <= 0)
                    {
                        return BadRequest($"Warehouse ID: {obj.WarehouseID} is invalid.");
                    }
                }

                var existingWarehouse = _db.Mas_Warehouse.Find(obj.WarehouseID);
                if (existingWarehouse == null)
                {
                    return NotFound($"Warehouse not found with ID: {obj.WarehouseID}.");
                }

                if (existingWarehouse.WarehouseCode != obj.WarehouseCode)
                {
                    var duplicateWarehouseCode = _db.Mas_Warehouse.Any(item => item.WarehouseCode == obj.WarehouseCode && item.WarehouseID != obj.WarehouseID);
                    if (duplicateWarehouseCode)
                    {
                        return BadRequest("WarehouseCode is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_Warehouse).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingWarehouse, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Warehouse details updated.");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                return BadRequest($"An error occurred while saving the entity changes: {innerException}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{warehouseID}")]
        public IActionResult DeleteWarehouse(int? warehouseID)
        {
            try
            {
                if (warehouseID == null || warehouseID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var wh = _db.Mas_Warehouse.Find(warehouseID);
                if (wh == null)
                {
                    return NotFound($"Warehouse not found with ID: {warehouseID}.");
                }
                _db.Mas_Warehouse.Remove(wh);
                _db.SaveChanges();
                return Ok("Warehouse Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
