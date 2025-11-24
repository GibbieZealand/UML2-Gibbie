using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.Customers
{
    public class AddVIPCustomerController : AddCustomerController
    {
        ICustomerRepository _customerRepository;
        public override int VIPDiscount { get; set; }
        public AddVIPCustomerController(string name, string mobile, string address, bool clubMember, int discount, ICustomerRepository customerRepository) : base(name, mobile, address, clubMember, discount,  customerRepository)
        {
            Customer = new VIPCustomer(name, mobile, address, discount);
            Customer.ClubMember = clubMember;
            VIPDiscount = discount;
        }
        public void AddVIPCustomer()
        {
            _customerRepository.AddCustomer(Customer);
        }
    }
}
