using Shop_Management_System.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Order
{
    internal class OrderService
    {
        public OrderRepo orderRepo = new OrderRepo();


        public void AddOrder(OrderModel newOrder)
        {
            orderRepo.SaveOne(newOrder);
        }

        public List<OrderModel> GetData()
        {
            return orderRepo.GetAllOrders();
        }

        public OrderModel SearchOrderByName(string name)
        {
            foreach (OrderModel o in GetData())
            {
                if (o.CustomerName == name)
                {
                    return o;
                }
            }
            return null;
        }

        public bool DeleteOrder(string name)
        {
            List<OrderModel> orders = orderRepo.GetAllOrders();
            int removeCount = 0;
            removeCount = orders.RemoveAll(o => o.CustomerName == name);

            if (removeCount > 0)
            {
                orderRepo.SaveAll(orders);
                return true;
            }
            return false;
        }
    }
}
