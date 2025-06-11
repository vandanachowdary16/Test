using ePizzaHub.Core.Contracts;
using ePizzaHub.Models.Response;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidateUserResponse> ValidateUserAsync(string username, string password)
        {
           var userdetails =await _userRepository.FindByUserNameAsync(username);
            if (userdetails is null) 
            {
                throw new Exception($"The user with email doesnt exists {username}");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, userdetails.Password);
            if (!isValidPassword) 
            {
                throw new Exception($"Invalid credentails for username {username}");
            }

            return new ValidateUserResponse
            {
                Name = userdetails.Name,
                Email = userdetails.Email,
                UserId = userdetails.Id,
                Roles = userdetails.Roles.Select(c => c.Name).ToList()
            };
        }
    }
}
