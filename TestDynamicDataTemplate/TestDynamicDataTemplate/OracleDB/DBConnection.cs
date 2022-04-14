using Oracle.ManagedDataAccess.Client;
using System;
//using System.Configuration;
//using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace TestDynamicDataTemplate.OracleDB
{
    public class DBConnection
    {
        string connectString = new AppSetting().GetConnectionStringDB();
        public DBConnection()
        {
        }
        public OracleConnection GetConnection() // connect Oracle DB
        {
            AppSetting appSetting = new AppSetting();
            string dbHost = appSetting.GetDBHost();
            string dbPort = appSetting.GetDbPort();
            string dbSID = appSetting.GetDbSID();
            string dbUser = appSetting.GetDbUser();
            string dbPass = appSetting.GetDbPass();
            //string passTemp = Utils.Encrypt("etaxdb", true);
            //dbPass = Decrypt(dbPass, true);
            //Logger.Info("DBHOST." + dbHost + " " + dbPort);
            return new OracleConnection(String.Format(connectString, new object[] { dbHost, dbPort, dbSID, dbUser, dbPass }));
        }

        public string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "sbbs-offline";

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}