using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    internal class OrderDetailRepository: IOrderDetail
    {
        public decimal CalculateSubtotal()
        {
            throw new NotImplementedException();
        }

        public string GetOrderDetailInfo()
        {
            throw new NotImplementedException();
        }

        public void UpdateQuantity(int newQuantity)
        {
            throw new NotImplementedException();
        }

        public void AddDiscount(decimal discount)
        {
            throw new NotImplementedException();
        }
        public decimal CalculateSubtotal(OrderDetail orderDetail)
        {
            if (orderDetail == null)
                throw new ArgumentNullException(nameof(orderDetail), "OrderDetail cannot be null.");

            // Assuming Product has a Price property and orderDetail has a Quantity property
            return orderDetail.Product.Price * orderDetail.Quantity;
        }

        // Method to retrieve and display information about this order detail
        public void GetOrderDetailInfo(OrderDetail orderDetail)
        {
            if (orderDetail == null)
                throw new ArgumentNullException(nameof(orderDetail), "OrderDetail cannot be null.");

            Console.WriteLine("Order Detail Information:");
            Console.WriteLine($"Product Name: {orderDetail.Product.ProductName}");
            Console.WriteLine($"Quantity: {orderDetail.Quantity}");
            Console.WriteLine($"Subtotal: {CalculateSubtotal(orderDetail):C}");
        }

        // Method to update the quantity of the product in this order detail
        public void UpdateQuantity(OrderDetail orderDetail, int newQuantity)
        {
            if (orderDetail == null)
                throw new ArgumentNullException(nameof(orderDetail), "OrderDetail cannot be null.");

            orderDetail.Quantity = newQuantity;
            Console.WriteLine($"Quantity updated to: {newQuantity}");
        }

        // Method to apply a discount to this order detail
        public void AddDiscount(OrderDetail orderDetail, decimal discountPercentage)
        {
            if (orderDetail == null)
                throw new ArgumentNullException(nameof(orderDetail), "OrderDetail cannot be null.");

            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount must be between 0 and 100.");

            decimal discountAmount = CalculateSubtotal(orderDetail) * (discountPercentage / 100);
            Console.WriteLine($"Discount of {discountPercentage}% applied. Amount: {discountAmount:C}");
        }
    }
}

