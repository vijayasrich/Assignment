using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public object Description { get; internal set; }

        public Product(int productID, string productName, string description, decimal price, bool inStock)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = description;
            Price = price;
            InStock = inStock;
        }
    }
}
