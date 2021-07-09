using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebserviceDemo
{
    public class DBConnector
    {
        private string connectionString = "Data Source = localhost/ORCL; User Id = phong; Password = 12345";
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DBConnector()
        {
             
        }

        public void saveDB(String name)
        {
            log.Info("Starting saveDB");
            using (OracleConnection connection = new OracleConnection())
            {
                
                connection.ConnectionString = connectionString;

                connection.Open();
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                                  connection.ConnectionString);
                log.Info("Connected to db");

                OracleCommand command = connection.CreateCommand();
                string sql = "INSERT INTO sys.hello (name) values ('" + name + "')";
                command.CommandText = sql;

                command.ExecuteReader();
                log.Info("Name saved to DB");
            }
        }
    }
}