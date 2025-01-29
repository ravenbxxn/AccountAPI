using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPrototype.Models;
using APIPrototype.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class AccTransactionController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AccTransactionController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult GetAccTransactionHD(
            string accDocNo = null,
            DateTime? accBatchDate = null,
            DateTime? accEffectiveDate = null,
            string partyCode = null,
            string partyTaxCode = null,
            string issueBy = null,
            string accDocType = null,
            DateTime? accPostDate = null,
            DateTime? fiscalYear = null,
            int? docStatus = null,
            string docRefNo = null)
        {
            try
            {
                var queryable = _db.Acc_TransactionHD.AsQueryable();

                // ตรวจสอบว่ามีการส่งพารามิเตอร์สำหรับการกรองหรือไม่
                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(accDocNo))
                {
                    queryable = queryable.Where(item => item.AccDocNo == accDocNo);
                    hasCriteria = true;
                }

                if (accBatchDate.HasValue)
                {
                    queryable = queryable.Where(item => item.AccBatchDate == accBatchDate.Value);
                    hasCriteria = true;
                }

                if (accEffectiveDate.HasValue)
                {
                    queryable = queryable.Where(item => item.AccEffectiveDate == accEffectiveDate.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(partyCode))
                {
                    queryable = queryable.Where(item => item.PartyCode == partyCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(partyTaxCode))
                {
                    queryable = queryable.Where(item => item.PartyTaxCode == partyTaxCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(issueBy))
                {
                    queryable = queryable.Where(item => item.IssueBy == issueBy);
                    hasCriteria = true;
                }

                /*if (!string.IsNullOrEmpty(accDocType))
                {
                    queryable = queryable.Where(item => item.AccDocType == accDocType);
                    hasCriteria = true;
                }*/

                if (!string.IsNullOrEmpty(accDocType)) // รับค่า accDocType หลายตัว เช่น ?accDocType=PO,DI
                {
                    var accDocTypeList = accDocType.Split(','); // แยกค่าด้วย Comma
                    queryable = queryable.Where(item => accDocTypeList.Contains(item.AccDocType));
                    hasCriteria = true;
                }

                if (accPostDate.HasValue)
                {
                    queryable = queryable.Where(item => item.AccPostDate == accPostDate.Value);
                    hasCriteria = true;
                }

                if (fiscalYear.HasValue)
                {
                    queryable = queryable.Where(item => item.FiscalYear == fiscalYear.Value);
                    hasCriteria = true;
                }

                if (docStatus.HasValue)
                {
                    queryable = queryable.Where(item => item.DocStatus == docStatus.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(docRefNo))
                {
                    queryable = queryable.Where(item => item.DocRefNo == docRefNo);
                    hasCriteria = true;
                }

                // ดึงข้อมูลหลังกรอง
                var accTransactionHD = queryable.ToList();

                if (hasCriteria && !accTransactionHD.Any())
                {
                    // กรณีส่ง criteria แต่ไม่มีข้อมูล
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !accTransactionHD.Any())
                {
                    // กรณีไม่ได้ส่ง criteria และไม่มีข้อมูลทั้งหมดในฐานข้อมูล
                    return NotFound("No records found.");
                }

                return Ok(accTransactionHD);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetAccTransactionHD(Acc_TransactionHD obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }

                var currentDate = DateTime.Now;
                var gregorianYear = (currentDate.Year % 100).ToString("D2");
                var month = currentDate.ToString("MM");
                var runningNumberPrefix = $"{obj.AccDocType}{gregorianYear}{month}";

                var lastTransaction = _db.Acc_TransactionHD
                    .Where(t => t.AccDocNo.StartsWith(runningNumberPrefix))
                    .OrderByDescending(t => t.AccDocNo)
                    .FirstOrDefault();

                var runningNumber = 1;
                if (lastTransaction != null)
                {
                    var lastNumber = lastTransaction.AccDocNo.Substring(runningNumberPrefix.Length);
                    runningNumber = int.Parse(lastNumber) + 1;
                }

                obj.AccDocNo = $"{runningNumberPrefix}{runningNumber:D4}";
                _db.Acc_TransactionHD.Add(obj);
                _db.SaveChanges();
                return Ok(new { message = "AccTransactionHD Created.", accDocNo = obj.AccDocNo });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAccTransactionHD(Acc_TransactionHD obj)
        {
            try
            {
                if (obj == null || obj.AccDocNo == "")
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.AccDocNo == "")
                    {
                        return BadRequest($"AccTransactionHD AccDocNo: {obj.AccDocNo} is invalid.");
                    }
                }
                var AccTransHD = _db.Acc_TransactionHD.Find(obj.AccDocNo);
                if (AccTransHD == null)
                {
                    return NotFound($"AccTransactionHD not found with ID: {obj.AccDocNo}.");
                }
                foreach (PropertyInfo property in typeof(Acc_TransactionHD).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(AccTransHD, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("AccTransactionHD details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accDocNo}")]
        public IActionResult DeleteAccTransactionHD(string accDocNo)
        {
            try
            {
                var AccTransHD = _db.Acc_TransactionHD.Find(accDocNo);
                if (AccTransHD == null)
                {
                    return NotFound($"AccTransactionHD not found with AccDocNo: {accDocNo}.");
                }
                _db.Acc_TransactionHD.Remove(AccTransHD);
                _db.SaveChanges();
                return Ok("AccTransactionHD Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAccTransactionDT(
            string accDocNo = null,
            int? accItemNo = null,
            string accSourceDocNo = null,
            int? accSourceDocItem = null,
            string saleProductCode = null)
        {
            try
            {
                var queryable = _db.Acc_TransactionDT.AsQueryable();

                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(accDocNo))
                {
                    queryable = queryable.Where(item => item.AccDocNo == accDocNo);
                    hasCriteria = true;
                }

                if (accItemNo.HasValue)
                {
                    queryable = queryable.Where(item => item.AccItemNo == accItemNo.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(accSourceDocNo))
                {
                    queryable = queryable.Where(item => item.AccSourceDocNo == accSourceDocNo);
                    hasCriteria = true;
                }

                if (accSourceDocItem.HasValue)
                {
                    queryable = queryable.Where(item => item.AccSourceDocItem == accSourceDocItem.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(saleProductCode))
                {
                    queryable = queryable.Where(item => item.SaleProductCode == saleProductCode);
                    hasCriteria = true;
                }             
               
                var accTransactionDT = queryable.ToList();

                if (hasCriteria && !accTransactionDT.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !accTransactionDT.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(accTransactionDT);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult SetAccTransactionDT([FromBody] List<Acc_TransactionDT> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No AccTransactionDT were provided.");
                }

                foreach (var obj in objs)
                {
                    if (string.IsNullOrEmpty(obj.AccDocNo))
                    {
                        return BadRequest("AccDocNo is required.");
                    }

                    // หา AccItemNo ล่าสุดที่ตรงกับ AccDocNo
                    var latestItem = _db.Acc_TransactionDT
                        .Where(x => x.AccDocNo == obj.AccDocNo)
                        .OrderByDescending(x => x.AccItemNo)
                        .FirstOrDefault();

                    // หากยังไม่มี AccItemNo ให้เริ่มต้นที่ 1
                    int nextItemNo = latestItem == null ? 1 : latestItem.AccItemNo + 1;

                    // กำหนดค่า AccItemNo ใหม่
                    obj.AccItemNo = nextItemNo;

                    // เพิ่มข้อมูลลงใน context
                    _db.Acc_TransactionDT.Add(obj);
                }

                _db.SaveChanges();
                return Ok("AccTransactionDTs Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAccTransactionDT(Acc_TransactionDT obj)
        {
            try
            {
                if (obj == null || obj.AccDocNo == "")
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.AccDocNo == "")
                    {
                        return BadRequest($"AccTransactionDT AccDocNo: {obj.AccDocNo} is invalid.");
                    }
                }
                var AccTransDT = _db.Acc_TransactionDT.Find(obj.AccDocNo,obj.AccItemNo);
                if (AccTransDT == null)
                {
                    return NotFound($"AccTransactionDT not found with AccDocNo: {obj.AccDocNo}, AccItemNo: {obj.AccItemNo}.");
                }
                foreach (PropertyInfo property in typeof(Acc_TransactionDT).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(AccTransDT, property.GetValue(obj, null));
                }


                _db.SaveChanges();
                return Ok("AccTransactionDT details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accDocNo}")]
        public IActionResult DeleteAccTransactionDT(string accDocNo,int accItemNo)
        {
            try
            {
                var AccTransDT = _db.Acc_TransactionDT.Find(accDocNo, accItemNo);
                if (AccTransDT == null)
                {
                    return NotFound($"AccTransactionDT not found with AccDocNo: {accDocNo}, AccItemNo: {accItemNo}.");
                }
                _db.Acc_TransactionDT.Remove(AccTransDT);
                _db.SaveChanges();
                return Ok("AccTransactionDT Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
