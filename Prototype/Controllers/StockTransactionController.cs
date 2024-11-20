using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class StockTransactionController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StockTransactionController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetStockTransaction(
                    int? transID = null,
                    string transNum = null,
                    string transType = null,
                    string stockProductCode = null,
                    string transCurrency = null,
                    string warehouseCode = null,
                    string refDocNo = null)
        {
            try
            {
                var queryable = _db.Acc_StockTransaction.AsQueryable();
                bool hasCriteria = false;

                if (transID.HasValue)
                {
                    queryable = queryable.Where(item => item.TransID == transID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(transNum))
                {
                    queryable = queryable.Where(item => item.TransNum == transNum);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(transType))
                {
                    queryable = queryable.Where(item => item.TransType == transType);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(stockProductCode))
                {
                    queryable = queryable.Where(item => item.StockProductCode == stockProductCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(transCurrency))
                {
                    queryable = queryable.Where(item => item.TransCurrency == transCurrency);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(warehouseCode))
                {
                    queryable = queryable.Where(item => item.WarehouseCode == warehouseCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(refDocNo))
                {
                    queryable = queryable.Where(item => item.RefDocNo == refDocNo);
                    hasCriteria = true;
                }

                var stockTrans = queryable.ToList();

                if (hasCriteria && !stockTrans.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !stockTrans.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(stockTrans);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*        [HttpPost]
                public IActionResult SetStockTransaction(Acc_StockTransaction obj)
                {
                    try
                    {
                        if (obj == null)
                        {
                            return BadRequest("Data is invalid.");
                        }

                        var gregorianYear = DateTime.Now.Year.ToString(); // ปีปัจจุบัน (yyyy)
                        var month = DateTime.Now.ToString("MM"); // เดือนปัจจุบัน (MM)
                        var runningNumberPrefix = $"{gregorianYear}{month}"; // สร้างคำนำหน้าของ TransNum เป็น yyyyMM

                        // ค้นหาการทำรายการล่าสุดที่มีคำนำหน้าของ TransNum ตรงกัน
                        var lastTransaction = _db.Acc_StockTransaction
                            .Where(t => t.TransNum.StartsWith(runningNumberPrefix))
                            .OrderByDescending(t => t.TransNum)
                            .FirstOrDefault();

                        var runningNumber = 1;
                        if (lastTransaction != null)
                        {
                            var lastNumber = lastTransaction.TransNum.Substring(6); // ตัดส่วนปีและเดือน (yyyyMM) ออก
                            runningNumber = int.Parse(lastNumber) + 1;
                        }

                        // กำหนดค่า TransNum โดยมีการรันเลข 5 หลัก (xxxxx)
                        obj.TransNum = $"{runningNumberPrefix}{runningNumber:D5}";
                        _db.Acc_StockTransaction.Add(obj);
                        _db.SaveChanges();
                        return Ok("StockTransaction Created.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }*/

        [HttpPost]
        public IActionResult SetStockTransaction([FromBody] List<Acc_StockTransaction> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No StockTransaction were provided.");
                }

                foreach (var obj in objs)
                {
                    _db.Acc_StockTransaction.Add(obj);
                }

                _db.SaveChanges();
                return Ok("StockTransaction Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult EditStockTransaction(Acc_StockTransaction obj)
        {
            try
            {
                if (obj == null || obj.TransID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.TransID == 0)
                    {
                        return BadRequest($"StockTransactionID: {obj.TransID} is invalid.");
                    }
                }

                var stocktrans = _db.Acc_StockTransaction.Find(obj.TransID);
                if (stocktrans == null)
                {
                    return NotFound($"StockTransactionID not found with TransactionID: {obj.TransID}.");
                }

                foreach (PropertyInfo property in typeof(Acc_StockTransaction).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(stocktrans, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("StockTransaction details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{transID}")]
        public IActionResult DeleteStockTransaction(int transID)
        {
            try
            {
                var stocktrans = _db.Acc_StockTransaction.Find(transID);
                if (stocktrans == null)
                {
                    return NotFound($"StockTransaction not found with TransactionID: {transID}.");
                }
                _db.Acc_StockTransaction.Remove(stocktrans);
                _db.SaveChanges();
                return Ok("StockTransaction Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
