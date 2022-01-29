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
            // connection.Open();
            string query = "SELECT * FROM products WHERE productId = @ID";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
          //  command.Parameters["@ID"].Value = id;

           // MySqlDataReader reader = command.ExecuteReader();
           // reader.Read();
           // Product p = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);
            connection.Close();
            Product product = null;
            try {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                product = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);

            }
            catch (Exception e) { Console.WriteLine(e.Message); }


            return product;

        }

        public Product Update(int id, Product product)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; user=root; password=root; database=igs");
            // connection.Open();
            string query = "UPDATE `igs`.`products` SET `Name` = @Name, `Price` = @Price WHERE (`productId` = @ID)";
            // string query2 = "SELECT * FROM products WHERE productId = @ID";
            MySqlCommand command = new MySqlCommand(query, connection);


            command.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
           // command.Parameters["@Price"].Value = product.Price;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            // command.Parameters["@ID"].Value = id;

            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
           // command.Parameters["@Name"].Value = product.Name;

            //  command.ExecuteNonQuery();
            //   connection.Close();
            //Product updatdedProduct = GetProduct(id);
            Product updatdedProduct = null;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                updatdedProduct = GetProduct(id);

                //MySqlCommand command = new MySqlCommand(query2, connection);
                //command2.Parameters.Add("@ID", MySqlDbType.Int32);
                //command2.Parameters["@ID"].Value = id;
                //MySqlDataReader reader = command.ExecuteReader();
                //updadedP = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);


            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return updatdedProduct;
        }



    }
}
