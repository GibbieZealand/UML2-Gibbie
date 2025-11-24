using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class MenuItemRepo : IMenuItemRepository
    {
        private List<MenuItem> _menuItemList;
        public MenuItemRepo()
        {
            _menuItemList = MockData.MenuItemData;
        }
        public int Count { get { return _menuItemList.Count; } }
        List<MenuItem> IMenuItemRepository.GetAll()
        {
            return _menuItemList;
        }
        void IMenuItemRepository.AddMenuItem(MenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }
        MenuItem? IMenuItemRepository.GetMenuItemByNo(int no)
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.No == no)
                    return menuItem;
            }
            return null;
        }
        //needs to return a list rather than a single item
        public List<IMenuItem> GetMenuItemByType(MenuType menuType)
        {
            List<IMenuItem> _itemByType = new List<IMenuItem>();
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.TheMenuType == menuType)
                {
                    _itemByType.Add(menuItem);
                }
            }
            return _itemByType;
        }
        public MenuItem? GetMenuItemTypeByHighest(MenuType menuType)
        {
            foreach (var menuHighest in _menuItemList)
            {
                if (menuHighest.TheMenuType == menuType)
                {
                    var highestItemOfType = _menuItemList.MaxBy(m => m.Price); //Finds the highest value item within the category
                    // Test Code: it works
                    //Console.WriteLine($"Highest price of the type: {menuType} is: {menuHighest}");
                    return highestItemOfType;
                }
            }
            return null;
        }
        public MenuItem? GetPizzaByHighest()
        {
            foreach (var pizzaHighest in _menuItemList)
            {
                if (pizzaHighest.TheMenuType.ToString().StartsWith("PIZZE"))
                {
                    var highestPrice = _menuItemList.MaxBy(p => p.Price);
                    Console.WriteLine($"\nThe highest priced pizza is: {highestPrice.Name} at: {highestPrice.Price}kr.");
                    return highestPrice;
                }
                Console.WriteLine();
            }
            return null;
        }
        void IMenuItemRepository.RemoveMenuItem(int no)
        {
            for (int m = 0; m < _menuItemList.Count; m++)
            {
                if (_menuItemList[m].No == no)
                {
                    _menuItemList.RemoveAt(m);
                    return;
                }
            }
            Console.WriteLine($"Menu item {no} was succesfully removed");
        }

        void IMenuItemRepository.PrintAllMenuItems()
        {
            foreach (var menuItem in _menuItemList)
            {
                Console.WriteLine($"{menuItem.No} {menuItem.TheMenuType} {menuItem.Name} {menuItem.Description} {menuItem.Price}kr.");
            }
            Console.WriteLine();
        }
        // "Der skal laves en metode, som kan udskrive et menukort, hvor de forskellige menuitems præsenteres under deres menutype."
        public void PrintMenu()
        {
            Console.WriteLine($"\t------------ Menu ------------");
            foreach (MenuType t in Enum.GetValues(typeof(MenuType)))
            {
                Console.WriteLine($"\n\t{t}");
                List<IMenuItem> itemsOfType = GetMenuItemByType(t);
                foreach (var menuTypeItem in itemsOfType)
                {
                    Console.WriteLine($"\t * {menuTypeItem.Name}");
                }
            }
            Console.WriteLine("\n\t------------------------------");
        }
    }
}
