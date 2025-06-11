using ePizzaHub.Core.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authservice)
        {
            _authService = authservice;
        }

        [HttpGet]
        public async Task<IActionResult> ValidateUser(string username,string password)
        {
            var response = await _authService.ValidateUserAsync(username, password);
            return Ok(response);
        }
    }
}
