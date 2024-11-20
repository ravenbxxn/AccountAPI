using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ProductSetController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductSetController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProductSetHD(
            int? productSetHDID = null,
            string productSetCode = null,
            string promoCode = null,
            string salesCurrency = null,
            string incomeAccCode = null,
            string expenseAccCode = null)
        {
            try
            {

                var queryable = _db.Mas_ProductSetHD.AsQueryable();
                bool hasCriteria = false;

                if (productSetHDID.HasValue)
                {
                    queryable = queryable.Where(item => item.ProductSetHDID == productSetHDID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productSetCode))
                {
                    queryable = queryable.Where(item => item.ProductSetCode == productSetCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(promoCode))
                {
                    queryable = queryable.Where(item => item.PromoCode == promoCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(salesCurrency))
                {
                    queryable = queryable.Where(item => item.SalesCurrency == salesCurrency);
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

                var productSetHDs = queryable.ToList();

                if (hasCriteria && !productSetHDs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !productSetHDs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(productSetHDs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetProductSetHD([FromBody] List<Mas_ProductSetHD> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No ProductSetHD were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_ProductSetHD.Where(item => item.ProductSetCode == obj.ProductSetCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_ProductSetHD.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"ProductSetCode : [{obj.ProductSetCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("ProductSetHD Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditProductSetHD(Mas_ProductSetHD obj)
        {
            try
            {
                if (obj == null || obj.ProductSetHDID <= 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.ProductSetHDID <= 0)
                    {
                        return BadRequest($"ProductSetHD ID: {obj.ProductSetHDID} is invalid.");
                    }
                }

                var existingPDSHD = _db.Mas_ProductSetHD.Find(obj.ProductSetHDID);
                if (existingPDSHD == null)
                {
                    return NotFound($"ProductSetHD not found with ID: {obj.ProductSetHDID}.");
                }

                if (existingPDSHD.ProductSetCode != obj.ProductSetCode)
                {
                    var duplicatePDSHD = _db.Mas_ProductSetHD.Any(item => item.ProductSetCode == obj.ProductSetCode && item.ProductSetHDID != obj.ProductSetHDID);
                    if (duplicatePDSHD)
                    {
                        return BadRequest("ProductSetCode is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_ProductSetHD).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingPDSHD, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("ProductSetHD details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productSetHDID}")]
        public IActionResult DeleteProductSetHD(int? productSetHDID)
        {
            try
            {
                if (productSetHDID == null || productSetHDID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var PDSHD = _db.Mas_ProductSetHD.Find(productSetHDID);
                if (PDSHD == null)
                {
                    return NotFound($"ProductSetHD not found with ID: {productSetHDID}.");
                }
                _db.Mas_ProductSetHD.Remove(PDSHD);
                _db.SaveChanges();
                return Ok("ProductSetHD Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProductSetDT(
           int? productSetDTID = null,
           string productSetCode = null,
           int? itemNo = null,
           string productCode = null)
        {
            try
            {

                var queryable = _db.Mas_ProductSetDT.AsQueryable();
                bool hasCriteria = false;

                if (productSetDTID.HasValue)
                {
                    queryable = queryable.Where(item => item.ProductSetDTID == productSetDTID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productSetCode))
                {
                    queryable = queryable.Where(item => item.ProductSetCode == productSetCode);
                    hasCriteria = true;
                }

                if (itemNo.HasValue)
                {
                    queryable = queryable.Where(item => item.ItemNo == itemNo.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productCode))
                {
                    queryable = queryable.Where(item => item.ProductCode == productCode);
                    hasCriteria = true;
                }

                var productSetDTs = queryable.ToList();

                if (hasCriteria && !productSetDTs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !productSetDTs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(productSetDTs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetProductSetDT([FromBody] List<Mas_ProductSetDT> objs)
        {

            try
            {

                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No ProductSetDTs were provided.");
                }

                foreach (var obj in objs)
                {
                    _db.Mas_ProductSetDT.Add(obj);
                }
                _db.SaveChanges();
                return Ok("ProductSetDTs Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditProductSetDT(Mas_ProductSetDT obj)
        {
            try
            {
                if (obj == null || obj.ProductSetDTID <= 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.ProductSetDTID <= 0)
                    {
                        return BadRequest($"ProductSetDT ID: {obj.ProductSetDTID} is invalid.");
                    }
                }
                var PDSDT = _db.Mas_ProductSetDT.Find(obj.ProductSetDTID);
                if (PDSDT == null)
                {
                    return NotFound($"ProductSetDT not found with ID: {obj.ProductSetDTID}.");
                }
                foreach (PropertyInfo property in typeof(Mas_ProductSetDT).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(PDSDT, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("ProductSetDT details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productSetDTID}")]
        public IActionResult DeleteProductSetDT(int productSetDTID)
        {
            try
            {
                var PDSDT = _db.Mas_ProductSetDT.Find(productSetDTID);
                if (PDSDT == null)
                {
                    return NotFound($"ProductSetDT not found with ID: {productSetDTID}.");
                }
                _db.Mas_ProductSetDT.Remove(PDSDT);
                _db.SaveChanges();
                return Ok("ProductSetDT Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
