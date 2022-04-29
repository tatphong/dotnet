using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.Service;
using Newtonsoft.Json.Linq;
using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Net;
using System.Xml;
using System.IO;
using System.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Program app = new Program();
            var ds = app.InvokeService("GetHoadon1","PE03000000106");
            
            Console.WriteLine(""+ds.Tables.Count );
            Console.WriteLine(ds.Tables[0].Rows[0]["makh"].ToString());
            Console.WriteLine(ds.Tables[0].Rows[0]["TENKH"].ToString());
            Console.WriteLine(ds.Tables[0].Rows[0]["diachi"].ToString());
            //Console.ReadLine();
        }
        private HttpWebRequest CreateSOAPWebRequest(string apiName, string api)
        {
            //Making Web Request  
            string[] split = api.Split(':');
            string ip = split[0]+":" + split[1] +"/"; // http://192.168.1.42/
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(api);
            //SOAPAction  
            Req.Headers.Add(@"SOAPAction:" + ip + apiName);
            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";
            //return HttpWebRequest  
            return Req;
        }
        DataSet InvokeService(string apiName, string input)
        {
            DataSet dataSet = new DataSet();
            string api = "http://192.168.1.42:8081/SMSWS.asmx";
            string[] split = api.Split(':');
            string ip = split[0]+":" + split[1] +"/"; // http://192.168.1.42/
            //Calling CreateSOAPWebRequest method  
            HttpWebRequest request = CreateSOAPWebRequest(apiName, api);

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request  
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""> 
                <soap:Body>  
                <" + apiName + @" xmlns=""http://192.168.1.42/"">  
                    <MaKH>" + input + @"</MaKH>
                </" + apiName + @">  
                </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request  
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream  
                    dataSet = new DataSet();  
                    dataSet.ReadXml(rd,XmlReadMode.ReadSchema); 
                }
            }
            return dataSet;
        }
    }
}
