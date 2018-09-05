using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace InClassCrud_Operations
{
    class Repository
    {
        public Repository (string connection )
        {
            connectionstring = connection;  
        }
        string connectionstring;
        // Read
        public void AddNewCategory(string Category)
        {
            string connString = connectionstring;

            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO categories (Name) VALUES (@newCategory)";
                cmd.Parameters.AddWithValue("newCategory", Category);

                cmd.ExecuteNonQuery();
            }
        }

        // Update
        public List<string> GetProductsNameInPriceRange(int maxPrice)
        {
            string connString = connectionstring;

            MySqlConnection conn = new MySqlConnection(connString);

            using (conn) 
            {

                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                MySqlDataReader dr = cmd.ExecuteReader();

                List<string> productNames = new List<string>();

                while (dr.Read())
                {
                    productNames.Add(dr["Name"].ToString());
                }
                return productNames;

            }
        }
        public void PriceChange(int Price)
        {
            string connString = connectionstring;

            MySqlConnection conn = new MySqlConnection(connString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Samsung Galaxy From products SET Price =@newPrice";
                cmd.Parameters.AddWithValue("newPrice", Price);

                cmd.ExecuteNonQuery();
            }
        }


        // Delete
        public void DeleteProduct(string productToDelete)
        {

            string connString = connectionstring;

            MySqlConnection conn = new MySqlConnection(connString);


            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM products WHERE Name LIKE '%productToDelete";

                cmd.Parameters.AddWithValue("productToDelete", productToDelete);

                cmd.ExecuteNonQuery();
            }

        }
    }
}



            
