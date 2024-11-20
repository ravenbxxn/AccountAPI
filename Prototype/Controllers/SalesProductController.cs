using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPrototype.Models;
using APIPrototype.Data;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class SalesProductController : ControllerBase
    {
        private readonly AppDbContext _db;

        public SalesProductController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSalesProductHD(
            int? salesProductIDHD = null,
            string salesProductCode = null,
            DateTime? beginSalesDate = null,
            DateTime? endSalesDate = null)
        {
            try
            {

                var queryable = _db.Mas_SalesProductHD.AsQueryable();
                bool hasCriteria = false;

                if (salesProductIDHD.HasValue)
                {
                    queryable = queryable.Where(item => item.SalesProductIDHD == salesProductIDHD.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(salesProductCode))
                {
                    queryable = queryable.Where(item => item.SalesProductCode == salesProductCode);
                    hasCriteria = true;
                }

                if (beginSalesDate.HasValue)
                {
                    queryable = queryable.Where(item => item.BeginSalesDate == beginSalesDate.Value);
                    hasCriteria = true;
                }

                if (endSalesDate.HasValue)
                {
                    queryable = queryable.Where(item => item.EndSalesDate == endSalesDate.Value);
                    hasCriteria = true;
                }

                var salesProductHD = queryable.ToList();

                if (hasCriteria && !salesProductHD.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !salesProductHD.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(salesProductHD);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetSalesProductHD(Mas_SalesProductHD obj)
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

                var checkobj = _db.Mas_SalesProductHD.Where(item => item.SalesProductCode == obj.SalesProductCode);
                if (!checkobj.Any())
                {
                    _db.Mas_SalesProductHD.Add(obj);
                    _db.SaveChanges();
                    return Ok("SalesProductHD Created.");
                }
                else
                {
                    return BadRequest("SalesProductHD is already exsist.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditSalesProductHD(Mas_SalesProductHD obj)
        {
            try
            {
                if (obj == null || obj.SalesProductIDHD == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.SalesProductIDHD == 0)
                    {
                        return BadRequest($"SalesProductHD: {obj.SalesProductIDHD} is invalid.");
                    }
                }

                var existingSalesPDHD = _db.Mas_SalesProductHD.Find(obj.SalesProductIDHD);
                if (existingSalesPDHD == null)
                {
                    return NotFound($"SalesProductHD not found with ID: {obj.SalesProductIDHD}.");
                }
                if (existingSalesPDHD.SalesProductCode != obj.SalesProductCode)
                {
                    var duplicateSalesPDHD = _db.Mas_SalesProductHD.Any(item => item.SalesProductCode == obj.SalesProductCode && item.SalesProductIDHD != obj.SalesProductIDHD);
                    if (duplicateSalesPDHD)
                    {
                        return BadRequest("SalesProductHD is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_SalesProductHD).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingSalesPDHD, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("SalesProductHD details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{salesProductIDHD}")]
        public IActionResult DeleteSalesProductHD(int salesProductIDHD)
        {
            try
            {
                var SalesPDHD = _db.Mas_SalesProductHD.Find(salesProductIDHD);
                if (SalesPDHD == null)
                {
                    return NotFound($"SalesProductHD not found with ID: {salesProductIDHD}.");
                }
                _db.Mas_SalesProductHD.Remove(SalesPDHD);
                _db.SaveChanges();
                return Ok("SalesProductHD Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSalesProductDT(
            int? salesProductIDDT = null,
            string salesProductCode = null,
            int? salesItemNo = null,
            string productSetCode = null)
        {
            try
            {

                var queryable = _db.Mas_SalesProductDT.AsQueryable();
                bool hasCriteria = false;

                if (salesProductIDDT.HasValue)
                {
                    queryable = queryable.Where(item => item.SalesProductIDDT == salesProductIDDT.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(salesProductCode))
                {
                    queryable = queryable.Where(item => item.SalesProductCode == salesProductCode);
                    hasCriteria = true;
                }

                if (salesItemNo.HasValue)
                {
                    queryable = queryable.Where(item => item.SalesItemNo == salesItemNo.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(productSetCode))
                {
                    queryable = queryable.Where(item => item.ProductSetCode == productSetCode);
                    hasCriteria = true;
                }

                var salesProductDT = queryable.ToList();

                if (hasCriteria && !salesProductDT.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !salesProductDT.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(salesProductDT);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetSalesProductDTs([FromBody] List<Mas_SalesProductDT> objs)
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
                    return BadRequest("No SalesProductDTs were provided.");
                }

                foreach (var obj in objs)
                {
                    _db.Mas_SalesProductDT.Add(obj);
                }
                _db.SaveChanges();
                return Ok("SalesProductDT Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditSalesProductDT(Mas_SalesProductDT obj)
        {

            try
            {
                if (obj == null || obj.SalesProductIDDT == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.SalesProductIDDT == 0)
                    {
                        return BadRequest($"SalesProductHD: {obj.SalesProductIDDT} is invalid.");
                    }
                }
                var SalesPDDT = _db.Mas_SalesProductDT.Find(obj.SalesProductIDDT);
                if (SalesPDDT == null)
                {
                    return NotFound($"SalesProductHD not found with ID: {obj.SalesProductIDDT}.");
                }
                foreach (PropertyInfo property in typeof(Mas_SalesProductDT).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(SalesPDDT, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("SalesProductDT details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{salesProductIDDT}")]
        public IActionResult DeleteSalesProductDT(int salesProductIDDT)
        {
            try
            {
                var SalesPDDT = _db.Mas_SalesProductDT.Find(salesProductIDDT);
                if (SalesPDDT == null)
                {
                    return NotFound($"SalesProductDT not found with ID: {salesProductIDDT}.");
                }
                _db.Mas_SalesProductDT.Remove(SalesPDDT);
                _db.SaveChanges();
                return Ok("SalesProductDT Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
