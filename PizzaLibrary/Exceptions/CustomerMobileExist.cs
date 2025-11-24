using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Exceptions
{
    //works in Console, does not work in menu.
        //Assigment does not state it needs to, either. ¯\_(ツ)_/¯
    public class CustomerMobileExists : Exception
    {
        public CustomerMobileExists(string message) : base(message)
        { }
    }
}
