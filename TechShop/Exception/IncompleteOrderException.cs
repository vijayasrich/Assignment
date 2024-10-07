using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Exception
{
    public class IncompleteOrderException : IOException
    {
        public IncompleteOrderException(string message) : base(message) { }
    }

    public class OrderDetail
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            if (Product == null)
            {
                throw new IncompleteOrderException("Order detail is missing a product reference.");
            }
        }
    }
}
