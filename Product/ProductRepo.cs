using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Product
{
    internal class ProductRepo
    {
        private readonly string DBConnectionString = "Server=localhost;Database=ShopManagementDB;Trusted_Connection=true;";

        // Product Repo Table;;;
        //               Id   |   Product_Name | Description |  Purchase_Price  |  Sale_Price   |  Discount
        //Placeholder    @id  |   @name          @des           @pPrice            @sPrice         @dis
        
        
        public bool Create(ProductModel product)
        {
            using (SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO ProductTable " +
                  "(Product_Name, Description, Purchase_Price, Sale_Price, Discount) " +
                  "VALUES (@name, @des, @pPrice, @sPrice, @dis)";

                SqlCommand cmd = new SqlCommand(insertQuery, connection);

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@des", product.Description);
                cmd.Parameters.AddWithValue("@pPrice", product.Purchase_price);
                cmd.Parameters.AddWithValue("@sPrice", product.Sale_price);
                cmd.Parameters.AddWithValue("@dis", product.Discount);

                int RowAffected = cmd.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public bool Delete(string name)
        { 
           using(SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM ProductTable Where Product_Name = @name";

                SqlCommand cmd = new SqlCommand(deleteQuery, connection);   

                cmd.Parameters.AddWithValue("@name", name);

                int RowAffected = cmd.ExecuteNonQuery();

                if(RowAffected > 0)
                {
                    return true;
                }
                else return false;
            }
        }


        public bool Update(ProductModel product)
        {
            using (SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE ProductTable " +
                                     "SET Product_Name = @name , Description = @des , Purchase_Price = @pPrice , Sale_Price = @sPrice , Discount = @discount " +
                                        "Where  Product_Name = @name ";

                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@des", product.Description);
                cmd.Parameters.AddWithValue("@pPrice", product.Purchase_price);
                cmd.Parameters.AddWithValue("@sPrice", product.Sale_price);
                cmd.Parameters.AddWithValue("@discount", product.Discount);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public List<ProductModel> GetALL() 
        {
            List<ProductModel> Products = new List<ProductModel>();
            
            using (SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                connection.Open();
                string GetAllQuery = "SELECT Product_Name , Description , Purchase_Price , Sale_Price , Discount FROM ProductTable";
                
                SqlCommand cmd = new SqlCommand(GetAllQuery, connection);
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                { 
                    string Name = reader["Product_Name"].ToString();
                    string Description = reader["Description"].ToString();
                    int Purchase_Price = Convert.ToInt32(reader["Purchase_Price"]);
                    int Sale_Price = Convert.ToInt32(reader["Sale_Price"]);
                    int Discount = Convert.ToInt32(reader["Discount"]);
                    ProductModel product = new ProductModel(Name , Description , Purchase_Price , Sale_Price , Discount);
                    Products.Add(product);
                }
                reader.Close();
            }
            return Products;
        }

        public ProductModel GetProductByName(string name)
        {
            ProductModel product = null;

            using (SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                String SearchProductQuery = "SELECT Product_Name , Description , Purchase_Price , Sale_Price , Discount  FROM  ProductTable  WHERE  Name = @name";

                SqlCommand cmd = new SqlCommand(SearchProductQuery, connection);

                cmd.Parameters.AddWithValue("@name", name);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //int ID = Convert.ToInt32(reader["ID"]);
                    string Name = reader["Product_Name"].ToString();
                    string Description = reader["Description"].ToString();
                    int Purchase_Price = Convert.ToInt32(reader["Purchase_Price"]);
                    int Sale_Price = Convert.ToInt32(reader["Sale_Price"]);
                    int Discount = Convert.ToInt32(reader["Discount"]);
                    product = new ProductModel(Name, Description, Purchase_Price, Sale_Price, Discount);
                }

                reader.Close();
            }
            return product;
        }
    }
}
