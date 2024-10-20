
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

        [HttpGet("get")]
        public ActionResult<List<MenuItemDto>> GetMenuItems()
        {
            return _menuService.GetMenuItems();
        }

        [HttpPost("post")]
        public ActionResult<MenuItemDto> AddMenuItem(MenuItemCreateDto newItemDto)
        {
            return _menuService.AddMenuItem(newItemDto);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            _menuService.DeleteMenuItem(id);
            return Ok();
        }
    }
}

