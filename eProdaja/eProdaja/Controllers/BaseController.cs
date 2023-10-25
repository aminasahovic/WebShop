using AutoMapper;
using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eProdaja.Controllers
{
    [Route("[controller]")]
    public class BaseController<T, Tsearch> :ControllerBase where T : class where Tsearch:class
    {
        private readonly IService<T,Tsearch> service; 
        private readonly ILogger<BaseController<T, Tsearch>> _logger;


        public BaseController(IService<T, Tsearch> service, ILogger<BaseController<T, Tsearch>> _logger)
        {
            this.service = service;
            this._logger = _logger;

        }

        [HttpGet()]
        public async Task<PagedResult<T>> Get([FromQuery] Tsearch? search=null)
        {
            return await service.Get(search);
        }


        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await service.GetById(id);
        }
    }
}
