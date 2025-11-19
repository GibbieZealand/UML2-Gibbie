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
        MenuItem? GetMenuItemByType(MenuType menuType);
        MenuItem? GetMenuItemTypeByHighest(MenuType menuType);
        MenuItem? GetPizzaByHighest(); //<-- Its purpose is redundant and a mystery
        void RemoveMenuItem(int no);
        void PrintAllMenuItems();
        //"Der skal laves en metode, som kan udskrive et menukort, hvor de forskellige menuitems præsenteres under deres menutype."
    }

}
