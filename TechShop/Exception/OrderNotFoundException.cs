using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    public class OrderNotFoundException : IOException
    {
        public OrderNotFoundException()
            : base("Order not found.")
        {
        }

        public OrderNotFoundException(string message)
            : base(message)
        {
        }

        public OrderNotFoundException(string message, IOException innerException)
            : base(message, innerException)
        {
        }
    }
}
