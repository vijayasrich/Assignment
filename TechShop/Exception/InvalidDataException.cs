using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    public class InvalidDataException : IOException
    {
        public InvalidDataException(string message) : base(message) { }
    }

    public class Customer
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (!IsValidEmail(value))
                {
                    throw new InvalidDataException("Invalid email address.");
                }
                email = value;
            }
        }

        private bool IsValidEmail(string email)
        {
            // Basic email validation logic
            return email.Contains("@");
        }
    }

}
