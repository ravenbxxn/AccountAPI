using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPrototype.Data;
using APIPrototype.Models;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly AppDbContext _db;

        public SupplierController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSupplier(
            int? supplierID = null,
            string supplierCode = null,
            string taxNumber = null,
            string taxBranch = null)
        {
            try
            {

                var queryable = _db.Mas_Supplier.AsQueryable();
                bool hasCriteria = false;

                if (supplierID.HasValue)
                {
                    queryable = queryable.Where(item => item.SupplierID == supplierID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(supplierCode))
                {
                    queryable = queryable.Where(item => item.SupplierCode == supplierCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(taxNumber))
                {
                    queryable = queryable.Where(item => item.TaxNumber == taxNumber);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(taxBranch))
                {
                    queryable = queryable.Where(item => item.TaxBranch == taxBranch);
                    hasCriteria = true;
                }

                var suppliers = queryable.ToList();

                if (hasCriteria && !suppliers.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !suppliers.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetSupplier([FromBody] List<Mas_Supplier> objs)
        {
            try
            {

                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Suppliers were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Supplier.Where(item => item.SupplierCode == obj.SupplierCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Supplier.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"SupplierCode : [{obj.SupplierCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Suppliers Created.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditSupplier(Mas_Supplier obj)
        {
            try
            {
                if (obj == null || obj.SupplierID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.SupplierID == 0)
                    {
                        return BadRequest($"SupplierID: {obj.SupplierID} is invalid.");
                    }
                }

                var exisitingSupplier = _db.Mas_Supplier.Find(obj.SupplierID);
                if (exisitingSupplier == null)
                {
                    return NotFound($"Supplier not found with SupplierID: {obj.SupplierID}.");
                }

                if (exisitingSupplier.SupplierCode != obj.SupplierCode)
                {
                    var duplicateSupplier = _db.Mas_Supplier.Any(item => item.SupplierCode == obj.SupplierCode && item.SupplierID != obj.SupplierID);
                    if (duplicateSupplier)
                    {
                        return BadRequest("SupplierCode is already exist.");
                    }
                }
                foreach (PropertyInfo property in typeof(Mas_Supplier).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(exisitingSupplier, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Supplier details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{supplierID}")]
        public IActionResult DeleteSupplier(int? supplierID)
        {
            try
            {
                if (supplierID == null || supplierID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var supplier = _db.Mas_Supplier.Find(supplierID);
                if (supplier == null)
                {
                    return NotFound($"Supplier not found with SupplierID: {supplierID}.");
                }
                _db.Mas_Supplier.Remove(supplier);
                _db.SaveChanges();
                return Ok("Supplier Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
