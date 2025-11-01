using Shop_Management_System.Product;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Customer
{
    internal class CustomerRepo
    {
        private readonly string DBConnectionString = "Server=localhost;Database=ShopManagementDB;Trusted_Connection=true;";


        // Customer Repo Table;;;
        //CustomerTable
        //  Customer_Name | PhoneNumber |  Age  |  Address

        //  @name     @number     @age         @address 

        public bool Create(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                connection.Open();

                string CreateQuery = "INSERT INTO CustomerTable " +
                    "(Customer_Name , PhoneNumber , Age , Address)" +
                    "VALUES(@name , @phoneNo , @age , @address)";

                SqlCommand cmd = new SqlCommand(CreateQuery, connection);

                cmd.Parameters.AddWithValue("@name",customer.Name);
                cmd.Parameters.AddWithValue("@phoneNo", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@age", customer.Age);
                cmd.Parameters.AddWithValue("@address", customer.Address);

                int RowAffected = cmd. ExecuteNonQuery();

                if (RowAffected > 0) return true;

                return false;
            }
        }

        public bool Delete(string name)
        {
            using(SqlConnection connection = new SqlConnection(DBConnectionString))
            {
                connection.Open();

                string DeleteQuery = "DELETE FROM CustomerTable WHERE Customer_Name = @name";

                SqlCommand cmd = new SqlCommand(DeleteQuery, connection);

                cmd.Parameters.AddWithValue("@name", name);

                int RowAffected = cmd.ExecuteNonQuery();

                if (RowAffected > 0) return true;

                return false;
            }
        }


        public bool Update(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string UpdateQuery = "UPDATE CustomerTable " +
                                        "SET " +
                                        "Customer_Name = @name , " +
                                        "PhoneNumber = @number , " +
                                        "Age = @age " +
                                        "Address = @address" +
                                      "WHERE Customer_Name = @name";


                SqlCommand cmd = new SqlCommand (UpdateQuery, connection);

                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@number", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@age", customer.Age);
                cmd.Parameters.AddWithValue("@address", customer.Address);

                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)return true;

                return false;
            }
        }


        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> Customers = new List<CustomerModel>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string GetAllQuery = "SELECT " +
                    "Customer_Name, PhoneNumber, Age, Address" +
                    "FROM CustomerTable";

                SqlCommand cmd = new SqlCommand (GetAllQuery, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string Name = reader["Customer_Name"].ToString();
                    string PhoneNO = reader["PhoneNumber"].ToString();
                    int Age = Convert.ToInt32(reader["Age"]);
                    string Address = reader["Address"].ToString();

                    CustomerModel customer = new CustomerModel(Name, PhoneNO, Age, Address);
                    Customers.Add(customer);
                }
            }
            return Customers;
        }



        public CustomerModel SearchCustomerByName(string name)
        {
            CustomerModel customer = null;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string GetAllQuery = "SELECT " +
                    "Customer_Name, PhoneNumber, Age, Address" +
                    "FROM CustomerTable WHERE Customer_Name = @name";

                SqlCommand cmd = new SqlCommand(GetAllQuery, connection);

                cmd.Parameters.AddWithValue("@name" , customer.Name);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string Name = reader["Customer_Name"].ToString();
                    string PhoneNO = reader["PhoneNumber"].ToString();
                    int Age = Convert.ToInt32(reader["Age"]);
                    string Address = reader["Address"].ToString();

                    customer = new CustomerModel(Name, PhoneNO, Age, Address);
                }
            }
            return customer;
        }

    }
}
