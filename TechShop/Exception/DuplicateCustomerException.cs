using System.Runtime.Serialization;

namespace TechShop.Exception
{
    public class DuplicateCustomerException : IOException
    {
        public DuplicateCustomerException() { }

        public DuplicateCustomerException(string message) : base(message) { }

        public DuplicateCustomerException(string message, IOException inner) : base(message, inner) { }
    }
}
