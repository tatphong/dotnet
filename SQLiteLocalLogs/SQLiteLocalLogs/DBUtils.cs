using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQLiteLocalLogs
{
    class DBUtils
    {
        static string conn_string = "Data Source=db.sqlite;Version=3;";
        static DateTime today = DateTime.Today;

        public DBUtils()
        {
            using (SQLiteConnection conn = new SQLiteConnection(conn_string))
            {
                conn.Open();
                string sql = "create table Logs (transactionID nvarchar(20), " +
                                                "transactionDate datetime); ";
                try
                {
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Console.WriteLine("Table Logs already existed.");
                }
            }
        }
        
        public bool IsDoubleTransID(string transID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(conn_string))
            {
                conn.Open();
                int result = 0;
                try
                {
                    string sql = String.Format("SELECT Count(*) FROM Logs WHERE transactionID = '{0}' and date(transactionDate) = '{1}'", transID, DateTime.Now.ToString("yyyy-MM-dd"));
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.CommandType = System.Data.CommandType.Text;
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result = Int32.Parse(reader[0].ToString());
                    }
                }
                //Console.WriteLine(result);
                catch (Exception ex)
                {
                    Console.WriteLine("IsDouble Error: " + ex);
                }
                if (result > 1)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddLog(string transID, string transDate)
        {
            using (SQLiteConnection conn = new SQLiteConnection(conn_string))
            {
                conn.Open();
                // insert data to table
                try
                {
                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText = "insert into Logs (transactionID, transactionDate) values (@transID, @transDate);";
                    command.Parameters.AddWithValue("@transID", transID);
                    command.Parameters.AddWithValue("@transDate", transDate);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("AddLog Error: " + ex);
                }
            }
            if (today != DateTime.Today)
            {
                today = DateTime.Today;
                DeleteOldLog();
            }
        }

        public void SelectLog()
        {
            using (SQLiteConnection conn = new SQLiteConnection(conn_string))
            {
                conn.Open();
                // select data from table
                try
                {
                    string sql = "SELECT * FROM Logs";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();
                    string r = "";
                    while (reader.Read())
                    {
                        r += String.Format("{0}\t{1}\n", reader[0], reader[1]);
                    }
                    Console.WriteLine(r);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SelectLog err: " + ex);
                }
            }
        }

        private void DeleteOldLog()
        {
            using (SQLiteConnection conn = new SQLiteConnection(conn_string))
            {
                conn.Open();
                try
                {
                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText = "DELETE FROM Logs WHERE date(transactionDate, '+15 day') < @date;";
                    command.Parameters.AddWithValue("@date", today.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DeleteLog err: " + ex);
                }
            }
        }

        public List<Log> SearchLog(string transID = "###", string tranDate = "###")
        {
            List<Log> res = new List<Log>();
            using (SQLiteConnection conn = new SQLiteConnection(conn_string))
            {
                conn.Open();
                try
                {
                    string sql = String.Format("SELECT * FROM Logs WHERE transactionID LIKE '%{0}%' OR transactionDate LIKE '%{1}%'", transID, tranDate);
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Log a = new Log(reader.GetString(0), reader.GetString(1));
                        res.Add(a);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Search Err: " + ex);
                }
            }
            return res;
        }
    }

    class Log
    {
        string transID { get; set; }
        string transDate { get; set; }

        public Log(string transID, string transDate)
        {
            this.transID = transID;
            this.transDate = transDate;
        }

        public void ShowLog()
        {
            Console.WriteLine(transID + "\t" + transDate);
        }
    }
}
