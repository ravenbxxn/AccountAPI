using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrototype.Models;

namespace WebPrototype.Controllers
{
    public class SrvSingleController : Controller
    {
        Uri baseAddress = new Uri("http://localhost/APIPrototype/api/Prototype");

        private readonly HttpClient _client;


        public SrvSingleController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Mas_SrvSingle> srvSingleList = new List<Mas_SrvSingle>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SrvSingle/GetSrvSingles").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                srvSingleList = JsonConvert.DeserializeObject<List<Mas_SrvSingle>>(data);
            }
            return View(srvSingleList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Mas_SrvSingle obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/SrvSingle/SetSrvSingle", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "SrvSingle Created.";
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
                Mas_SrvSingle srvSingle = new Mas_SrvSingle();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SrvSingle/GetSrvSingle/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    srvSingle = JsonConvert.DeserializeObject<Mas_SrvSingle>(data);
                }
                return View(srvSingle);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }


        [HttpPost]
        public IActionResult Edit(Mas_SrvSingle obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage reponse = _client.PutAsync(_client.BaseAddress + "/SrvSingle/EditSrvSingle", content).Result;

                if (reponse.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = $"SrvSingle {obj.SICode} details updated.";
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

                HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "/SrvSingle/DeleteSrvSingle/" + id);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "SrvSingle has been deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // ถ้าไม่สำเร็จ
                    TempData["ErrorMessage"] = "Failed to delete SrvSingle.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting SrvSingle: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
