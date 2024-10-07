using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    public class ProductRepository : IProduct
    {
        private List<Product> products = new List<Product>();

        // Method to retrieve and display detailed information about a product
        public void GetProductDetails(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            Console.WriteLine("Product Details:");
            Console.WriteLine($"Product ID: {product.ProductID}");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price:$}");
        }

        // Method to update product information
        public void UpdateProductInfo(Product product, string description = null, decimal? price = null)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }

        // Method to check if the product is currently in stock
        public bool IsProductInStock(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            return false;
        }

        // Method to add a product to the repository (for demonstration purposes)
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

        }

        public string GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void UpdateProductInfo(string description, decimal price)
        {
            throw new NotImplementedException();
        }

        public bool IsProductInStock()
        {
            throw new NotImplementedException();
        }
    }
}