﻿
using RestaurantApp_BackEnd.Models.DTO;
using RestaurantApp_BackEnd.Models;
using RestaurantApp_BackEnd.Repositories;


namespace RestaurantApp_BackEnd.Services
{
    public class MenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService()
        {
            _menuRepository = new MenuRepository();
        }

        public List<MenuItemDto> GetMenuItems()
        {
            var menuItems = _menuRepository.GetMenuItems();
            var menuItemDtos = new List<MenuItemDto>();

            foreach (var item in menuItems)
            {
                menuItemDtos.Add(new MenuItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Ingredients = item.Ingredients,
                    Group = item.Group,
                    Image = $"{item.Image}",
                    Price = item.Price
                });
            }

            return menuItemDtos;
        }


        public MenuItemDto AddMenuItem(MenuItemCreateDto newItemDto)
        {
            var newItem = new MenuItem
            {
                Name = newItemDto.Name,
                Description = newItemDto.Description,
                Ingredients = newItemDto.Ingredients,
                Group = newItemDto.Group,
                Image = newItemDto.Image,
                Price = newItemDto.Price
            };

            var addedItem = _menuRepository.AddMenuItem(newItem);

            return new MenuItemDto
            {
                Id = addedItem.Id,
                Name = addedItem.Name,
                Description = addedItem.Description,
                Ingredients = addedItem.Ingredients,
                Group = addedItem.Group,
                Image = addedItem.Image,
                Price = addedItem.Price
            };
        }

        public void DeleteMenuItem(int id)
        {
            _menuRepository.DeleteMenuItem(id);
        }
    }
}

