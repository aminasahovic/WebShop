using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace eProdaja.Controllers
{
    [ApiController]

    public class VrsteProizvodumController : BaseController<Model.VrsteProizvodum, BaseSearchObject>
    {
        public VrsteProizvodumController(IService<Model.VrsteProizvodum, BaseSearchObject> service, ILogger<BaseController<Model.VrsteProizvodum, BaseSearchObject>> _logger) : base(service, _logger)
        {
        }
    }
}
