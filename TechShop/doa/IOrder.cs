using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.doa
{
    internal interface IOrder
    {
        decimal CalculateTotalAmount();
        string GetOrderDetails();
        void UpdateOrderStatus(string status);
        void CancelOrder();
    }
}
