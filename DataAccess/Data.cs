using MySqlConnector;
using Marketplace_v4.Models;

namespace Marketplace_v4.DataAccess
{
    public class Data
    {

        //public Data() { }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["Default"];
        public List<Product> GetProducts()
        {


            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM products";
            var command = new MySqlCommand(query, connection);
            var reader = command.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                var p = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);
                products.Add(p);
            }
            connection.Close();
            return products;

        }

        public Product? GetProduct(int id)
        {
            var connection = new MySqlConnection(connectionString);
            var query = "SELECT * FROM products WHERE productId = @ID";
            var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            
            Product? product = null;
            try {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                product = new Product((int)reader["productId"], (string)reader["Name"], (string)reader["Price"]);
                connection.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return product;

        }

        //public Product? Update(int id, Product product)
        public Product Update(Product product)
        {

            //var exiting = _data.ge
            Product? updatedProduct = null;
            var connection = new MySqlConnection(connectionString);

            var query = "UPDATE `igs`.`products` SET `Name` = @Name, `Price` = @Price WHERE (`productId` = @ID)";
            var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            // command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = product.id;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
       
            
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
               // updatedProduct = GetProduct(id);
                updatedProduct = GetProduct(product.id);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return updatedProduct;
        }

        

        public void Delete(int id) {
            var connection = new MySqlConnection(connectionString);
            var query = "DELETE FROM products WHERE productId = @ID";
            var command = new MySqlCommand(query, connection);

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
            var toReturn = -1;
            var connection = new MySqlConnection(connectionString);
            var query = "INSERT INTO products (Name, Price) VALUES(@Name, @Price)";
            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name; ;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                toReturn = (int)command.LastInsertedId;
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return toReturn;
        }



    }
}
