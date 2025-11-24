using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        private static int _counter = 0;
        private int _no;
        public string Description { get; set; } 
        public string Name { get; set; }
        public int No { get { return _no; } }
        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }
        virtual public int Alcohol { get; set; }
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            _no = _counter++;
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
            
        }
    }
}
