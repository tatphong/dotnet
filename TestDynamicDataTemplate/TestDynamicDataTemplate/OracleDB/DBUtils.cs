using System.Globalization;
using System.Runtime.Serialization;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Types;
using Newtonsoft.Json;
using TestDynamicDataTemplate.Models;

namespace TestDynamicDataTemplate.OracleDB
{
    public class DBUtils : DBConnection
    {
        public DBUtils()
        {

        }

        public string ExecuteAndReturn(OracleCommand cmd) //Execute command line and return response
        {
            try
            {
                cmd.ExecuteNonQuery(); // execute procedure
                string returnValue = "";
                returnValue = Convert.ToString(cmd.Parameters["returnvalue"].Value).Trim(); // read return value
                //Logger.Info("Oracle Proc Response: " + returnValue);
                if (returnValue != "")
                    return returnValue;
            }
            catch (Exception e)
            {
            }
            return "99";
        }

        public List<Users> GetUser()
        {
            List<Users> data = new List<Users>();
            OracleConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = $@"select * from EMAIL_USER";
                cmd.CommandType = System.Data.CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    Users user = new Users(dr);
                    data.Add(user);
                };
                
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return data;
        }
        
        public DataTable GetUserReader()
        {
            DataTable data = new DataTable();
            OracleConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = $@"select * from EMAIL_USER";
                cmd.CommandType = System.Data.CommandType.Text;
                OracleDataReader dr = (OracleDataReader)cmd.ExecuteReader();

                data.Load(dr);

                //if (dr.HasRows)
                //    while (dr.Read()) 
                //    {
                //        data.Add((dr));
                //    };
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return data;
        }

        public void GetFieldTemplate(string template)
        {

        }
        
    }
}