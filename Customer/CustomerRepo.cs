using Shop_Management_System.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Customer
{
    internal class CustomerRepo
    {
        private readonly string _filePath = "E:\\C#\\Shop Management System\\Customer\\customers.txt";

        public CustomerRepo() { }

        public void SaveInFile(CustomerModel customer)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(customer.ToString());
            }
        }

        public void SaveAllDataIntoFile(List<CustomerModel> customers)
        {
            File.WriteAllText(_filePath, string.Empty);
            foreach (CustomerModel c in customers)
            {
                SaveInFile(c);   //Call upper function to reuse
            }
        }

        public List<CustomerModel> GetAllCustomersFromFile()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string customerName = parts[0];
                    string customerPhoneNo = parts[1];
                    int customerAge = int.Parse(parts[2]);
                    string customerAddress = parts[3];

                    CustomerModel newCustomer = new CustomerModel(customerName, customerPhoneNo, customerAge, customerAddress);

                    customerList.Add(newCustomer);
                }
            }
            return customerList;
        }
    }
}
