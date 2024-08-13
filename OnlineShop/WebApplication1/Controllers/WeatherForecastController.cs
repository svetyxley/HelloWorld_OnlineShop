using Microsoft.AspNetCore.Mvc;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Entities;
using OnlineShop.Records;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private SuppliersService suppliersService = new SuppliersService(new DapperContext(), new ActivityLogService(), new OutputManager());
        private IConfiguration configuration;

        public WeatherForecastController(IConfiguration config, ILogger<WeatherForecastController> logger)
        {
            configuration = config;
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Supplier> Get()
        {
            var conString = configuration.GetConnectionString("Master");
            var result = suppliersService.GetAllSupliers(conString);

            return result;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
