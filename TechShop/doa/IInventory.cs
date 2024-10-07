using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.doa
{
    internal interface IInventory
    {
        Product GetProduct();
        int GetQuantityInStock();
        void AddToInventory(int quantity);
        void RemoveFromInventory(int quantity);
        void UpdateStockQuantity(int newQuantity);
        bool IsProductAvailable(int quantityToCheck);
        decimal GetInventoryValue();
        List<Product> ListLowStockProducts(int threshold);
        List<Product> ListOutOfStockProducts();
        List<Product> ListAllProducts();
    }
}
