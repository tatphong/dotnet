using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.IO;
using GroupDocs.Merger;
using System.Linq;

namespace ConsoleDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Program runner = new Program();
            List<PayooReport> payoo = new List<PayooReport>();
            var reports = runner.GetSGBLog();
            var compare = (from sgb in reports join pay in payoo
                          on sgb.SystemTrace equals pay.SystemTrace
                          select new Report
                              {
                                TransactionId= sgb.TransactionId,
                                SystemTrace= sgb.SystemTrace,
                                DaiLy= sgb.DaiLy,
                                RequestTime= sgb.RequestTime,
                                ResponseTime= sgb.ResponseTime,
                                BranchId= sgb.BranchId,
                                ProvideId= sgb.ProvideId,
                                ServiceType= sgb.ServiceType,
                                ServicesId= sgb.ServicesId,
                                MoneyTotal= sgb.MoneyTotal,
                                CustomerId= sgb.CustomerId,
                                Status= sgb.Status,
                                Note = (
                                    sgb.Status == "1" && pay.Status == "0" ? "Payoo nhiều hơn" :
                                    (String.IsNullOrEmpty(sgb.Status) || String.IsNullOrEmpty(sgb.ResponseTime)) && pay.Status == "1" ? "Payoo nhiều hơn" :
                                    (String.IsNullOrEmpty(sgb.Status) || String.IsNullOrEmpty(sgb.ResponseTime)) && String.IsNullOrEmpty(pay.Status) ? "SaigonBank nhiều hơn" : "Unknow"
                                )
                              }
                          ).ToList();


        }
        public List<Report> GetSGBLog(string begin= "01/03/2022", string end = "01/04/2022")
        {
            begin = "01/03/2022";
            end = "01/04/2022";
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=201.201.201.175)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ATMP)));User Id=ONLINEPAYMENT;Password=ONLINEPAYMENT; Pooling=true; Max Pool Size=50";
            //string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.72.71)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=EOC_TEST)));User Id=VUTRUONGGIANG;Password=*********; Pooling=true; Max Pool Size=50";
            List<Report> data = new List<Report>();
            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = @$"SELECT ORDERNO,SYSTEMTRACE, BRANCH_ID,REQUEST_TIME, RESPONSE_TIME,
                                                     moneytotal, providerid, servicesid,CUSTOMERID, RETURNCODE 
                                    FROM PAYOO_TRANX_LOG
                                    WHERE request_time BETWEEN to_date('{begin}','dd/mm/yyyy') AND to_date('{end}','dd/mm/yyyy')
                                    and RETURNCODE <> 0
                                    ORDER BY request_time";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var item = new Report()
                        {
                            TransactionId = dr["ORDERNO"].ToString(),
                            SystemTrace = dr["SYSTEMTRACE"].ToString(),
                            RequestTime = dr["REQUEST_TIME"].ToString(),
                            ResponseTime = dr["RESPONSE_TIME"].ToString(),
                            BranchId = dr["BRANCH_ID"].ToString(),
                            ProvideId = dr["providerid"].ToString(),
                            ServicesId = dr["servicesid"].ToString(),
                            MoneyTotal = dr["moneytotal"].ToString(),
                            CustomerId = dr["CUSTOMERID"].ToString(),
                            Status = dr["RETURNCODE"].ToString(),
                        };
                        Console.WriteLine(item.ToString());
                        data.Add(item);
                    }
                }

                conn.Close();
                Console.WriteLine();
                Console.WriteLine(data.Count);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return data;
        }
        public class PayooReport
        {
            public string SystemTrace { get; set; }
            public string CustomerId { get; set; }
            public string Status { get; set; }
        }
        public class Report
        {
            public string TransactionId { get; set; }
            public string SystemTrace { get; set; }
            public string DaiLy { get; set; } = "Saigonbank";
            public string RequestTime { get; set; }
            public string ResponseTime { get; set; }
            public string BranchId { get; set; }
            public string ProvideId { get; set; }
            public string ServiceType { get; set; } = "PayBill";
            public string ServicesId { get; set; }
            public string MoneyTotal { get; set; }
            public string CustomerId { get; set; }
            public string Status { get; set; }
            public string Note { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }


        public void MergerHtml()
        {
            string html1 = File.ReadAllText("D:/Code/Dotnet/ConsoleDapper/ConsoleDapper/file1.html");
            string html2 = File.ReadAllText("D:/Code/Dotnet/ConsoleDapper/ConsoleDapper/file2.html");
            //Console.WriteLine(html);
            using (Merger merger = new Merger("D:/Code/Dotnet/ConsoleDapper/ConsoleDapper/file1.html"))
            {
                // Call Join method of Merger class instance and pass second source document path
                merger.Join("D:/Code/Dotnet/ConsoleDapper/ConsoleDapper/file2.html");

                // Call Save method of Merger class instance to save merged document
                merger.Save("D:/Code/Dotnet/ConsoleDapper/ConsoleDapper/merged-file.html");
            }
        }
        public void DapperText()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            Console.WriteLine("Hello World!");
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.72.71)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=EOC_TEST)));User Id=VUTRUONGGIANG;Password=*********; Pooling=true; Max Pool Size=50";
            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                conn.Open();

                Console.WriteLine("Hello");
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("pClass", "A", dbType: (OracleMappingType?)OracleDbType.NVarchar2, direction: ParameterDirection.Input);
                parameters.Add("returnvalue", dbType: (OracleMappingType?)OracleDbType.Int64, direction: ParameterDirection.Output);
                parameters.Add("p_recordset", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("pClass", "A", DbType.String, ParameterDirection.Input);
                //parameters.Add("returnvalue", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //parameters.Add("p_recordset", dbType: DbType.Object, direction: ParameterDirection.Output);

                //var result = conn.Execute("VUTRUONGGIANG.PKGTEST.liststudent", parameters, commandType: CommandType.StoredProcedure);
                var result = SqlMapper.Query<Student>(conn, "PKGTEST.liststudent", param: parameters, commandType: CommandType.StoredProcedure);
                Console.WriteLine(result.ToString());
                Console.WriteLine(parameters.Get<Decimal>("returnvalue"));
                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString());
                }


                //Console.WriteLine(parameters.Get<OracleDbType.RefCursor>("p_recordset"));
                //Console.ReadLine();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
    class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Column("Class_Id")]
        //[Column(Name = "Class")]
        //[Column(Storage = "Class")]
        public string ClassId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
