using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        override public int Discount { get; set; }
        //UML2.2 13 - Look back at CustomerRepo to establish a search by it
        public VIPCustomer(string name, string mobile, string address, int discount) : base(name, mobile, address)
        {
            Discount = discount;
        }
        //Needs to be able to remove a discount off menuitems (How do I make it withdraw a percentage off the price of an item?)
        // Probably something like "Price = Price * Discount (must be between 0.01 and 0.25) the problem is that it's an int"
        // so more reasonably it'd be like "Price = (Price / Discount) * 100 

        //Needs to be able to be assigned at user creation (how?)
        // I think what I'd want is for it to be able to go off the club member thing, and then ask for a value.if it doesn't meet the 
        // Parameters, it returns an error, or boots you back to the menu screen. It's probably easier to do there than to do it here
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
