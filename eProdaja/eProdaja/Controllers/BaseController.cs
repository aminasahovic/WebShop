using AutoMapper;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [Route("[controller]")]
    public class BaseController<T>:ControllerBase where T : class
    {
        private readonly IService<T> service; 
        private readonly ILogger<BaseController<T>> _logger;


        public BaseController(IService<T> service, ILogger<BaseController<T>> _logger)
        {
            this.service = service;
            this._logger = _logger;

        }

        [HttpGet()]
        public async Task<IEnumerable<T>> Get()
        {
            return await service.Get();
        }
    }
}
