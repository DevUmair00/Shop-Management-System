using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Product
{
    internal class ProductService
    {
        ProductRepo productRepo = new ProductRepo();
        public ProductService() { }

        public bool SaveProduct(ProductModel product)
        {

            bool result = productRepo.Create(product);
            return result;

        }

        public bool UpdateProduct(string name, float price)
        {
            List<ProductModel> products = productRepo.GetALL();

            if (products != null)
            {
                foreach (ProductModel p in products)
                {
                    if (p.Name == name)
                    {
                        p.Sale_price = price;
                        productRepo.Update(p);
                        return true;
                    }
                }
            }
            return false;
        }


        public bool DeleteProduct(string name)
        {
            List<ProductModel> products = productRepo.GetALL();

            bool del = false;
            foreach (ProductModel p in products)
            {
                if (p.Name == name)
                {
                    del = productRepo.Delete(p.Name);
                }
            }

            return del;
        }


        public List<ProductModel> GetAllData()
        {
            return productRepo.GetALL();
        }

        public ProductModel SearchProductByName(string Name)
        {
            return productRepo.GetProductByName(Name);
        }


        public List<ProductModel> SearchProductsByName(string name)
        {
            List<ProductModel> GetAllProducts = productRepo.GetALL();

            List<ProductModel> FilterProducts = new List<ProductModel>();

            foreach (ProductModel product in GetAllProducts)
            {
                if (product.Name == name)
                {
                    FilterProducts.Add(product);
                }
            }
            return FilterProducts;
        }


        public List<ProductModel> SearchProductByPrice(float price)
        {
            List<ProductModel> GetAllProducts = productRepo.GetALL();
            List<ProductModel> FilterProducts = new List<ProductModel>();

            foreach (ProductModel product in GetAllProducts)
            {
                if (product.Sale_price == price)
                {
                    FilterProducts.Add(product);
                }
            }
            return FilterProducts;
        }

        public List<ProductModel> SearchProductByPriceInRange(float startPrice, float endPrice)
        {
            List<ProductModel> GetAllProducts = productRepo.GetALL();
            List<ProductModel> FilterProducts = new List<ProductModel>();

            foreach (ProductModel product in GetAllProducts)
            {
                if (product.Sale_price >= startPrice && product.Sale_price <= endPrice)
                {
                    FilterProducts.Add(product);
                }
            }

            return FilterProducts;
        }

        public List<ProductModel> DisplayProductsByPriceDifference(float differencePrice)
        {
            List<ProductModel> GetAllProducts = productRepo.GetALL();
            List<ProductModel> FilterProducts = new List<ProductModel>();

            foreach (ProductModel product in GetAllProducts)
            {
                if (Math.Abs(product.Sale_price - product.Purchase_price) == differencePrice)
                {
                    FilterProducts.Add(product);
                }
            }

            return FilterProducts;
        }

        public List<ProductModel> SearchProductsBySubstring(string substring)
        {
            List<ProductModel> GetAllProducts = productRepo.GetALL();
            List<ProductModel> FilterProducts = new List<ProductModel>();

            foreach (ProductModel product in GetAllProducts)
            {
                if (substring != null && product.Name.ToLower().Contains(substring.ToLower()))
                {
                    FilterProducts.Add(product);
                }
            }
            return FilterProducts;
        }

    }
}