using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    public class OrderDetail
    {
        public int OrderDetailID {  get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity {  get; set; }

        public OrderDetail(int orderDetailID, Order order, Product product, int quantity)
        {
            OrderDetailID = orderDetailID;
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        internal decimal CalculateSubtotal()
        {
            throw new NotImplementedException();
        }
    }
}
