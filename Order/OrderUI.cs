using System;
using System.Collections.Generic;
using Shop_Management_System.Customer;
using Shop_Management_System.Product;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop_Management_System.Order
{
    internal class OrderUI
    {
        OrderService orderService = new OrderService();
        CustomerService customerService = new CustomerService();
        ProductService productService = new ProductService();
        CustomerUI customerUI = new CustomerUI();
        ProductUI productUI = new ProductUI();

        public void OrderDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = OrderMenu();

                if (option == "1")
                {
                    OrderModel newOrder = TakeInput();

                    if (newOrder != null)
                    {
                        orderService.AddOrder(newOrder);
                    }
                }
                
                else if (option == "2")
                {
                    string choice = ViewOrderMenu();

                    if (choice == "1") { DisplayAll(); }

                    else if (choice == "2")
                    {
                        Console.Write("Enter Customer Name: ");
                        string customerName = Console.ReadLine();
                        DisplayOrderByCustomerName(customerName);
                    }

                    else if (choice == "3")
                    {
                        Console.Write("Enter Customer Name to Remove Orders: ");
                        string name = Console.ReadLine();
                        if (orderService.DeleteOrder(name))
                        {
                            Console.WriteLine("Order removed successfully..");
                        }
                    }
                    else if (choice == "4") { break; }

                    else
                    {
                        Console.WriteLine("Invalid option!");
                    }
                }
                
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        public string OrderMenu()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("              ORDER MANAGEMENT SYSTEM              ");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Order History");
            Console.WriteLine("3. EXIT");
            Console.Write("Choose an option: ");
            return Console.ReadLine();
        }
        public string ViewOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("                  Order History                    ");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. View Order By Customer Name");
            Console.WriteLine("3. Remove Orders By Customer Name");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        public OrderModel TakeInput()
        {
            OrderModel newOrder = new OrderModel();
            CustomerModel newCustomer = new CustomerModel();

            //------------------------------------ Handle customer------------------------------

            while (true) 
            {
                Console.Clear();
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                CustomerModel searchCustomer = customerService.SearchCustomerByName(name);

                if (searchCustomer != null)
                {
                    Console.WriteLine("\n-----------Customer Detail---------------");
                    customerUI.DisplayCustomer(searchCustomer);
                    newOrder = new OrderModel(searchCustomer.Name, searchCustomer.PhoneNumber, searchCustomer.Address);

                    Console.WriteLine("\n-----------Products Detail---------------");
                    int count = 1;
                    while (true)
                    {
                        //----------------------------------- Handle Customer---------------------------------------
                        Console.WriteLine("\n          Product " + count);
                        Console.Write("\nEnter Product Name: ");
                        string productName = Console.ReadLine();

                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.Write("Enter Sale Price: ");
                        float salePrice = float.Parse(Console.ReadLine());

                        OrderItem item = new OrderItem(productName, quantity, salePrice);
                        newOrder.AddOrder(item);

                        //----------------------------------- Handle order items---------------------------------------

                        Console.Write("Add another item? (y/n): ");
                        count++;
                        if (Console.ReadLine().ToLower() != "y") return newOrder;
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                    Console.WriteLine("\nPress any key to Add Customer First...");
                    Console.ReadKey();

                    customerUI.CustomerInput();
                }
            }
            
        }
        public void DisplayAll()
        {
            List<OrderModel> orders = orderService.GetData();

            if(orders != null)
            {
                foreach (OrderModel model in orders)
                {
                    DisplayOrder(model);
                }
                Console.WriteLine("----------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No any Order Available....");
                Console.ReadKey();
            }
        }
        public void DisplayOrderByCustomerName(string customerName)
        {
            OrderModel model = orderService.SearchOrderByName(customerName);
            if(model == null)
            {
                Console.WriteLine("No order found for the given customer name.");
                Console.ReadKey();
                return;
            }
            DisplayOrder(model);
        }
        public void DisplayOrder(OrderModel order)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------");
            Console.ResetColor();
            if (order != null)
            {
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine($"Customer Phone Number: {order.Contact}");
                Console.WriteLine($"Customer Address: {order.Address}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------");
                Console.ReadKey();
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No any Order Available....");
                Console.ReadKey();
            }


            if (order.orderList.Count < 1)
            {
                Console.WriteLine("No items found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Items Purchased:");

            foreach (var item in order.orderList)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("----------------------------------");
                Console.ResetColor();
                Console.WriteLine($"Product Name: {item.Product}");
                Console.WriteLine($"Product Quantity: {item.Quantity}");
                Console.WriteLine($"Product Price: {item.SalePrice}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Console.ResetColor();
        }

    }

}


