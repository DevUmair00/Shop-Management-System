using Shop_Management_System.Customer;
using Shop_Management_System.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Customer
{
    internal class CustomerUI
    {
        CustomerService customerService = new CustomerService();

        public CustomerUI() { }

        public void CustomerDriver()
        {
            while (true)
            {   
                Console.Clear();
                Console.ResetColor();
                string option = CustomerMenu();
                if (option == "1") { CustomerInput(); }
                else if (option == "2") { UpdateCustomer(); }
                else if (option == "3") { DeleteCustomer(); }
                else if (option == "4") { SearchCustomer(); }
                else if (option == "5") { ViewAllCustomer(); }
                else if (option == "6") { AdvanceSearchDriver(); }
                else if (option == "7") { break; }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid Choice...  ");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public string CustomerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.WriteLine("      Customer Management     ");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Add Customer");
            Console.WriteLine("2- Update Customer");
            Console.WriteLine("3- Delete Customer");
            Console.WriteLine("4- search Customer");
            Console.WriteLine("5- View all Customer");
            Console.WriteLine("6- Advance Search");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("7- Back");
            Console.ResetColor();
            Console.Write("Enter your Choice... ");
            string choice = Console.ReadLine();
            return choice;
        }


        public void AdvanceSearchDriver()
        {
            while (true)
            {
                string advanceSearchOption = AdvanceSearchMenu();

                if (advanceSearchOption == "1") { SearchCustomerByname(); }
                else if (advanceSearchOption == "2") { DisplayCustomerByFirstCharacter(); }
                else if (advanceSearchOption == "3") { DisplayCustomerPhoneNumber(); }
                else if (advanceSearchOption == "4") { DisplayCustomerByAddress(); }
                else if (advanceSearchOption == "5") { DisplayCustomerByAge(); }
                else if (advanceSearchOption == "6") break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid Choice...  ");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            return;
        }

        public string AdvanceSearchMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Advance Search Menu      ");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 Search Customer By Name ");
            Console.WriteLine("2 Search Customer By First Character ");
            Console.WriteLine("3 Search Customer by Phone Number ");
            Console.WriteLine("4 Search Customer by Address ");
            Console.WriteLine("5 Search Customer by Age ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6 Back");
            Console.ResetColor();
            Console.Write("Enter your Choice... ");
            string option = Console.ReadLine();
            return option;
        }

        public void DisplayCustomer(CustomerModel customer)
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Name : " + customer.Name);
            Console.WriteLine("Phone Number : " + customer.PhoneNumber);
            Console.WriteLine("Age : " + customer.Age);
            Console.WriteLine("Address : " + customer.Address);
            Console.WriteLine("------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void CustomerInput()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Customer name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone.NO : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Address : ");
            string address = Console.ReadLine();

            CustomerModel customer = new CustomerModel(name, phoneNumber, age, address);

            customerService.SaveCustomer(customer);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Customer Added Successfully....");
            Console.ReadKey();
            Console.ResetColor();
        }

        public void UpdateCustomer()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Customer Name : ");
            string name = Console.ReadLine();

            CustomerModel matchedCustomer = customerService.SearchCustomerByName(name);

            if (matchedCustomer != null)
            {
                Console.Write("\nEnter customer new name : ");
                string newname = Console.ReadLine();
                Console.Write("Enter customer contact : ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Enter age  : ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter customer address : ");
                string address = Console.ReadLine();

                if (customerService.UpdateCustomer(name , newname, phoneNumber, age, address))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer updated successfully");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Customer not found");
            }
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Customer Name : ");
            string name = Console.ReadLine();

            CustomerModel matchedCustomer = customerService.SearchCustomerByName(name);

            if (matchedCustomer != null)
            {
                if (customerService.DeleteCustomer(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer Deleted Successfully....");
                    Console.ReadKey();
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Customer Not Found....");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void SearchCustomer()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Customer Name : ");
            string name = Console.ReadLine();

            CustomerModel matchedCustomer = customerService.SearchCustomerByName(name);

            if (matchedCustomer != null)
            {
                Console.Clear();
                Console.WriteLine(matchedCustomer.ToString());
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Customer Not Found....");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        public void ViewAllCustomer()
        {
            List<CustomerModel> customers = customerService.GetAllCustomer();

            if (customers != null)
            {
                Console.Clear();
                foreach (CustomerModel customer in customers)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.ReadKey();
                return ;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No any Customer Found....");
            Console.ResetColor();
            Console.ReadKey();
            return;

        }
    
        public void SearchCustomerByname()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Customer Name : ");
            string name = Console.ReadLine();

            List<CustomerModel> filteredList = customerService.searchCustomersByname(name);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Customer....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (CustomerModel customer in filteredList)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Customers Found....");
            Console.ReadKey();
            return;
        }

        public void DisplayCustomerByFirstCharacter()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter 1st Character of Name : ");
            string name = Console.ReadLine();

            List<CustomerModel> filteredList = customerService.searchCustomersByFirstCharacter(name);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Customer....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (CustomerModel customer in filteredList)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Customers Found....");
            Console.ReadKey();
            return;
        }

        public void DisplayCustomerPhoneNumber()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Phone Number : ");
            string number = Console.ReadLine();

            List<CustomerModel> filteredList = customerService.searchCustomerByPhoneNumber(number);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Customer....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (CustomerModel customer in filteredList)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Customers Found....");
            Console.ReadKey();
            return;
        }

        public void DisplayCustomerByAddress()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Address of Customer : ");
            string address = Console.ReadLine();

            List<CustomerModel> filteredList = customerService.searchCustomersByAddress(address);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Customer....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (CustomerModel customer in filteredList)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Customers Found....");
            Console.ReadKey();
            return;
        }

        public void DisplayCustomerByAge()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Age of Customer : ");
            float age = float.Parse(Console.ReadLine());

            List<CustomerModel> filteredList = customerService.searchCustomersByAge(age);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Customer....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (CustomerModel customer in filteredList)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Customers Found....");
            Console.ReadKey();
            return;
        }

    }
}
