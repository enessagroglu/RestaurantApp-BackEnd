
using Microsoft.AspNetCore.Mvc;
using RestaurantApp_BackEnd.Models.DTO;
using RestaurantApp_BackEnd.Services;
using System.Globalization;

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
    public async Task<IActionResult> AddMenuItem([FromForm] MenuItemCreateDto newItemDto, IFormFile image)
    {
        if (image != null && image.Length > 0)
        {
            var fileExtension = Path.GetExtension(image.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/menuItems", uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            newItemDto.Image = $"{uniqueFileName}";
        }

        
        if (!decimal.TryParse(newItemDto.Price, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedPrice))
        {
            return BadRequest("Geçersiz fiyat formatı.");
        }

        newItemDto.Price = parsedPrice.ToString();

        var addedItem = _menuService.AddMenuItem(newItemDto);
        return Ok(addedItem);
    }



    [HttpDelete("delete/{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            _menuService.DeleteMenuItem(id);
            return Ok();
        }
    }
}

