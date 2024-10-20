namespace RestaurantApp_BackEnd.Models.DTO
{
    public class MenuItemCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
