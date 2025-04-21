using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProduct(int? productID = null, string productCode = null, string productTypeCode = null)
        {
            try
            {

                var queryable = _db.Mas_Products.AsQueryable();
                bool hasCriteria = false;

                if (productID.HasValue)
                {
                    queryable = queryable.Where(item => item.ProductID == productID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productCode))
                {
                    queryable = queryable.Where(item => item.ProductCode == productCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productTypeCode))
                {
                    queryable = queryable.Where(item => item.ProductTypeCode == productTypeCode);
                    hasCriteria = true;
                }

                var products = queryable.ToList();

                if (hasCriteria && !products.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !products.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetProduct([FromBody] List<Mas_Products> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Products were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Products.Where(item => item.ProductCode == obj.ProductCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Products.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"ProductCode : [{obj.ProductCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Products Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult EditProduct(Mas_Products obj)
        {

            try
            {
                if (obj == null || obj.ProductID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.ProductID == 0)
                    {
                        return BadRequest($"ProductID: {obj.ProductID} is invalid.");
                    }
                }

                var existingProduct = _db.Mas_Products.Find(obj.ProductID);
                if (existingProduct == null)
                {
                    return NotFound($"Product not found with ProductID: {obj.ProductID}.");
                }

                if (existingProduct.ProductCode != obj.ProductCode)
                {
                    var duplicateProduct = _db.Mas_Products.Any(item => item.ProductCode == obj.ProductCode && item.ProductID != obj.ProductID);
                    if (duplicateProduct)
                    {
                        return BadRequest("ProductCode is already exist.");
                    }
                }
                foreach (PropertyInfo property in typeof(Mas_Products).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingProduct, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Product details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productID}")]
        public IActionResult DeleteProduct(int? productID)
        {
            try
            {
                if (productID == null || productID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var product = _db.Mas_Products.Find(productID);
                if (product == null)
                {
                    return NotFound($"Product not found with ProductID: {productID}.");
                }
                _db.Mas_Products.Remove(product);
                _db.SaveChanges();
                return Ok("Product Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
