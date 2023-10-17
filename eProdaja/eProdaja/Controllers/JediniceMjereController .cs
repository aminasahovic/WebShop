using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services;
using eProdaja.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    public class JediniceMjereController : BaseController<Model.JediniceMjere>
    {
        public JediniceMjereController(IJediniceMjereService service, ILogger<BaseController<Model.JediniceMjere>> _logger) : base(service, _logger)
        {
        }
    }
}