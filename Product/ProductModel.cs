using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop_Management_System.Product
{
    internal class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Purchase_price { get; set; }
        public float Sale_price { get; set; }
        public float Discount {  get; set; }

        ProductModel() { }

        public ProductModel(string name, string description, float purchase_price, float sale_price, float discount)
        {
            Name = name;
            Description = description;
            Purchase_price = purchase_price;
            Sale_price = sale_price;
            Discount = discount;
        }

        public ProductModel(int id , string name, string description, float purchase_price, float sale_price, float discount)
        {
            ID = id;
            Name = name;
            Description = description;
            Purchase_price = purchase_price;
            Sale_price = sale_price;
            Discount = discount;
        }

        public override string ToString()
        {
            return $"{Name},{Description},{Purchase_price},{Sale_price},{Discount}";
        }
    }
}
