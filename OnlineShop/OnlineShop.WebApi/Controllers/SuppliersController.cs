using Microsoft.AspNetCore.Mvc;
using OnlineShop.BusinessLayer.DTOs;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Entities;
using OnlineShop.WebApi.DTOs;

namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private SuppliersService _suppliersService;
        private IConfiguration _configuration;


        public SuppliersController(IConfiguration configuration, SuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("suppliers")]
        public async Task<List<Supplier>> GetAll()
        {
            var conStr = _configuration.GetConnectionString("Master");
            var suppliers = await _suppliersService.GetAllSuppliers(conStr);
            return suppliers;
        }

        [HttpGet]
        [Route("suppliers/{id}")]
        public async Task<GetSupplierDto> GetSupplierById([FromRoute]int id)
        {
            var conStr = _configuration.GetConnectionString("Master");
            var supplier = await _suppliersService.GetSupplierByID(id, conStr);
            return supplier;
        }

        [HttpPost]
        [Route("suppliers")]
        public async Task<Supplier> CreateSupplier([FromBody]CreateSupplierDto supplierDto)
        {
            var conStr = _configuration.GetConnectionString("Master");

            var supplier = await _suppliersService.CreateSupplier(supplierDto.Name, supplierDto.Code, conStr);

            return supplier;
        }
    }
}
