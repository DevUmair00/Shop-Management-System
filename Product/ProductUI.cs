using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Product
{
    internal class ProductUI
    {
        ProductService productService = new ProductService();

        public ProductUI() { }
        public void ProductDriver()
        {
            while (true)
            {
                Console.Clear();
                Console.ResetColor();
                string option = ProductMenu();
                if (option == "1") { ProductInput(); }
                else if (option == "2") { UpdateProduct(); }
                else if (option == "3") { DeleteProduct(); }
                else if (option == "4") { DisplayAllProduct(); }
                else if (option == "5") { AdvanceSearchDriver(); }
                else if (option == "6") { break; }
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
        public string ProductMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Product Management       ");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 Add Product ");
            Console.WriteLine("2 Update Product");
            Console.WriteLine("3 Delete Product");
            Console.WriteLine("4 View All Product ");
            Console.WriteLine("5 Advance Search");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6 Back");
            Console.ResetColor();
            Console.Write("Enter your Choice... ");
            string option = Console.ReadLine();
            return option;
        }

        public void AdvanceSearchDriver()
        {
            while (true)
            {
                string advanceSearchOption = AdvanceSearchMenu();

                if (advanceSearchOption == "1") { SearchProductByname(); }
                else if (advanceSearchOption == "2") { SearchProductByPrice(); }
                else if (advanceSearchOption == "3") { DisplayProductsInRange(); }
                else if (advanceSearchOption == "4") { DisplayProductsByPriceDifference(); }
                else if (advanceSearchOption == "5") { FindProductBySubstring(); }
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
            Console.WriteLine("1 Search Product By Name ");
            Console.WriteLine("2 Search All product by Price");
            Console.WriteLine("3 Display Product Between Price Range");
            Console.WriteLine("4 Display Product By Price Difference ");
            Console.WriteLine("5 Find Product By Substring");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6 Back");
            Console.ResetColor();
            Console.Write("Enter your Choice... ");
            string option = Console.ReadLine();
            return option;
        }

        public void ProductInput()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter product name : ");
            string name = Console.ReadLine();
            Console.Write("Enter product description : ");
            string description = Console.ReadLine();


            Console.Write("Enter purchase price: ");
            float productPrice;
            while (!float.TryParse(Console.ReadLine(), out productPrice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter purchase price again: ");
            }

            Console.Write("Enter sale price: ");
            float salePrice;
            while (!float.TryParse(Console.ReadLine(), out salePrice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input..... ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter sale price again: ");
            }

            Console.Write("Enter discount: ");
            float discount;
            while (!float.TryParse(Console.ReadLine(), out discount))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter discount again: ");
            }

            //int id = AssignId();

            ProductModel product = new ProductModel(name, description, productPrice, salePrice, discount);

            if (productService.SaveProduct(product))
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product Added Successfully....");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        //public int AssignId()
        //{
        //    int id = 0;
        //    List<ProductModel> productsList = productService.GetAllData();
        //    foreach (ProductModel product in productsList)
        //    {
        //        id++;
        //    }
        //    return id;
        //}

        public void DisplayProduct(ProductModel product)
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Name : " + product.Name);
            Console.WriteLine("Description : " + product.Description);
            Console.WriteLine("Price : " + product.Sale_price);
            Console.WriteLine("------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void UpdateProduct()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Product Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            float Price;
            while (!float.TryParse(Console.ReadLine(), out Price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input..... ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter Price again: ");
            }

            if (productService.UpdateProduct(name, Price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product Updated Successfully....");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product Not Found....");
            return;
        }

        public void DeleteProduct()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Product Name : ");
            string name = Console.ReadLine();

            if (productService.DeleteProduct(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product Deleted Successfully....");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Product Found....");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void DisplayAllProduct()
        {
            Console.Clear();
            List<ProductModel> productList = productService.GetAllData();
            if (productList != null)
            {
                foreach (ProductModel product in productList)
                {
                    Console.WriteLine(product.ToString());
                }
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No any Product Found....");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        public void SearchProductByname()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Product Name : ");
            string name = Console.ReadLine();

            List<ProductModel> filteredList = productService.SearchProductsByName(name);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Products....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (ProductModel product in filteredList)
                {
                    Console.WriteLine(product.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Product Found....");
            Console.ReadKey();
            return;

        }

        public void SearchProductByPrice()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Product Price : ");
            float price = float.Parse(Console.ReadLine());

            List<ProductModel> filteredList = productService.SearchProductByPrice(price);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Products....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (ProductModel product in filteredList)
                {
                    Console.WriteLine(product.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Product Found With Given Price....");
            Console.ReadKey();
            return;

        }


        public void DisplayProductsInRange()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Product Price in \nRange From : ");
            float startPrice = float.Parse(Console.ReadLine());
            Console.Write("Range to : ");
            float endPrice = float.Parse(Console.ReadLine());

            List<ProductModel> filteredList = productService.SearchProductByPriceInRange(startPrice , endPrice);

            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filtered Products....");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (ProductModel product in filteredList)
                {
                    Console.WriteLine(product.ToString());
                }
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Product Found in Given Price....");
            Console.ReadKey();
            return;
        }

        public void DisplayProductsByPriceDifference()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Differnce Price : ");
            float differPrice = float.Parse(Console.ReadLine());

            List<ProductModel> filteredList = productService.DisplayProductsByPriceDifference(differPrice);

            if (filteredList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Product Found in Given Price....");
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Filtered Products....");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (ProductModel product in filteredList)
            {
                Console.WriteLine(product.ToString());
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        public void FindProductBySubstring()
        {
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Substring to search Product : ");
            string substring = Console.ReadLine();
            List<ProductModel> filteredList = productService.SearchProductsBySubstring(substring);
            if (filteredList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Product Found With Given Substring....");
                Console.ReadKey();
                return;

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Filtered Products....");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (ProductModel product in filteredList)
            {
                Console.WriteLine(product.ToString());
            }
            Console.ResetColor();
            Console.ReadKey();
            return;
        }
    }
}
