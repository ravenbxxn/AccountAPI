using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly AppDbContext _db;

        public JournalController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetJournalHD(
                    int? entryID = null,
                    string journalNo = null,
                    DateTime? entryDate = null,
                    DateTime? effectiveDate = null,
                    string entryBy = null)
        {
            try
            {
                var queryable = _db.Acc_JournalHD.AsQueryable();

                bool hasCriteria = false;

                if (entryID.HasValue)
                {
                    queryable = queryable.Where(item => item.EntryId == entryID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(journalNo))
                {
                    queryable = queryable.Where(item => item.JournalNo == journalNo);
                    hasCriteria = true;
                }

                if (entryDate.HasValue)
                {
                    queryable = queryable.Where(item => item.EntryDate == entryDate.Value);
                    hasCriteria = true;
                }

                if (effectiveDate.HasValue)
                {
                    queryable = queryable.Where(item => item.EffectiveDate == effectiveDate.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(entryBy))
                {
                    queryable = queryable.Where(item => item.EntryBy == entryBy);
                    hasCriteria = true;
                }

                var journalHDs = queryable.Select(item => new
                                { 
                                    item.EntryId,
                                    item.JournalNo,
                                    item.EntryDate,
                                    item.EffectiveDate,
                                    item.EntryBy,
                                    item.Description,
                                    TotalDebit = Convert.ToDecimal(item.TotalDebit).ToString("G29"),
                                    TotalCredit = Convert.ToDecimal(item.TotalCredit).ToString("G29")
                                }).ToList();

                if (hasCriteria && !journalHDs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !journalHDs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(journalHDs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetJournalHD(Acc_JournalHD obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                _db.Acc_JournalHD.Add(obj);
                _db.SaveChanges();
                return Ok( new { message = "JournalHD Created.", entryId = obj.EntryId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult EditJournalHD(Acc_JournalHD obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                var journalHd = _db.Acc_JournalHD.Find(obj.EntryId);
                if (journalHd == null)
                {
                    return BadRequest($"JournalHD not found with ID: {obj.EntryId}.");
                }
                foreach (PropertyInfo property in typeof(Acc_JournalHD).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(journalHd, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("JournalHD datail updated.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{entryID}")]
        public IActionResult DeleteJournalHD(int? entryID)
        {
            try
            {
                if (entryID == null)
                {
                    return BadRequest("ID is null or empty.");
                }
                var journalHD = _db.Acc_JournalHD.Find(entryID);
                if (journalHD == null)
                {
                    return BadRequest($"JournalHD not found with ID: {entryID}.");
                }
                _db.Acc_JournalHD.Remove(journalHD);
                _db.SaveChanges();
                return Ok("JournalHD deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetJournalDT(
                    int? entryID = null,
                    int? seq = null,
                    string accCode = null)
        {
            try
            {
                var queryable = _db.Acc_JournalDT.AsQueryable();

                bool hasCriteria = false;

                if (entryID.HasValue)
                {
                    queryable = queryable.Where(item => item.EntryId == entryID.Value);
                    hasCriteria = true;
                }

                if (seq.HasValue)
                {
                    queryable = queryable.Where(item => item.Seq == seq.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(accCode))
                {
                    queryable = queryable.Where(item => item.AccCode == accCode);
                    hasCriteria = true;
                }

                var journalDTs = queryable.Select(item => new
                                {
                                    item.EntryId,
                                    item.Seq, 
                                    item.AccCode,
                                    item.AccName,
                                    item.AccDesc,
                                    Debit = Convert.ToDecimal(item.Debit).ToString("G29"),
                                    Credit = Convert.ToDecimal(item.Credit).ToString("G29")
                                }).ToList();

                if (hasCriteria && !journalDTs.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !journalDTs.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(journalDTs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult SetJournalDT([FromBody] List<Acc_JournalDT> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No JournalDT were provided.");
                }

                foreach (var obj in objs)
                {
                    if (obj.EntryId == 0)
                    {
                        return BadRequest("EntryId is required.");
                    }

                    var latestItem = _db.Acc_JournalDT
                        .Where(x => x.EntryId == obj.EntryId)
                        .OrderByDescending(x => x.Seq)
                        .FirstOrDefault();

                    int nextItemNo = latestItem == null ? 1 : latestItem.Seq + 1;

                    obj.Seq = nextItemNo;

                    _db.Acc_JournalDT.Add(obj);
                }

                _db.SaveChanges();
                return Ok("JournalDTs Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditJournalDT(Acc_JournalDT obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest("Data is invalid.");
                }
                var journalDT = _db.Acc_JournalDT.Find(obj.EntryId,obj.Seq);
                if (journalDT == null)
                {
                    return BadRequest($"JournalDT not found with ID: {obj.EntryId}, Seq: {obj.Seq}.");
                }
                foreach (PropertyInfo property in typeof(Acc_JournalDT).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(journalDT, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("JournalDT datail updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{entryID}")]
        public IActionResult DeleteJournalDT(int? entryID,int? seq)
        {
            try
            {
                if (entryID == null)
                {
                    return BadRequest("ID is null or empty.");
                }
                var journalDT = _db.Acc_JournalDT.Find(entryID, seq);
                if (journalDT == null)
                {
                    return BadRequest($"JournalDT not found with ID: {entryID}, Seq: {seq}.");
                }
                _db.Acc_JournalDT.Remove(journalDT);
                _db.SaveChanges();
                return Ok("JournalDT deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
