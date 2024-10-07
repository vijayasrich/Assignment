using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.dao;


namespace TechShop.MainModule
{
    internal class TechShopMenu
    {
        readonly ICustomerService _customerService;
        readonly IProductService _productService;
        readonly IOrderService _orderService;
        readonly IOrderDetailService _orderDetailService;
        readonly IInventoryService _inventoryService;
        private string firstName;

        public TechShopMenu()
        {
            _customerService = new CustomerService();
            _productService = new ProductService();
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
            _inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("TechShop Management System");
                Console.WriteLine("1. Customer Management");
                Console.WriteLine("2. Product Management");
                Console.WriteLine("3. Order Management");
                Console.WriteLine("4. Order Detail Management");
                Console.WriteLine("5. Inventory Management");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int menu))
                {
                    switch (menu)
                    {
                        case 1:
                            ManageCustomers();
                            break;
                        case 2:
                            ManageProducts();
                            break;
                        case 3:
                            ManageOrders();
                            break;
                        case 4:
                            ManageOrderDetails();
                            break;
                        case 5:
                            ManageInventory();
                            break;
                        case 6:
                            exit = true; // Exit the loop
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ManageCustomers()
        {
            bool keepManaging = true;

            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Customer Management");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Get Customer Details");
                Console.WriteLine("3. Update Customer Info");
                Console.WriteLine("4. Remove Customer");
                Console.WriteLine("5. Calculate Total Orders");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            // Add Customer
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Phone: ");
                            string phone = Console.ReadLine();
                            Console.Write("Enter Address: ");
                            string address = Console.ReadLine();

                            var newCustomer = new Customer
                            {
                                FirstName = name,
                                Email = email,
                                Phone = phone,
                                Address = address
                            };

                            try
                            {
                                _customerService.AddCustomer(newCustomer);
                                Console.WriteLine("Customer added successfully.");
                            }
                            catch (IOException ex)
                            {
                                Console.WriteLine($"Error adding customer: {ex.Message}");
                            }
                            break;

                        case 2:
                            Console.Write("Enter Customer ID: ");
                            if (int.TryParse(Console.ReadLine(), out int customerId))
                            {
                                var customer = _customerService.GetCustomerDetails(customerId); // Get the Customer object from the database

                                if (customer != null)
                                {
                                    // Format the customer details as a string
                                    string customerDetails = $"ID: {customer.CustomerID}, Name: {customer.FirstName}, Email: {customer.Email}, Phone: {customer.Phone}, Address: {customer.Address}";
                                    Console.WriteLine(customerDetails); // Output formatted customer details
                                }
                                else
                                {
                                    Console.WriteLine("Customer not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Customer ID.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter Customer ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int updateCustomerId))
                            {
                                Console.Write("Enter new Email: ");
                                string newEmail = Console.ReadLine();
                                Console.Write("Enter new Phone Number: ");
                                string newPhone = Console.ReadLine();
                                Console.Write("Enter new Address: ");
                                string newAddress = Console.ReadLine();

                                _customerService.UpdateCustomerInfo(updateCustomerId, newEmail, newPhone, newAddress);
                                Console.WriteLine("Customer updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Customer ID.");
                            }
                            break;

                        case 4:
                            // Remove Customer
                            Console.Write("Enter Customer ID to remove: ");
                            if (int.TryParse(Console.ReadLine(), out int removeCustomerId))
                            {
                                try
                                {
                                    // Attempt to remove the customer using the service
                                    _customerService.RemoveCustomer(removeCustomerId);
                                    Console.WriteLine("Customer removed successfully.");
                                }
                                catch (KeyNotFoundException)
                                {
                                    // Handle the case where the customer ID does not exist
                                    Console.WriteLine($"Customer with ID {removeCustomerId} not found.");
                                }
                                catch (InvalidOperationException ex)
                                {
                                    // Handle the case where the customer cannot be removed due to existing orders
                                    Console.WriteLine(ex.Message);
                                }
                                catch (IOException ex)
                                {
                                    // Handle any other unexpected exceptions
                                    Console.WriteLine($"An error occurred: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Customer ID.");
                            }
                            break;


                        case 5:
                            // Calculate Total Orders
                            Console.Write("Enter Customer ID to calculate total orders: ");
                            if (int.TryParse(Console.ReadLine(), out int totalOrdersCustomerId))
                            {
                                int totalOrders = _customerService.CalculateTotalOrders(totalOrdersCustomerId);
                                Console.WriteLine($"Total Orders: {totalOrders}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Customer ID.");
                            }
                            break;

                        case 6:
                            keepManaging = false; // Exit to main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

    private void ManageProducts()
        {
            bool keepManaging = true;
            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Product Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Get Product Details");
                Console.WriteLine("5. Search Products");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Product Name: ");
                            string productName = Console.ReadLine();
                            Console.Write("Enter Description: ");
                            string productDescription = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            decimal productPrice = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Stock Quantity: ");
                            int productStock = int.Parse(Console.ReadLine());

                            var newProduct = new Product
                            {
                                ProductName = productName,
                                Description = productDescription,
                                Price = productPrice,
                                StockQuantity = productStock
                            };

                            _productService.AddProduct(newProduct);
                            Console.WriteLine("Product added successfully.");
                            break;

                        case 2:
                            // Update Product
                            Console.Write("Enter Product ID to update: ");
                            int updateProductId = int.Parse(Console.ReadLine());
                            Console.Write("Enter new Description: ");
                            string description = Console.ReadLine();
                            Console.Write("Enter new Price: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            _productService.UpdateProduct(updateProductId,description, price);
                            Console.WriteLine("Product updated successfully.");
                            break;

                        case 3:
                            // Remove Product
                            Console.Write("Enter Product ID to remove: ");
                            int removeProductId = int.Parse(Console.ReadLine());
                            _productService.RemoveProduct(removeProductId);
                            Console.WriteLine("Product removed successfully.");
                            break;

                        case 4:
                            // Get Product Details
                            Console.Write("Enter Product ID: ");
                            int productId = int.Parse(Console.ReadLine());
                            string productDetails = _productService.GetProductDetails(productId);
                            Console.WriteLine(productDetails ?? "Product not found.");
                            break;

                        case 5:
                            // Search Products
                            Console.Write("Enter search term: ");
                            string searchTerm = Console.ReadLine();
                            List<Product> products = _productService.SearchProducts(searchTerm);
                            Console.WriteLine("Search Results:");
                            foreach (var product in products)
                            {
                                Console.WriteLine($"- {product.ProductName}");
                            }
                            break;

                        case 6:
                            keepManaging = false; // Exit to main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
      
        private void ManageOrders()
        {
            bool keepManaging = true;
            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Order Management");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Get Orders by Customer ID");
                Console.WriteLine("3. Get All Orders");
                Console.WriteLine("4. Cancel Order");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Customer Name: ");
                            string customerNameForOrder = Console.ReadLine();

                            // Fetch customer details based on the name or prompt for other details
                            Customer customer = new Customer
                            {
                                FirstName = customerNameForOrder
                                // Add other properties if needed
                            };

                            Console.Write("Enter Order Date (yyyy-mm-dd): ");
                            DateTime orderDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Total Amount: ");
                            decimal totalAmount = decimal.Parse(Console.ReadLine());

                            var newOrder = new Order
                            {
                                Customer = customer, // Set the customer directly
                                OrderDate = orderDate,
                                TotalAmount = totalAmount
                            };

                            _orderService.AddOrder(newOrder);
                            Console.WriteLine("Order added successfully.");
                            break;

                        case 2:
                            // Get Orders by Customer ID
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            List<Order> orders = _orderService.GetOrdersByCustomerId(customerId);
                            Console.WriteLine("Orders for Customer:");
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"- Order ID: {order.OrderID}, Total Amount: {order.TotalAmount}");
                            }
                            break;

                        case 3:
                            // Get All Orders
                            List<Order> allOrders = _orderService.GetAllOrders();
                            Console.WriteLine("All Orders:");
                            foreach (var order in allOrders)
                            {
                                Console.WriteLine($"- Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                            }
                            break;

                        case 4:
                            // Cancel Order
                            Console.Write("Enter Order ID to cancel: ");
                            int orderId = int.Parse(Console.ReadLine());
                            _orderService.CancelOrder(orderId);
                            Console.WriteLine("Order cancelled successfully.");
                            break;

                        case 5:
                            keepManaging = false; // Exit to main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        
        private void ManageOrderDetails()
        {
            bool keepManaging = true;
            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Order Detail Management");
                Console.WriteLine("1. Add Order Detail");
                Console.WriteLine("2. Update Order Detail Quantity");
                Console.WriteLine("3. Add Discount to Order Detail");
                Console.WriteLine("4. Get Order Detail Info");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Order ID: ");
                            int orderIdForDetail = int.Parse(Console.ReadLine());

                            // Fetch the existing order from the service
                            string v = _orderService.GetOrderDetails(orderIdForDetail);
                            Order existingOrder = v;

                            if (existingOrder == null)
                            {
                                Console.WriteLine("Order not found. Please ensure the order ID is correct.");
                                break; // Exit to the main menu or handle accordingly
                            }

                            Console.Write("Enter Product ID: ");
                            int productIdForDetail = int.Parse(Console.ReadLine());

                            // Fetch the existing product from the service
                            string v1 = _productService.GetProductDetails(productIdForDetail);
                            Product existingProduct = v1;

                            if (existingProduct == null)
                            {
                                Console.WriteLine("Product not found. Please ensure the product ID is correct.");
                                break; // Exit to the main menu or handle accordingly
                            }

                            Console.Write("Enter Quantity: ");
                            int quantity = int.Parse(Console.ReadLine());

                            var newOrderDetail = new OrderDetail
                            {
                                Order = existingOrder,     // Set the existing order
                                Product = existingProduct,  // Set the existing product
                                Quantity = quantity
                            };

                            _orderDetailService.AddOrderDetail(newOrderDetail);
                            Console.WriteLine("Order detail added successfully.");
                            break;





                        case 2:
                            // Update Order Detail Quantity
                            Console.Write("Enter Order Detail ID to update: ");
                            int orderDetailId = int.Parse(Console.ReadLine());
                            Console.Write("Enter new Quantity: ");
                            int newQuantity = int.Parse(Console.ReadLine());
                            _orderDetailService.UpdateQuantity(orderDetailId, newQuantity);
                            Console.WriteLine("Order detail updated successfully.");
                            break;

                        case 3:
                            // Add Discount to Order Detail
                            Console.Write("Enter Order Detail ID to add discount: ");
                            int discountOrderDetailId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Discount Amount: ");
                            decimal discountAmount = decimal.Parse(Console.ReadLine());
                            _orderDetailService.AddDiscount(discountOrderDetailId, discountAmount);
                            Console.WriteLine("Discount added successfully.");
                            break;

                        case 4:
                            // Get Order Detail Info
                            Console.Write("Enter Order Detail ID: ");
                            int detailId = int.Parse(Console.ReadLine());
                            string orderDetailInfo = _orderDetailService.GetOrderDetailInfo(detailId);
                            Console.WriteLine(orderDetailInfo ?? "Order detail not found.");
                            break;

                        case 5:
                            keepManaging = false; // Exit to main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void ManageInventory()
        {
            bool keepManaging = true;
            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Inventory Management");
                Console.WriteLine("1. Add to Inventory");
                Console.WriteLine("2. Remove from Inventory");
                Console.WriteLine("3. Update Stock Quantity");
                Console.WriteLine("4. Get Inventory Value");
                Console.WriteLine("5. List Low Stock Products");
                Console.WriteLine("6. List Out of Stock Products");
                Console.WriteLine("7. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Add to Inventory
                            Console.Write("Enter Product ID: ");
                            int addProductId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Quantity to add: ");
                            int addQuantity = int.Parse(Console.ReadLine());
                            _inventoryService.AddToInventory(addProductId, addQuantity);
                            Console.WriteLine("Quantity added to inventory successfully.");
                            break;

                        case 2:
                            // Remove from Inventory
                            Console.Write("Enter Product ID: ");
                            int removeProductId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Quantity to remove: ");
                            int removeQuantity = int.Parse(Console.ReadLine());
                            _inventoryService.RemoveFromInventory(removeProductId, removeQuantity);
                            Console.WriteLine("Quantity removed from inventory successfully.");
                            break;

                        case 3:
                            // Update Stock Quantity
                            Console.Write("Enter Product ID to update stock: ");
                            int updateStockProductId = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Stock Quantity: ");
                            int newStockQuantity = int.Parse(Console.ReadLine());
                            _inventoryService.UpdateStockQuantity(updateStockProductId, newStockQuantity);
                            Console.WriteLine("Stock quantity updated successfully.");
                            break;

                        case 4:
                            // Get Inventory Value
                            decimal inventoryValue = _inventoryService.GetInventoryValue();
                            Console.WriteLine($"Total Inventory Value: {inventoryValue:C}");
                            break;

                        case 5:
                            // List Low Stock Products
                            Console.Write("Enter low stock threshold: ");
                            int threshold = int.Parse(Console.ReadLine());
                            List<Product> lowStockProducts = _inventoryService.ListLowStockProducts(threshold);
                            Console.WriteLine("Low Stock Products:");
                            foreach (var product in lowStockProducts)
                            {
                                Console.WriteLine($"- {product.ProductName} (Stock: {product.StockQuantity})");
                            }
                            break;

                        case 6:
                            // List Out of Stock Products
                            List<Product> outOfStockProducts = _inventoryService.ListOutOfStockProducts();
                            Console.WriteLine("Out of Stock Products:");
                            foreach (var product in outOfStockProducts)
                            {
                                Console.WriteLine($"- {product.ProductName}");
                            }
                            break;

                        case 7:
                            keepManaging = false; // Exit to main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
     