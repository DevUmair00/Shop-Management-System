using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Order
{
    internal class OrderItem
    {
        public string Product;
        public int Quantity;
        public float SalePrice;

        public OrderItem() { }

        public OrderItem(string Product , int Quantity , float SalePrice)
        {
            this.Product = Product;
            this.Quantity = Quantity;
            this.SalePrice = SalePrice;
        }

        public override string ToString()
        {
            return $"{Product}, {Quantity}, {SalePrice}";
        }
    }
}
