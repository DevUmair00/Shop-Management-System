using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Customer
{
    internal class CustomerModel
    {
        public int ID { get; set; }
        public string Name {  get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address {  get; set; }

        public CustomerModel() { }

        public CustomerModel(string name, string phoneNumber, int age, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Age = age;
            Address = address;
        }

        public CustomerModel(int id , string name, string phoneNumber, int age, string address)
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Age = age;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Name},{PhoneNumber},{Age},{Address}";
        }
    }
}
