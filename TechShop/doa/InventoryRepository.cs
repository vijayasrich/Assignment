using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    internal class InventoryRepository: IInventory
    {
        private List<Inventory> inventory = new List<Inventory>();
        

        // Method to retrieve the product associated with this inventory item
        public Product GetProduct(Inventory inventory)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            return inventory.Product;
        }

        // Method to get the current quantity of the product in stock
        public int GetQuantityInStock(Inventory inventory)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            return inventory.QuantityInStock;
        }

        // Method to add a specified quantity of the product to the inventory
        public void AddToInventory(Inventory inventory, int quantity)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            inventory.QuantityInStock += quantity;
            Console.WriteLine($"Added {quantity} units to inventory for {inventory.Product.ProductName}.");
        }

        // Method to remove a specified quantity of the product from the inventory
        public void RemoveFromInventory(Inventory inventory, int quantity)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            if (inventory.QuantityInStock < quantity)
                throw new InvalidOperationException("Insufficient stock to remove the specified quantity.");

            inventory.QuantityInStock -= quantity;
            Console.WriteLine($"Removed {quantity} units from inventory for {inventory.Product.ProductName}.");
        }

        // Method to update the stock quantity to a new value
        public void UpdateStockQuantity(Inventory inventory, int newQuantity)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            if (newQuantity < 0)
                throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be positive.");

            inventory.QuantityInStock = newQuantity;
            Console.WriteLine($"Stock quantity updated to {newQuantity} for {inventory.Product.ProductName}.");
        }

        // Method to check if a specified quantity of the product is available in the inventory
        public bool IsProductAvailable(Inventory inventory, int quantityToCheck)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            return inventory.QuantityInStock >= quantityToCheck;
        }

        // Method to calculate the total value of the products in the inventory
        public decimal GetInventoryValue()
        {
            return inventory.Sum(inventory => inventory.Product.Price * inventory.QuantityInStock);
        }

        // Method to list products with quantities below a specified threshold
        public List<Product> ListLowStockProducts(int threshold)
        {
            return inventory
                .Where(item => item.QuantityInStock < threshold)
                .Select(item => item.Product)
                .ToList();
        }

        // Method to list products that are out of stock
        public List<Product> ListOutOfStockProducts()
        {
            return inventory
                .Where(item => item.QuantityInStock == 0)
                .Select(item => item.Product)
                .ToList();
        }

        // Method to list all products in the inventory, along with their quantities
        public List<Inventory> ListAllProducts()
        {
            return inventory;
        }

        public Product GetProduct()
        {
            throw new NotImplementedException();
        }

        public int GetQuantityInStock()
        {
            throw new NotImplementedException();
        }

        public void AddToInventory(int quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromInventory(int quantity)
        {
            throw new NotImplementedException();
        }

        public void UpdateStockQuantity(int newQuantity)
        {
            throw new NotImplementedException();
        }

        public bool IsProductAvailable(int quantityToCheck)
        {
            throw new NotImplementedException();
        }

        List<Product> IInventory.ListAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}