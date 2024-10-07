using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Exception
{
    public class ConcurrencyException : IOException
    {
        public ConcurrencyException(string message) : base(message) { }
    }

    public class OrderManager
    {
        private bool isBeingUpdated = false;

        public void UpdateOrder(Order order)
        {
            if (isBeingUpdated)
            {
                throw new ConcurrencyException("Order is currently being updated by another user.");
            }
            isBeingUpdated = true;

            // Perform update logic
            isBeingUpdated = false;
        }
    }
}
