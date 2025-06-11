using ePizzaHub.UI.Models.ApiModels.Response;
using ePizzaHub.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ePizzaHub.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            var client = httpClientFactory.CreateClient("ePizzaAPI");

            var userDetails = await client.GetFromJsonAsync<ValidateUserResponse>(
                                        $"Auth?userName={request.EmailAddress}&password={request.Password}");

            if(userDetails is not null)
            {
                List<Claim> claims = new List<Claim>();
                await GenerateTicket(claims);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Login");
        }

        private async Task GenerateTicket(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                           principal,
                                           new AuthenticationProperties
                                           {
                                               IsPersistent = false,
                                               ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                                           });

        }

    }
}
