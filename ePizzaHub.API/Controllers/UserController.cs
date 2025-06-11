using ePizzaHub.Core.Contracts;
using ePizzaHub.Models.ApiModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userservice)
        {
          _userService = userservice;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest userRequest)
        {
            var result = await _userService.CreateUserRequestAsync(userRequest);
            return Ok();
        }
    }
}
