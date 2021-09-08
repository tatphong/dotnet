using System;
using System.Collections.Generic;

namespace SQLiteLocalLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DBUtils a = new DBUtils();
            a.AddLog("35S41D63A15d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //check double transID
            Console.WriteLine(a.IsDoubleTransID("35S41D63A15d"));

            //search
            List<Log> s = a.SearchLog("35S41D63A15d", null);
            foreach (Log i in s)
            {
                i.ShowLog();
            }

            //a.SelectLog();
        }
    }
}
