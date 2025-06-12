using ePizzaHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _itemService.GetItemsasync();
            return Ok(items);
        }
    }
}
