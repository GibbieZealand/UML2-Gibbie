using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Exceptions
{
    //The assigment specifically says to make an exception for already-existing menu item numbers,
    //but given how they're assigned automatically and cannot be handled by input, I don't really see the point,
    //or how I should even implement it. Sorry?
    public class MenuItemExist : Exception
    {
        public MenuItemExist(string message) :base(message) 
        { }
    }
}
