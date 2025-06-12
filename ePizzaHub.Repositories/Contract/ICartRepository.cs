﻿using ePizzaHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Contract
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<int> GetCartItemQuantityAsync(Guid guid);

    }
}
