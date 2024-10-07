using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    public class DuplicateProductException : IOException
    {
        public DuplicateProductException(string message) : base(message) { }
    }
}
