using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.Customers
{
    public class AddCustomerController
    {
        ICustomerRepository _customerRepository;
        virtual public int VIPDiscount { get; set; }
        public Customer Customer { get; set; }

        public AddCustomerController(string name, string mobile, string address, bool clubMember, int discount, ICustomerRepository customerRepository)
        {
            Customer = new Customer(name, mobile, address);
            Customer.ClubMember = clubMember;
            _customerRepository = customerRepository;
        }

        public void AddCustomer()
        {
            _customerRepository.AddCustomer(Customer);
        }

        //public void AddVIPCustomer()
        //{
        //    _customerRepository.AddCustomer(VIPCustomer);
        //}

    }

}
