using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQLiteLocalLogs
{
    class DBUtils
    {

        static SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        static DateTime today = DateTime.Today;

        public DBUtils()
        {
            m_dbConnection.Open();
            //create table
            try
            {
                string sql = "create table Logs (transactionID nvarchar(20), " +
                                                "transactionDate datetime); ";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Table Logs already existed.");
            }
            m_dbConnection.Close();
        }
        
        public bool IsDoubleTransID(string transID)
        {
            try
            {
                m_dbConnection.Open();
                string sql = String.Format("SELECT Count(*) FROM Logs WHERE transactionID = '{0}' and date(transactionDate) = '{1}'", transID, DateTime.Now.ToString("yyyy-MM-dd"));
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.CommandType = System.Data.CommandType.Text;
                SQLiteDataReader reader = command.ExecuteReader();
                int result = 0;
                while (reader.Read())
                {
                    result = Int32.Parse(reader[0].ToString());
                }
                //Console.WriteLine(result);

                if (result > 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("IsDouble Error: " + ex);
            }
            finally
            {
                m_dbConnection.Close();
            }
            return false;
        }

        public void AddLog(string transID, string transDate)
        {
            try
            {
                m_dbConnection.Open();
                // insert data to table
                using (SQLiteCommand command = m_dbConnection.CreateCommand())
                {
                    command.CommandText = "insert into Logs (transactionID, transactionDate) values (@transID, @transDate);";
                    command.Parameters.AddWithValue("@transID", transID);
                    command.Parameters.AddWithValue("@transDate", transDate);
                    command.ExecuteNonQuery();
                }

                if (today != DateTime.Today)
                {
                    today = DateTime.Today;
                    DeleteOldLog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddLog Error: " + ex);
            }
            finally
            {
                m_dbConnection.Close();
            }
        }

        public void SelectLog()
        {
            try
            {
                m_dbConnection.Open();
                // insert data to table
                string sql = "SELECT * FROM Logs";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
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
                Console.WriteLine(ex);
            }
            finally
            {
                m_dbConnection.Close();
            }
        }

        private void DeleteOldLog()
        {
            try
            {
                //m_dbConnection.Open();    //Connection already opened at func: Add Log
                using (SQLiteCommand command = m_dbConnection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Logs WHERE date(transactionDate, '+15 day') < @date;";
                    command.Parameters.AddWithValue("@date", today.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DelLog Err: " + ex);
            }
            finally
            {
                //m_dbConnection.Close();
            }
        }

        public List<Log> SearchLog(string transID = "###", string tranDate = "###")
        {
            List<Log> res = new List<Log>();
            try
            {
                m_dbConnection.Open();
                string sql = String.Format("SELECT * FROM Logs WHERE transactionID LIKE '%{0}%' OR transactionDate LIKE '%{1}%'", transID, tranDate);
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
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
            finally
            {
                m_dbConnection.Close();
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
