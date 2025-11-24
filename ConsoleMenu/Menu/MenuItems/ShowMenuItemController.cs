using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu.MenuItems
{
    public class ShowMenuItemController
    {
        private IMenuItemRepository _menuItemRepository;
        public ShowMenuItemController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public void ShowAllMenuItems()
        {
            _menuItemRepository.PrintAllMenuItems();
        }
    }

}
