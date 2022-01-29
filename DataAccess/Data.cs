using MySqlConnector;
using Marketplace_v4.Models;

namespace Marketplace_v4.DataAccess
{
    public class Data
    {

        public Data() { }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["Default"];
        public List<Product> GetProducts()
        {

            
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Product> Products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);
                Products.Add(p);
            }
            connection.Close();
            return Products;

        }

        public Product GetProduct(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM products WHERE productId = @ID";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            
            Product product = null;
            try {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                product = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);
                connection.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }


            return product;

        }

        public Product Update(int id, Product product)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = "UPDATE `igs`.`products` SET `Name` = @Name, `Price` = @Price WHERE (`productId` = @ID)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
       
            Product updatdedProduct = null;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                updatdedProduct = GetProduct(id);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return updatdedProduct;
        }

        public void Delete(int id) {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "DELETE FROM products WHERE productId = @ID";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            try {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public int AddProduct(Product product) {

            return 4;
        }



    }
}
