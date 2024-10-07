using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.doa
{
    internal interface IOrderDetail
    {
        decimal CalculateSubtotal();
        string GetOrderDetailInfo();
        void UpdateQuantity(int newQuantity);
        void AddDiscount(decimal discount);
    }
}
