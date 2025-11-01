using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Order
{
    internal class OrderRepo
    {
        OrderItem orderItem = new OrderItem();

        private readonly string _fileName = "E:\\C#\\Shop Management System\\Order\\orders.txt";

        public void SaveOne(OrderModel Order)
        {
            using (StreamWriter writer = new StreamWriter(_fileName, true))
            {
                string customerData = $"Customer,{Order.CustomerName},{Order.Contact},{Order.Address}";
                writer.WriteLine(customerData);

                foreach(OrderItem items in Order.orderList)
                {
                    string line = $"Item,{items.Product},{items.Quantity},{items.SalePrice},{items.Quantity + items.SalePrice}";
                    writer.WriteLine(line);
                }
            }
        }

        public void SaveAll(List<OrderModel> orders)
        {
            using (StreamWriter writer = new StreamWriter(_fileName, true))
            {
                foreach (var order in orders)
                {
                   SaveOne(order); 
                }
            }
        }

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (StreamReader reader = new StreamReader(_fileName)) 
            {
                string line = "";
                while((line = reader.ReadLine())!= null)
                {
                    OrderModel customerObject = null;

                    if (line.StartsWith("Customer"))
                    {
                        string[] parts = line.Split(',');
                        string name = parts[1];
                        string contact = parts[2];
                        string address = parts[3];

                        customerObject = new OrderModel(name,contact,address);
                        orders.Add(customerObject);
                    }
                    else if (line.StartsWith("Item"))
                    {
                        string[] parts = line.Split(',');
                        string product = parts[1];
                        int quantity = int.Parse(parts[2]);
                        float salePrice = float.Parse(parts[3]);

                        OrderItem obj = new OrderItem(product,quantity,salePrice);
                        customerObject.AddOrder(obj);
                    }
                }
            }

            return orders;
        }
    }
}
 