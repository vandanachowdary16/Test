using ePizzaHub.Infrastructure.Models;
using ePizzaHub.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PizzaHubContext dbcontext) : base(dbcontext) 
        {
            
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await _dbcontext
                            .Users
                            .Include(c=>c.Roles)
                            .FirstOrDefaultAsync(c => c.Email == userName);
        }
    }
}
