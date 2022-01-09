using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using ServerDauGia.Model;
using MySql.Data.MySqlClient;

namespace ServerDauGia.DAO
{
    class DBUtils
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string connStr = "server=localhost;uid=root;pwd=13760119;database=daugia;";

        public User GetUserData(string username)
        {
            User user = null;
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from users where username = '"+username+"';";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    user = new User(null, null, -1, true);
                }
                else 
                { 
                    while (dr.Read())
                    {
                        string hpass = dr.GetString("hashpass");
                        int balance = Int32.Parse(dr.GetString("balance"));
                        bool block = dr.GetBoolean("hashpass");
                        user = new User(username, hpass, balance, block);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err Get User: " + ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return user;
        }

        public string addUser(User user)
        {
            string res = "98";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@$"insert into users(username, password, balance, lock) 
                                            values ('{user.username}', '{user.hashpass}', {user.block},
                                                    {user.block});");
                cmd.ExecuteNonQuery();
                res = "00";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err Create User: " + ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            Console.WriteLine("User add succeed");
            return res;
        }

        public string updateUserData(string username, string column, string data)
        {
            string res = "98";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@$"update users set {column}={data} 
                                                where username = '{username}';");
                cmd.ExecuteNonQuery();
                res = "00";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err Change User Block Status: " + ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return res;
        }

        public string InsertProduct(Product prod)
        {
            string res = "98";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@$"insert into products(name, org_price, final_price, sold
                                                    username, sold_time) 
                                                values ('{prod.name}', {prod.org_price}, {prod.final_price},
                                                    {prod.sold}, '{prod.username}', '{prod.sold_time}');");
                cmd.ExecuteNonQuery();
                res = "00";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err Insert Product: " + ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            Console.WriteLine("Insert Product succeed");
            return res;
        }

        public string UpdateProduct(Product prod)
        {
            string res = "98";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@$"update products set name = '{prod.name}', 
                                                    org_price = {prod.org_price}, 
                                                    final_price = {prod.final_price},
                                                    sold = {prod.sold}, username = '{prod.username}', 
                                                    sold_time = '{prod.sold_time}'
                                                where id = {prod.id};");
                cmd.ExecuteNonQuery();
                res = "00";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err update prod: " + ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return res;
        }

        public Product GetNewRandProduct()
        {
            Product prod = null;
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@$"SELECT * FROM products
                                                    ORDER BY RAND() LIMIT 1;");
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Int32.Parse(dr.GetString("id"));
                    string name = dr.GetString("name");
                    int org_price = Int32.Parse(dr.GetString("org_price"));
                    int final_price = Int32.Parse(dr.GetString("final_price"));
                    bool sold = dr.GetBoolean("sold");
                    string username = dr.GetString("username");
                    DateTime sold_time = DateTime.Parse(dr.GetString("soldtime"));

                    prod = new Product(id, name, org_price, final_price, sold, username, sold_time);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err get random Product: " + ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return prod;
        }
    }
}
