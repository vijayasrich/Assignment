using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.doa
{
    internal interface IProduct
    {
        string GetProductDetails();
        void UpdateProductInfo(string description, decimal price);
        bool IsProductInStock();
    }
}
