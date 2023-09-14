using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase
    {
        private readonly IProizvodiService proizvodiService;

        private readonly ILogger<WeatherForecastController> _logger;

        public ProizvodiController(ILogger<WeatherForecastController> logger, IProizvodiService service)
        {
            _logger = logger;
            proizvodiService= service;
        }

        [HttpGet]
        public IEnumerable<Proizvodi> Get()
        {
            return proizvodiService.Get();
        }
    }
}