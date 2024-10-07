using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    public class ProductNotFoundException : IOException
    {
        public ProductNotFoundException(string message) : base(message) { }
    }
}
