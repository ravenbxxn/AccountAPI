using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrototype.Models;

namespace WebPrototype.Controllers
{
    public class ProfileController : Controller
    {
        Uri baseAddress = new Uri("http://localhost/APIPrototype/api/Prototype");

        private readonly HttpClient _client;


        public ProfileController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Acc_Profile> profileList = new List<Acc_Profile>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Profile/GetProfile").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                profileList = JsonConvert.DeserializeObject<List<Acc_Profile>>(data);
            }
            return View(profileList);
        }

        [HttpPost]
        public IActionResult Create(Acc_Profile obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/Profile/SetProfile", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Profile Created";
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
        public IActionResult Create()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Acc_Profile profile = new Acc_Profile();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Profile/GetProfile/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    profile = JsonConvert.DeserializeObject<Acc_Profile>(data);
                }
                return View(profile);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Acc_Profile obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage reponse = _client.PutAsync(_client.BaseAddress + "/Profile/EditProfile", content).Result;

                if (reponse.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Profile details updated.";
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
    }
}
