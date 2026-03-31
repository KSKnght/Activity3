using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace WindowsFormsApp1
{
    public class DatabaseHelper
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["ActivityDatabase"]?.ConnectionString;

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT id, name, price, imagepath FROM product";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetDecimal("price"),
                            ImagePath = reader.GetString("imagepath")
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading products: {ex.Message}");
            }

            return products;
        }

        public int AuthenticateUser(string username, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT id FROM user WHERE name = @username AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error authenticating user: {ex.Message}");
            }

            return 0;
        }

        public bool RegisterUser(string username, string password, string role = "cashier")
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO user (name, password, role) VALUES (@username, @password, @role)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error registering user: {ex.Message}");
                return false;
            }
        }

        public int CreateOrder(decimal totalAmount, decimal amountTendered, decimal change)
        {
            int orderId = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO `order` (total_amount, amount_tendered, `change`) VALUES (@totalAmount, @amountTendered, @change); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@amountTendered", amountTendered);
                    cmd.Parameters.AddWithValue("@change", change);

                    orderId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error creating order: {ex.Message}");
            }

            return orderId;
        }

        public bool CreateOrderItem(int orderId, int productId, string size, int qty, decimal basePrice)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO order_item (order_id, product_id, size, qty, base_price) VALUES (@orderId, @productId, @size, @qty, @basePrice)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@basePrice", basePrice);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error creating order item: {ex.Message}");
                return false;
            }
        }

        public Product GetProductByName(string name)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT id, name, price, imagepath FROM product WHERE name = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetDecimal("price"),
                            ImagePath = reader.GetString("imagepath")
                        };
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error retrieving product: {ex.Message}");
            }

            return null;
        }

        public bool SaveCompleteTransaction(Order order, int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // Create order with added_by user id
                    string orderQuery = "INSERT INTO `order` (total_amount, amount_tendered, `change`, added_by) VALUES (@totalAmount, @amountTendered, @change, @addedBy); SELECT LAST_INSERT_ID();";
                    MySqlCommand orderCmd = new MySqlCommand(orderQuery, conn);
                    orderCmd.Parameters.AddWithValue("@totalAmount", order.TotalAmount);
                    orderCmd.Parameters.AddWithValue("@amountTendered", order.AmountTendered);
                    orderCmd.Parameters.AddWithValue("@change", order.Change);
                    orderCmd.Parameters.AddWithValue("@addedBy", userId);

                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());
                    order.Id = orderId;

                    // Create order items with base_price
                    foreach (var item in order.OrderItems)
                    {
                        string itemQuery = "INSERT INTO order_item (order_id, product_id, size, qty, base_price) VALUES (@orderId, @productId, @size, @qty, @basePrice)";
                        MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn);
                        itemCmd.Parameters.AddWithValue("@orderId", orderId);
                        itemCmd.Parameters.AddWithValue("@productId", item.ProductId);
                        itemCmd.Parameters.AddWithValue("@size", item.Size);
                        itemCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@basePrice", item.UnitPrice);

                        itemCmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error saving transaction: {ex.Message}");
                return false;
            }
        }

        public bool AddProduct(string name, decimal price, string imagePath)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO product (name, price, imagepath) VALUES (@name, @price, @imagepath)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@imagepath", imagePath);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error adding product: {ex.Message}");
                return false;
            }
        }

        public string GetUserRole(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT role FROM user WHERE id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "cashier";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error getting user role: {ex.Message}");
                return "cashier";
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT id, name, role FROM user";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Role = reader.GetString("role")
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading users: {ex.Message}");
            }

            return users;
        }

        public bool UpdateUser(int userId, string name, string role)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "UPDATE user SET name = @name, role = @role WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@role", role);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM user WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        public List<Product> GetAllProductsForAdmin()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT id, name, price, imagepath FROM product";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetDecimal("price"),
                            ImagePath = reader.GetString("imagepath")
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading products: {ex.Message}");
            }

            return products;
        }

        public bool UpdateProduct(int productId, string name, decimal price, string imagePath)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "UPDATE product SET name = @name, price = @price, imagepath = @imagepath WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@imagepath", imagePath);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error updating product: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM product WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", productId);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error deleting product: {ex.Message}");
                return false;
            }
        }
    }
}