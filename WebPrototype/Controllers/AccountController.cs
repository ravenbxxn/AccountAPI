using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrototype.Models;

namespace WebPrototype.Controllers
{
    public class AccountController : Controller
    {
        Uri baseAddress = new Uri("http://localhost/APIPrototype/api/Prototype");

        private readonly HttpClient _client;


        public AccountController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Mas_Account> AccountList = new List<Mas_Account>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Account/GetAccounts").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                AccountList = JsonConvert.DeserializeObject<List<Mas_Account>>(data);
            }
            return View(AccountList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Mas_Account obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/Account/SetAccount", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Account Created.";
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
                Mas_Account account = new Mas_Account();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Account/GetAccount/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    account = JsonConvert.DeserializeObject<Mas_Account>(data);
                }
                return View(account);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Mas_Account obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage reponse = _client.PutAsync(_client.BaseAddress + "/Account/EditAccount", content).Result;

                if (reponse.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = $"Account {obj.AccCode} details updated.";
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {

                HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "/Account/DeleteAccount/" + id);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Account has been deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // ถ้าไม่สำเร็จ
                    TempData["ErrorMessage"] = "Failed to delete account.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting account: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
