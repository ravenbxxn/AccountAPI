using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CustomerController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetCustomer(int? customerID = null, string customerCode = null, string taxNumber = null, string taxBranch = null)
        {
            try
            {

                var queryable = _db.Mas_Customer.AsQueryable();
                bool hasCriteria = false;

                if (customerID.HasValue)
                {
                    queryable = queryable.Where(item => item.CustomerID == customerID.Value);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(customerCode))
                {
                    queryable = queryable.Where(item => item.CustomerCode == customerCode);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(taxNumber))
                {
                    queryable = queryable.Where(item => item.TaxNumber == taxNumber);
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(taxBranch))
                {
                    queryable = queryable.Where(item => item.TaxBranch == taxBranch);
                    hasCriteria = true;
                }

                var customers = queryable.ToList();

                if (hasCriteria && !customers.Any())
                {
                    return NotFound("No records found matching the specified criteria.");
                }
                else if (!hasCriteria && !customers.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult SetCustomer([FromBody] List<Mas_Customer> objs)
        {
            try
            {

                if (objs == null || objs.Count == 0)
                {
                    return BadRequest("No Customers were provided.");
                }

                foreach (var obj in objs)
                {
                    var checkobj = _db.Mas_Customer.Where(item => item.CustomerCode == obj.CustomerCode);
                    if (!checkobj.Any())
                    {
                        _db.Mas_Customer.Add(obj);
                    }
                    else
                    {
                        return BadRequest($"CustomerCode : [{obj.CustomerCode}] is already exsist.");
                    }
                }

                _db.SaveChanges();
                return Ok("Customers Created.");

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditCustomer(Mas_Customer obj)
        {
            
            try
            {
                if (obj == null || obj.CustomerID == 0)
                {
                    if (obj == null)
                    {
                        return BadRequest("Data is invalid.");
                    }
                    else if (obj.CustomerID == 0)
                    {
                        return BadRequest($"CustomerID: {obj.CustomerID} is invalid.");
                    }
                }

                var existingCustomer = _db.Mas_Customer.Find(obj.CustomerID);
                if (existingCustomer == null)
                {
                    return NotFound($"Customer not found with CustomerID: {obj.CustomerID}.");
                }

                if (existingCustomer.CustomerCode != obj.CustomerCode)
                {
                    var duplicateCustomer = _db.Mas_Customer.Any(item => item.CustomerCode == obj.CustomerCode && item.CustomerID != obj.CustomerID);
                    if (duplicateCustomer)
                    {
                        return BadRequest("CustomerCode is already exist.");
                    }
                }
                foreach (PropertyInfo property in typeof(Mas_Customer).GetProperties().Where(p => p.CanRead))
                {
                    string propertyName = property.Name;
                    property.SetValue(existingCustomer, property.GetValue(obj, null));
                }

                _db.SaveChanges();
                return Ok("Customer details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{customerID}")]
        public IActionResult DeleteCustomer(int customerID)
        {
            try
            {
                var customer = _db.Mas_Customer.Find(customerID);
                if (customer == null)
                {
                    return NotFound($"Customer not found with CustomerID: {customerID}.");
                }
                _db.Mas_Customer.Remove(customer);
                _db.SaveChanges();
                return Ok("Customer Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
