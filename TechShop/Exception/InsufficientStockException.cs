using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Exception
{
    public class InsufficientStockException : IOException
    {
        public InsufficientStockException(string message) : base(message) { }
    }

    public class Inventory
    {
        public Product Product { get; set; }
        public int QuantityInStock { get; set; }

        public void DecrementStock(int quantity)
        {
            if (QuantityInStock < quantity)
            {
                throw new InsufficientStockException("Insufficient stock for product: " + Product.ProductName);
            }
            QuantityInStock -= quantity;
        }
    }
}
