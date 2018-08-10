using System;
using System.Collections.Generic;
using System.Text;

namespace InClassCrudOperations
{
    class Product_Repository
    {
    public class ProductRepository
    {
        public string ConnectionString { get; set; }

        public ProductRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // Create
        public void Insert(Product product)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO products (Name, Price) " +
                                  "VALUES (@name, @price);";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);

                cmd.ExecuteNonQuery();
            }
        }

        // Read
        public List<Product> Select()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ProductID, Name, Price " +
                                  "FROM products;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Product> products = new List<Product>();

                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(dataReader["ProductID"]);
                    product.Name = dataReader["Name"].ToString();
                    product.Price = Convert.ToDecimal(dataReader["Price"]);

                    products.Add(product);
                }

                return products;
            }
        }

        // Update
        public void Update(Product product)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE products " +
                                  "SET Name = @name, Price = @price " +
                                  "WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("id", product.Id);

                cmd.ExecuteNonQuery();
            }
        }

        // Delete
        public void Delete(Product product)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM products " +
                                  "WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", product.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
}
}
