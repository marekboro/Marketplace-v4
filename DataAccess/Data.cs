using MySqlConnector;
using Marketplace_v4.Models;

namespace Marketplace_v4.DataAccess
{
    public class Data
    {
        public List<Product> GetProducts()
        {

            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; user=root; password=root; database=igs");
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
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; user=root; password=root; database=igs");
            connection.Open();
            string query = "SELECT * FROM products WHERE productId = @ID";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@ID", MySqlDbType.Int32);
            command.Parameters["@ID"].Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Product p = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);
            connection.Close();
            return p;

        }

    }
}
