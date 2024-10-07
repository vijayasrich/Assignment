using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    internal class CustomerRepository : ICustomer
    {

        public int CalculateTotalOrders()
        {
            throw new NotImplementedException();
        }
        public int CalculateTotalOrders(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");

            return customer.Orders.Count;
        }
        public string GetCustomerDetails()
        {
            throw new NotImplementedException();
        }

        // Method to get customer details
        public void GetCustomerDetails(Customer customer)
        {
            Console.WriteLine("Customer Details:");
            Console.WriteLine($"Customer ID: {customer.CustomerID}");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"Address: {customer.Address}");
        }
        public void UpdateCustomerInfo(string email, string phone, string address)
        {
            throw new NotImplementedException();
        }
        // Method to update customer information
        public void UpdateCustomerInfo(Customer customer, string email = null, string phone = null, string address = null)
        {
            if (!string.IsNullOrWhiteSpace(email))
                customer.Email = email;

            if (!string.IsNullOrWhiteSpace(phone))
                customer.Phone = phone;

            if (!string.IsNullOrWhiteSpace(address))
                customer.Address = address;

            Console.WriteLine("Customer information updated successfully.");
        }
    }
}

