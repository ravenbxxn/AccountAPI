/*using APIPrototype.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static APIPrototype.Models.View_Model;

namespace APIPrototype.Controllers
{
    [Route("api/Prototype/[controller]/[action]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        private readonly ViewService _service;

        public ViewController(ViewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockCard()
        {
            var stockcard = await _service.GetStockCardsAsync();
            return Ok(stockcard);
        }

        [HttpGet]
        public async Task<IActionResult> GetStockOnHand()
        {
            var stockOnHand = await _service.GetStockOnHandsAsync();
            return Ok(stockOnHand);
        }

        [HttpGet]
        public async Task<IActionResult> GetJV(string? JournalNo = null)
        {
            var JV = await _service.GetJVsAsync(JournalNo);
            return Ok(JV);
        }

        [HttpGet]
        public async Task<IActionResult> GetSumBalance(string? accMainCode = null, string? accMainName = null)
        {
            var sumBalance = await _service.GetSumBalancesAsync(accMainCode, accMainName);
            return Ok(sumBalance);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrailBalance(string? accCode = null, string? accMainCode = null)
        {
            var trailBalance = await _service.GetTrailBalancesAsync(accCode, accMainCode);
            return Ok(trailBalance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccCode(string? accCode = null, string? accMainCode = null, string? accTypeName = null)
        {
            var accCodes = await _service.GetAccCodesAsync(accCode, accMainCode, accTypeName);
            return Ok(accCodes);
        }

        [HttpGet]
        public async Task<IActionResult> GetWarehouse()
        {
            var warehouse = await _service.GetWarehousesAsync();
            return Ok(warehouse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductType()
        {
            var productType = await _service.GetProductTypesAsync();
            return Ok(productType);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var product = await _service.GetProductsAsync();
            return Ok(product);
        }

    }
}
*/