using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PromotionController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetPromotion(int? promoCodeID = null, string promoCode = null)
        {
            try
            {

                var queryable = _db.Mas_Promotions.AsQueryable();
                bool hasCriteria = false;

                if (promoCodeID.HasValue)
                {
                    queryable = queryable.Where(item => item.PromoCodeID == promoCodeID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(promoCode))
                {
                    queryable = queryable.Where(item => item.PromoCode == promoCode);
                    hasCriteria = true;
                }


                var promotions = queryable.ToList();

                if (hasCriteria && !promotions.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !promotions.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(promotions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SetPromotion([FromBody] List<Mas_Promotions> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Promotions were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Promotions.Where(item => item.PromoCode == obj.PromoCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Promotions.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"PromotionCode : [{obj.PromoCode}] is already exsist.");
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
        public IActionResult EditPromotion(Mas_Promotions obj)
        {
            try
            {
                if (obj == null || obj.PromoCodeID <= 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.PromoCodeID <= 0)
                    {
                        return BadRequest($"Promotion ID: {obj.PromoCodeID} is invalid.");
                    }
                }

                var existingPromotion = _db.Mas_Promotions.Find(obj.PromoCodeID);
                if (existingPromotion == null)
                {
                    return NotFound($"Promotion not found with ID: {obj.PromoCodeID}.");
                }

                if (existingPromotion.PromoCode != obj.PromoCode)
                {
                    var duplicatePromotion = _db.Mas_Promotions.Any(item => item.PromoCode == obj.PromoCode && item.PromoCodeID != obj.PromoCodeID);
                    if (duplicatePromotion)
                    {
                        return BadRequest("PromotionCode is already exist.");
                    }
                }

                foreach (PropertyInfo property in typeof(Mas_Promotions).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingPromotion, property.GetValue(obj, null));
                }
                _db.SaveChanges();
                return Ok("Promotion details updated.");

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{promotionCodeID}")]
        public IActionResult DeletePromotion(int? promotionCodeID)
        {
            try
            {
                if (promotionCodeID == null || promotionCodeID <= 0)
                {
                    return BadRequest("Invalid or missing ID.");
                }
                var pmt = _db.Mas_Promotions.Find(promotionCodeID);
                if (pmt == null)
                {
                    return NotFound($"Promotion not found with ID: {promotionCodeID}.");
                }
                _db.Mas_Promotions.Remove(pmt);
                _db.SaveChanges();
                return Ok("Promotion Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
