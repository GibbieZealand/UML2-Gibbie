using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
   public class CustomerRepo : ICustomerRepository
   {
        private Dictionary<string, Customer> _customers;
        public CustomerRepo()
        {
            _customers = MockData.CustomerData;
        }
        public int Count { get { return _customers.Count; } }
        List<Customer> ICustomerRepository.GetAll()
        {
            //List<Customer> _customersList = new List<Customer>();
            //foreach (Customer customer in _customers.Values)
            //{
            //    _customersList.Add(customer);
            //}
            //return _customersList;
            return _customers.Values.ToList();
        }

        void ICustomerRepository.AddCustomer(Customer customer)
        {
            _customers[customer.Mobile] = customer;
        }
        Customer? ICustomerRepository.GetCustomerByMobile(string mobile)
        {
            return _customers.ContainsKey(mobile) ? _customers[mobile] : null;
        }
        Customer? ICustomerRepository.SearchByCity(string city)
        {
            return _customers.ContainsKey(city) ? _customers[city] : null;
        }
        //Come back to once the VIP Class is established
        public Customer? GetCustomerByVIP(string VIP)
        {
            throw new NotImplementedException();
        }
        void ICustomerRepository.RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
            Console.WriteLine($"Customer {mobile} has been removed");
        }
        void ICustomerRepository.PrintAllCustomers()
        {
            foreach(var customer in _customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();
        }
    }
}
