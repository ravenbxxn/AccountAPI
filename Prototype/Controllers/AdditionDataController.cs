using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.AccessControl;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class AdditionDataController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AdditionDataController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAdditionData(string docNo = null, int? seq = null)
        {
            try
            {

                var queryable = _db.Acc_AdditionData.AsQueryable();
                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(docNo))
                {
                    queryable = queryable.Where(item => item.DocNo == docNo);
                    hasCriteria = true;

                }

                if (seq.HasValue)
                {
                    queryable = queryable.Where(item => item.Seq == seq.Value);
                    hasCriteria = true;
                }

                var additionDatas = queryable.ToList();

                if (hasCriteria && !additionDatas.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !additionDatas.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(additionDatas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetAdditionData([FromBody] List<Acc_AdditionData> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No AdditionDatas were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Acc_AdditionData.Where(item => item.DocNo == obj.DocNo && item.Seq == obj.Seq);
                    if (!checkobj.Any())
                    {
                        _db.Acc_AdditionData.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"DocNo : [{obj.DocNo}],Seq : [{obj.Seq}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("AdditionDatas Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAdditionData(Acc_AdditionData obj)
        {
            try
            {
                if ( obj == null || obj.DocNo == null || obj.Seq < 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.DocNo == null || obj.Seq < 0)
                    {
                        return BadRequest($"AdditionData DocNo: {obj.DocNo} or Seq: {obj.Seq} is invalid.");
                    }
                }
                var additionData = _db.Acc_AdditionData.Find(obj.DocNo, obj.Seq);
                if (additionData == null)
                {
                    return NotFound($"AdditionData not found with DocNo: {obj.DocNo}, Seq: {obj.Seq}.");
                }
                foreach (PropertyInfo property in typeof(Acc_AdditionData).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(additionData, property.GetValue(obj, null));
                }


                _db.SaveChanges();
                return Ok("AdditionData details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{docNo}")]
        public IActionResult DeleteAdditionData(string docNo, int seq)
        {
            try
            {
                var additionData = _db.Acc_AdditionData.Find(docNo, seq);
                if (additionData == null)
                {
                    return NotFound($"AdditionData not found with DocNo: {docNo}, Seq: {seq}.");
                }
                _db.Acc_AdditionData.Remove(additionData);
                _db.SaveChanges();
                return Ok("AdditionData Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
