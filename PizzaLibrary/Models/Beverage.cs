using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        override public int Alcohol { get; set; }
        public Beverage(string name, double price, string description, int alcohol, MenuType menuType) : base(name, price, description, menuType)
        {
            Alcohol = alcohol;
        }
    }
}
