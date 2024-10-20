using Newtonsoft.Json;
using RestaurantApp_BackEnd.Models;


namespace RestaurantApp_BackEnd.Repositories
{
    public class MenuRepository
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "menuItems.json");

        public List<MenuItem> GetMenuItems()
        {
            if (!File.Exists(filePath))
            {
                return new List<MenuItem>();
            }

            var jsonData = File.ReadAllText(filePath);
            // Deserialize işlemi null dönerse, boş bir liste döndür
            return JsonConvert.DeserializeObject<List<MenuItem>>(jsonData) ?? new List<MenuItem>();
        }

        public void SaveMenuItems(List<MenuItem> menuItems)
        {
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(menuItems, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }


        public MenuItem AddMenuItem(MenuItem newItem)
        {
            var menuItems = GetMenuItems();
            newItem.Id = menuItems.Any() ? menuItems.Max(m => m.Id) + 1 : 1;
            menuItems.Add(newItem);
            SaveMenuItems(menuItems);
            return newItem;
        }

        public void DeleteMenuItem(int id)
        {
            var menuItems = GetMenuItems();
            var itemToRemove = menuItems.FirstOrDefault(m => m.Id == id);
            if (itemToRemove != null)
            {
                menuItems.Remove(itemToRemove);
                SaveMenuItems(menuItems);
            }
        }
    }
}
