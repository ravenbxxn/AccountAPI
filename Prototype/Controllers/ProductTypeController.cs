using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductTypeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProductType(
            int? productTypeID = null,
            string productTypeCode = null,
            string warehouseCode = null,
            bool? isMaterial = null,
            bool? isService = null,
            decimal? rateVat = null,
            decimal? rateWht = null,
            string vatType = null)
        {
            try
            {

                var queryable = _db.Mas_ProductType.AsQueryable();
                bool hasCriteria = false;

                if (productTypeID.HasValue)
                {
                    queryable = queryable.Where(item => item.ProductTypeID == productTypeID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productTypeCode))
                {
                    queryable = queryable.Where(item => item.ProductTypeCode == productTypeCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(warehouseCode))
                {
                    queryable = queryable.Where(item => item.WarehouseCode == warehouseCode);
                    hasCriteria = true;
                }

                if (isMaterial.HasValue)
                {
                    queryable = queryable.Where(item => item.IsMaterial == isMaterial.Value);
                    hasCriteria = true;
                }

                if (isService.HasValue)
                {
                    queryable = queryable.Where(item => item.IsService == isService.Value);
                    hasCriteria = true;
                }

                if (rateVat.HasValue)
                {
                    queryable = queryable.Where(item => item.RateVat == rateVat.Value);
                    hasCriteria = true;
                }

                if (rateWht.HasValue)
                {
                    queryable = queryable.Where(item => item.RateWht == rateWht.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(vatType))
                {
                    queryable = queryable.Where(item => item.VatType == vatType);
                    hasCriteria = true;
                }

                var productTypes = queryable.ToList();

                if (hasCriteria && !productTypes.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !productTypes.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(productTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetProductType([FromBody] List<Mas_ProductType> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No ProductTypes were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_ProductType.Where(item => item.ProductTypeCode == obj.ProductTypeCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_ProductType.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"ProductTypeCode : [{obj.ProductTypeCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("ProductTypes Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditProductType(Mas_ProductType obj)
        {
            try
            {
                if (obj == null || obj.ProductTypeID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.ProductTypeID == 0)
                    {
                        return BadRequest($"ProductTypeID: {obj.ProductTypeID} is invalid.");
                    }
                }

                var existingProducttype = _db.Mas_ProductType.Find(obj.ProductTypeID);
                if (existingProducttype == null)
                {
                    return NotFound($"ProductType not found with ProductID: {obj.ProductTypeID}.");
                }

                if (existingProducttype.ProductTypeCode != obj.ProductTypeCode)
                {
                    var duplicateProducttype = _db.Mas_ProductType.Any(item => item.ProductTypeCode == obj.ProductTypeCode && item.ProductTypeID != obj.ProductTypeID);
                    if (duplicateProducttype)
                    {
                        return BadRequest("ProductTypeCode is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_ProductType).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingProducttype, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("ProductType details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productTypeID}")]
        public IActionResult DeleteProductType(int productTypeID)
        {
            try
            {
                var producttype = _db.Mas_ProductType.Find(productTypeID);
                if (producttype == null)
                {
                    return NotFound($"ProductType not found with ProductTypeID: {productTypeID}.");
                }
                _db.Mas_ProductType.Remove(producttype);
                _db.SaveChanges();
                return Ok("ProductType Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
