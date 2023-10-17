using AutoMapper;
using eProdaja.Model;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class JediniceMjereService : BaseService<Model.JediniceMjere,Database.JediniceMjere>, IJediniceMjereService
    {

        public JediniceMjereService(EProdajaContext context, IMapper mapper)
            :base(context,mapper)
        {
   
        }

    }
}
