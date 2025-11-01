using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Order
{
    internal class OrderModel
    {
        public string CustomerName;
        public string Contact;
        public string Address;
        public List<OrderItem> orderList = new List<OrderItem>();

        public OrderModel() { }

        public OrderModel(string CustomerName, string Contact, string Address)
        {
            this.CustomerName = CustomerName;
            this.Contact = Contact;
            this.Address = Address;
        }

        public void AddOrder(OrderItem item)
        {
            orderList.Add(item);
        }

        public override string ToString()
        {
            return $"{CustomerName},{Contact},{Address}";
        }

    }
}
