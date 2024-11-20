using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CompanyController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult GetCompany(int? companyID = null, string companyTaxID = null, string companyTaxBranch = null)
        {
            try
            {

                var queryable = _db.Mas_Company.AsQueryable();
                bool hasCriteria = false;

                if (companyID.HasValue)
                {
                    queryable = queryable.Where(item => item.CompanyId == companyID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(companyTaxID))
                {
                    queryable = queryable.Where(item => item.CompanyTaxId == companyTaxID);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(companyTaxBranch))
                {
                    queryable = queryable.Where(item => item.CompanyTaxBranch == companyTaxBranch);
                    hasCriteria = true;
                }

                var companys = queryable.ToList();

                if (hasCriteria && !companys.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !companys.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(companys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult SetCompany([FromBody] List<Mas_Company> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Companys were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Company.Where(item => item.CompanyId == obj.CompanyId);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Company.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"CompanyID : [{obj.CompanyId}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Companys Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditCompany(Mas_Company obj)
        {
            try
            {
                if (obj == null || obj.CompanyId == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.CompanyId == 0)
                    {
                        return BadRequest($"CompanyUD: {obj.CompanyId} is invalid.");
                    }
                }

                var company = _db.Mas_Company.Find(obj.CompanyId);
                if (company == null)
                {
                    return NotFound($"Company not found with CompanyID: {obj.CompanyId}.");
                }

                foreach (PropertyInfo property in typeof(Mas_Company).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(company, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Company details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{companyID}")]
        public IActionResult DeleteCompany(int companyID)
        {
            try
            {
                var company = _db.Mas_Company.Find(companyID);
                if (company == null)
                {
                    return NotFound($"Company not found with CompanyID: {companyID}.");
                }
                _db.Mas_Company.Remove(company);
                _db.SaveChanges();
                return Ok("Company Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
