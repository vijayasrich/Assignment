using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount {  get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        //public IEnumerable<object> OrderDetails { get; internal set; }
        public object OrderID { get; internal set; }
        public string Status { get; internal set; }

        public Order(int orderID, Customer customer, DateTime orderDate,decimal totalAmount)
        {
            OrderId = orderID;
            Customer = customer;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
        }
    }

}
