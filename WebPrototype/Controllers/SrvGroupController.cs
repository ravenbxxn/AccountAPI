using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrototype.Models;

namespace WebPrototype.Controllers
{
    public class SrvGroupController : Controller
    {
        Uri baseAddress = new Uri("http://localhost/APIPrototype/api/Prototype");

        private readonly HttpClient _client;


        public SrvGroupController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Mas_SrvGroup> srvGroupList = new List<Mas_SrvGroup>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SrvGroup/GetSrvGroups").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                srvGroupList = JsonConvert.DeserializeObject<List<Mas_SrvGroup>>(data);
            }
            return View(srvGroupList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Mas_SrvGroup obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/SrvGroup/SetSrvGroup", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "SrvGroup Created.";
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
                Mas_SrvGroup srvGroup = new Mas_SrvGroup();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SrvGroup/GetSrvGroup/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    srvGroup = JsonConvert.DeserializeObject<Mas_SrvGroup>(data);
                }
                return View(srvGroup);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Mas_SrvGroup obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage reponse = _client.PutAsync(_client.BaseAddress + "/SrvGroup/EditSrvGroup", content).Result;

                if (reponse.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = $"SrvGroup {obj.GroupCode} details updated.";
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

                HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "/SrvGroup/DeleteSrvGroup/" + id);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "SrvGroup has been deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // ถ้าไม่สำเร็จ
                    TempData["ErrorMessage"] = "Failed to delete SrvGroup.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting SrvGroup: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
