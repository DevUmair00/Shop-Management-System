
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop_Management_System.Customer
{
    internal class CustomerService
    {
        CustomerRepo customerRepo = new CustomerRepo();

        public CustomerService() { }

        public void SaveCustomer(CustomerModel customer)
        {
            customerRepo.SaveInFile(customer);
        }

        public CustomerModel SearchCustomerByName(string name)
        {
            foreach(CustomerModel c in customerRepo.GetAllCustomersFromFile())
            {
                if(c.Name == name)
                {
                    return c;
                }
            }
            return null;
        }

        public bool UpdateCustomer(string name, string newName , string phoneNumber, int age, string address)
        {
            List<CustomerModel> customers = customerRepo.GetAllCustomersFromFile();
            foreach (var customer in customers)
            {
                if (customer.Name == name)
                {
                    customer.Name = newName;
                    customer.PhoneNumber = phoneNumber;
                    customer.Age = age;
                    customer.Address = address;
                    customerRepo.SaveAllDataIntoFile(customers);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCustomer(string name)
        { 
            List<CustomerModel> customers = customerRepo.GetAllCustomersFromFile() ;

            int count = 0;
            count = customers.RemoveAll(c => c.Name == name);

            if (count > 0)
            {
                customerRepo.SaveAllDataIntoFile(customers);
                return true;
            }
            return false;
        }

        public List<CustomerModel> GetAllCustomer()
        {
            return customerRepo.GetAllCustomersFromFile();
        }
        
        public List<CustomerModel> searchCustomersByname(string customerName)
        {
            List <CustomerModel> GetAllCustomers = customerRepo.GetAllCustomersFromFile();
            List <CustomerModel> FilterCustomer = new List<CustomerModel>();

            foreach (var customer in GetAllCustomers)
            { 
                if(customer.Name == customerName)
                {
                    FilterCustomer.Add(customer);
                }
            }
            return FilterCustomer;
        }

        public List<CustomerModel> searchCustomersByFirstCharacter(string character)
        {
            List<CustomerModel> GetAllCustomers = customerRepo.GetAllCustomersFromFile();
            List<CustomerModel> FilterCustomer = new List<CustomerModel>();

            foreach (var customer in GetAllCustomers)
            {
                string name = customer.Name;


                if (name.Substring(0, 1) == character)
                {
                    FilterCustomer.Add(customer);
                }
            }
            return FilterCustomer;
        }

        public List<CustomerModel> searchCustomerByPhoneNumber(string number)
        {
            List<CustomerModel> GetAllCustomers = customerRepo.GetAllCustomersFromFile();
            List<CustomerModel> FilterCustomer = new List<CustomerModel>();

            foreach (var customer in GetAllCustomers)
            {
                if (customer.PhoneNumber == number)
                {
                    FilterCustomer.Add(customer);
                }
            }
            return FilterCustomer;
        }

        public List<CustomerModel> searchCustomersByAddress(string address)
        {
            List<CustomerModel> GetAllCustomers = customerRepo.GetAllCustomersFromFile();
            List<CustomerModel> FilterCustomer = new List<CustomerModel>();

            foreach (var customer in GetAllCustomers)
            {
                if (customer.Address == address)
                {
                    FilterCustomer.Add(customer);
                }
            }
            return FilterCustomer;
        }

        public List<CustomerModel> searchCustomersByAge(float age)
        {
            List<CustomerModel> GetAllCustomers = customerRepo.GetAllCustomersFromFile();
            List<CustomerModel> FilterCustomer = new List<CustomerModel>();

            foreach (var customer in GetAllCustomers)
            {
                if (customer.Age == age)
                {
                    FilterCustomer.Add(customer);
                }
            }
            return FilterCustomer;
        }

        

    }
}
