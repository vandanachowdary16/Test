﻿using ePizzaHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Contract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByUserNameAsync(string userName);
    }
}
