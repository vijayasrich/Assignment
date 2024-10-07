using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    public class Inventory
    {
        public int InventoryId {  get; set; }
        public Product Product { get; set; }
        public int QuantityInStock {  get; set; }
        public DateTime LastStockUpdate { get; set; }

        public Inventory(int inventoryID, Product product, int quantityInStock)
        {
            InventoryId = inventoryID;
            Product = product;
            QuantityInStock = quantityInStock;
            LastStockUpdate = DateTime.Now;
        }
    }
}
