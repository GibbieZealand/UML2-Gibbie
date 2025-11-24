using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Exceptions
{
    //Test can be found in the console menu, did not bother testing the UML2 Console
    public class TooLowDiscountException : Exception
    {
        public TooLowDiscountException(string message) : base(message)
        { }
    }
}
