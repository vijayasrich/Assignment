using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    public class OrderDetailNotFoundException : IOException
    {
        public OrderDetailNotFoundException(string message) : base(message) { }
    }

}
