using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IMenuItemRepository
    {
        int Count { get; }
        List<MenuItem> GetAll(); //Frankly I have no idea what this is for
        void AddMenuItem(MenuItem menuItem);
        MenuItem? GetMenuItemByNo(int no);
        List<IMenuItem> GetMenuItemByType(MenuType menuType);
        MenuItem? GetMenuItemTypeByHighest(MenuType menuType);
        MenuItem? GetPizzaByHighest();
        void RemoveMenuItem(int no);
        void PrintAllMenuItems();
        void PrintMenu();

    }

}
