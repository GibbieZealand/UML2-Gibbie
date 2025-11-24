using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface ICustomerRepository
    {
        public int Count { get; }
        List<Customer> GetAll();
        void AddCustomer(Customer customer);
        void AddVIPCustomer(VIPCustomer customer);
        Customer? GetCustomerByMobile(string mobile);
        Customer? SearchByCity(string city);
        Customer? GetCustomerByClubmember(string clubMember);
        void RemoveCustomer(string mobile);
        void PrintAllCustomers();

    }

}
