using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace eProdaja.Controllers
{
    [ApiController]

    public class VrsteProizvodumController : BaseController<Model.VrsteProizvodum>
    {
        public VrsteProizvodumController(IService<Model.VrsteProizvodum> service, ILogger<BaseController<Model.VrsteProizvodum>> _logger) : base(service, _logger)
        {
        }
    }
}
