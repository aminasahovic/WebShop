using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using eProdaja.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    public class JediniceMjereController : BaseController<Model.JediniceMjere,JediniceMjereSearchObject>
    {
        public JediniceMjereController(IJediniceMjereService service, ILogger<BaseController<Model.JediniceMjere,JediniceMjereSearchObject>> _logger) : base(service, _logger)
        {
        }
    }
}