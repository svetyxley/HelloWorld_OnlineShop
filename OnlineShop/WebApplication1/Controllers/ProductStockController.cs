using Microsoft.AspNetCore.Mvc;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using OnlineShop.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private ProductStocksService _productStocksService;
        private IConfiguration _configuration;
        public ProductStockController(IConfiguration configuration, ProductStocksService productStocksService)
        {
            _productStocksService = productStocksService;
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("productStocks/{id}")]
        public async Task<int> GetAmountByID([FromRoute]int id)
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var amount = await _productStocksService.GetAmountByStockItemID(id, connectionStr);
            return amount;
        }


        [HttpPost]
        [Route("productStocks")]
        public async Task<int> CreateProductOnStock([FromBody])
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var product = await _productStocksService.CreateProductOnStock(productId, productAmount, stockItemId, connectionStr);
            return amount;
        }
    }
}
