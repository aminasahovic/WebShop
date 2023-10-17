using AutoMapper;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseService<T, TDb> : IService<T> where TDb : class where T : class
    {
        EProdajaContext context;
        IMapper mapper;

        public BaseService(EProdajaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<T>> Get()
        {
            var query= context.Set<TDb>().AsQueryable();
            var list= await query.ToListAsync();
            return mapper.Map<List<T>>(list);

        }
    }
}
