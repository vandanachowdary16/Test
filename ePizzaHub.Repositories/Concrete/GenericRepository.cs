using ePizzaHub.Infrastructure.Models;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected PizzaHubContext _dbcontext; 
        public GenericRepository(PizzaHubContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> AddSync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbcontext.Set<T>();
            return query.ToList();
        }
    }
}
