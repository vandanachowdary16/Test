using AutoMapper;
using ePizzaHub.Core.Contracts;
using ePizzaHub.Infrastructure.Models;
using ePizzaHub.Models.ApiModels.Request;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IRoleRepository roleRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<bool>  CreateUserRequestAsync(CreateUserRequest createUserRequest)
        {

            var roledetails = _roleRepository.GetAll().Where(c => c.Name == "User").FirstOrDefault();
            if(roledetails != null)
            {
                var user = _mapper.Map<User> (createUserRequest);
                user.Roles.Add (roledetails);

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await _userRepository.AddSync (user);

                int rowinserted = await _userRepository.CommitAsync();
                return rowinserted > 0;
            }
            return false;
        }
    }
}
