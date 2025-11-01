using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_Management_System.Product;
using Shop_Management_System.Customer;
using Shop_Management_System.Order;

namespace Shop_Management_System
{
    internal class Shop
    {
        ProductUI productUI = new ProductUI();
        CustomerUI customerUI = new CustomerUI();
        OrderUI orderUI = new OrderUI();
        public void Start() {

            while (true)
            {
                Console.Clear();   
                string option = MainMenu();

                if (option != null)
                {
                    if (option == "1")
                    {
                        productUI.ProductDriver();
                    }
                    else if (option == "2")
                    {
                        customerUI.CustomerDriver();
                    }
                    else if (option == "3")
                    {
                        orderUI.OrderDriver();
                    }
                    else if (option == "4") { break; }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid Choice....");
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear() ;
                    }
                }
            }
        }

        public string MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Shop Management System   ");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 Product Management ");
            Console.WriteLine("2 Customer Management");
            Console.WriteLine("3 Order Management");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4 Exit");
            Console.ResetColor();
            Console.Write("Enter your Choice... ");
            string option = Console.ReadLine();
            return option;
        }

    }
}
