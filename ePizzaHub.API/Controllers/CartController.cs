﻿using ePizzaHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("get-item-count")]
        public async Task<IActionResult> GetCartItemCount(Guid guid)
        {
            var itemcount = await _cartService.GetCartItemCountAsync(guid);
            return Ok(itemcount);
        }
    }
}
