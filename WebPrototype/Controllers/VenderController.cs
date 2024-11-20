using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrototype.Models;

namespace WebPrototype.Controllers
{
    public class VenderController : Controller
    {
        Uri baseAddress = new Uri("http://localhost/APIPrototype/api/Prototype");

        private readonly HttpClient _client;


        public VenderController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Mas_Vender> venderList = new List<Mas_Vender>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Vender/GetVenders").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                venderList = JsonConvert.DeserializeObject<List<Mas_Vender>>(data);
            }
            return View(venderList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Mas_Vender obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress + "/Vender/SetVender", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Vender Created";
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
                Mas_Vender supplier = new Mas_Vender();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Vender/GetVender/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    supplier = JsonConvert.DeserializeObject<Mas_Vender>(data);
                }
                return View(supplier);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }


        [HttpPost]
        public IActionResult Edit(Mas_Vender obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "text/json");
                HttpResponseMessage reponse = _client.PutAsync(_client.BaseAddress + "/Vender/EditVender", content).Result;

                if (reponse.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Vender details updated.";
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
        [ValidateAntiForgeryToken] // ใช้งานเฉพาะในระบบการตรวจสอบต่อ CSRF (Cross-Site Request Forgery)
        public async Task<IActionResult> Delete(string id)
        {
            try
            {

                // ส่งคำขอ DELETE ไปยัง API Controller
                HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "/Vender/DeleteVender/" + id);

                // ตรวจสอบการตอบกลับจาก API
                if (response.IsSuccessStatusCode)
                {
                    // ถ้าลบสำเร็จ
                    TempData["SuccessMessage"] = "Vender has been deleted successfully.";
                    return RedirectToAction(nameof(Index)); // ไปยังหน้า Index หลังจากลบเสร็จ
                }
                else
                {
                    // ถ้าไม่สำเร็จ
                    TempData["ErrorMessage"] = "Failed to delete vender.";
                    return RedirectToAction(nameof(Index)); // หรือจะทำการ redirect ไปยังหน้า Index หลังจากเกิดข้อผิดพลาด
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting vender: {ex.Message}";
                return RedirectToAction(nameof(Index)); // หรือจะทำการ redirect ไปยังหน้า Index หลังจากเกิดข้อผิดพลาด
            }
        }
    }
}
