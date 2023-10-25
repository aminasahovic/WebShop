using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch> where TDb : class where T : class where TSearch : BaseSearchObject
    {
        protected EProdajaContext context;
        protected IMapper mapper;

        public BaseService(EProdajaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public virtual async Task<PagedResult<T>> Get(TSearch search)
        {
            var query = context.Set<TDb>().AsQueryable(); //  DbSet expects to be filtered because of AsQueryable

            PagedResult<T> result=new PagedResult<T>();

            query =AddFilter(query, search); // A function that filtered DbSet
            result.Count = await query.CountAsync(); 


            if (search?.Page.HasValue==true && search?.PageSize.HasValue == true)//After filter, pagination 
            {
                query=query.Take(search.PageSize.Value).Skip(search.Page.Value*search.PageSize.Value);
            }
            
            var list = await query.ToListAsync();

            var tmp = mapper.Map<List<T>>(list);
            result.Result=tmp;
            return result;

        }
        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search)
        {
            return query;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entitiy=context.Set<TDb>().Find(id);

            return mapper.Map<T>(entitiy);
        }
    }
}
