using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            try
            {
                _customers[customer.Mobile] = customer;
                CheckExistingMobile(customer.Mobile);
            }
            catch (CustomerMobileExists cMex)
            {
                Console.WriteLine(cMex.Message);
            }
        }
        void ICustomerRepository.AddVIPCustomer(VIPCustomer vipCustomer)
        {
            _customers[vipCustomer.Mobile] = vipCustomer;
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
        public Customer? GetCustomerByClubmember(string clubMember)
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
                Console.WriteLine($"{customer.Value.Id} {customer.Value.Name} " +
                    $"at {customer.Value.Address} " +
                    $"contact {customer.Value.Mobile}, " +
                    $"is club member?: {customer.Value.ClubMember}, " +
                    $"VIP Discount: {customer.Value.Discount}%");
            }
            Console.WriteLine();
        }
        void CheckExistingMobile(string mobile)
        {
            foreach (var customer in _customers)
            {
                if (customer.Value.Mobile.Equals(mobile)) 
                {
                    throw new CustomerMobileExists("Dette nummer er allerede registreret.");
                }
            }
        }
    }
}
