using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    internal class OrderRepository : IOrder
    {
        private List<Order> orders = new List<Order>(); // Stores orders

        // Method to calculate the total amount of the order
        public decimal CalculateTotalAmount(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");

            decimal totalAmount = 0;
            foreach (var detail in order.OrderDetails)
            {
                totalAmount += detail.CalculateSubtotal(); // Assuming OrderDetails has a method to calculate subtotal
            }
            return totalAmount; // Return the total amount
        }

        // Method to retrieve and display the details of the order
        public void GetOrderDetails(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");

            Console.WriteLine("Order Details:");
            Console.WriteLine($"Order ID: {order.OrderID}");
            Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine($"Total Amount: {CalculateTotalAmount(order):C}"); // Format as currency

            Console.WriteLine("Order Items:");
            foreach (var detail in order.OrderDetails)
            {
                Console.WriteLine(value: $"Product: {detail.Product.ProductName}, Quantity: {detail.Quantity}, Subtotal: {detail.CalculateSubtotal():C}");
            }
        }

        // Method to update the status of the order
        public void UpdateOrderStatus(Order order, string newStatus)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Status cannot be null or empty.", nameof(newStatus));

            order.Status = newStatus; // Assuming Order has a Status property
            Console.WriteLine("Order status updated successfully.");
        }

        // Method to cancel the order and adjust stock levels for products
        public void CancelOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");

            // Logic to adjust stock levels for each product in the order
            foreach (var detail in order.OrderDetails)
            {
                // Assuming Inventory is a separate class managing stock levels
                // inventoryManager.AddToInventory(detail.Product, detail.Quantity); 
                throw new NotImplementedException("Stock adjustment logic will be implemented later.");
            }

            // Remove the order from the orders list (or mark it as canceled)
            orders.Remove(order); // Assuming you have logic in place to manage this correctly
            Console.WriteLine("Order has been canceled and stock levels adjusted.");
        }

        // Method to retrieve all orders
        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException("Retrieving all orders will be implemented later.");
        }

        public decimal CalculateTotalAmount()
        {
            throw new NotImplementedException();
        }

        public string GetOrderDetails()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus(string status)
        {
            throw new NotImplementedException();
        }

        public void CancelOrder()
        {
            throw new NotImplementedException();
        }
    }
}
