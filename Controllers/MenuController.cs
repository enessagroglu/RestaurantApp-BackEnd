
using Microsoft.AspNetCore.Mvc;
using RestaurantApp_BackEnd.Models.DTO;
using RestaurantApp_BackEnd.Services;

namespace RestaurantApp_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;

        public MenuController()
        {
            _menuService = new MenuService();
        }

        [HttpGet]
        public ActionResult<List<MenuItemDto>> GetMenuItems()
        {
            return _menuService.GetMenuItems();
        }

        [HttpPost]
        public ActionResult<MenuItemDto> AddMenuItem(MenuItemCreateDto newItemDto)
        {
            return _menuService.AddMenuItem(newItemDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            _menuService.DeleteMenuItem(id);
            return Ok();
        }
    }
}

