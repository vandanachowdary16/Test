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
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(PizzaHubContext dbcontext) : base(dbcontext)
        {

        }

        public async Task<int> GetCartItemQuantityAsync(Guid guid)
        {
            int itemcount = await _dbcontext.CartItems.Where(c => c.CartId == guid).CountAsync();
            return itemcount;
        }
    }
}
