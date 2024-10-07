using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email{get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
        public Customer(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            Orders = new List<Order>();
        }

    }
}
