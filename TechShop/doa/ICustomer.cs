using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    internal interface ICustomer
    {
        int CalculateTotalOrders();
        string GetCustomerDetails();
        void UpdateCustomerInfo(string email, string phone, string address);

    }
}
