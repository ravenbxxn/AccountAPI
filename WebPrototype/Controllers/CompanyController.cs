using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrototype.Models;

namespace WebPrototype.Controllers
{
    public class CompanyController : Controller
    {
        Uri baseAddress = new Uri("http://localhost/APIPrototype/api/Prototype");

        private readonly HttpClient _client;


        public CompanyController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Mas_Company> companyList = new List<Mas_Company>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Company/GetCompanys").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                companyList = JsonConvert.DeserializeObject<List<Mas_Company>>(data);
            }
            return View(companyList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Mas_Company obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/Company/SetCompany", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Customer Created.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                Mas_Company company = new Mas_Company();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Company/GetCompany/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    company = JsonConvert.DeserializeObject<Mas_Company>(data);
                }
                return View(company);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Mas_Company obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage reponse = _client.PutAsync(_client.BaseAddress + "/Company/EditCompany", content).Result;

                if (reponse.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = $"Customer {obj.CustCode} details updated.";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {

                HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "/Company/DeleteCompany/" + id);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Customer has been deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // ถ้าไม่สำเร็จ
                    TempData["ErrorMessage"] = "Failed to delete customer.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting customer: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
