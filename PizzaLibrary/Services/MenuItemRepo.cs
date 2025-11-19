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
        MenuItem? IMenuItemRepository.GetMenuItemByType(MenuType menuType)
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.TheMenuType == menuType)
                {
                    return menuItem;
                }
            }
            return null;
        }
        MenuItem? IMenuItemRepository.GetMenuItemTypeByHighest(MenuType menuType)
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
        MenuItem? IMenuItemRepository.GetPizzaByHighest()
        {
            foreach (var pizzaHighest in _menuItemList)
            {
                if (pizzaHighest.TheMenuType.ToString().StartsWith("PIZZE"))
                {
                    var highestPrice = _menuItemList.MaxBy(p => p.Price);
                    Console.WriteLine($"it works now, dorkass. {pizzaHighest}");
                    return highestPrice;
                }
            }
            return null;
            //foreach (var pizzaType in Enum.GetNames(typeof(MenuType)))
            //{
            //    if (pizzaType.StartsWith("PIZZE")) //The sorting algorithm works, I think. Just need it to actually find the highest value
            //        //on further reflection, it might be just looking in MenuType, not at the actual menu. fuck.
            //    {
            //        var highestPizza = _menuItemList.MaxBy(x => x.Price);
            //        Console.WriteLine($"Highest price pizza is: {pizzaType}");
            //        return highestPizza;
            //    }
            //}
            //return null;
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
                Console.WriteLine(menuItem);
            }
            Console.WriteLine();
        }
        // "Der skal laves en metode, som kan udskrive et menukort, hvor de forskellige menuitems præsenteres under deres menutype."
    }
}
