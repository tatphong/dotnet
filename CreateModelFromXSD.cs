using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ConsoleXML
{
    class Program
    {
        static void Main(string[] args)
        {
            GIAODICH item = NewMain();
            WriteXML(item);
            //OldMian();
        }
        public static GIAODICH NewMain(){
            // xsd D:\Code\Dotnet\ConsoleXML\signature2.xsd D:\Code\Dotnet\ConsoleXML\transaction2.xsd /classes /outputdir:D:\Code\Dotnet\ConsoleXML\
            //string xsdPath = "Transaction.xsd";
            string xmlPath = "011200000110060238.xml";
            //Console.WriteLine(ValidateXML(xsdPath, xmlPath));
            using (var fileStream = File.Open(xmlPath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(GIAODICH));
                GIAODICH ship = (GIAODICH)serializer.Deserialize(fileStream);
                //Console.WriteLine($"Item: {JsonConvert.SerializeObject(ship)}");
                //Console.WriteLine($"Item: {JsonConvert.SerializeObject(ship, Formatting.Indented)}");
                return ship;
            }
            Console.WriteLine("Hello World!");
            return null;
        }
        public static void WriteXML(GIAODICH obj){
            XmlSerializer xsSubmit = new XmlSerializer(typeof(GIAODICH));
            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = System.Xml.Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);
                    Console.WriteLine(sww.ToString());
                    File.WriteAllText("WriteText.xml", sww.ToString());
                }
            }
        }
        public static void OldMian(){
            // C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools>xsd D:\Code\Dotnet\ConsoleXML\shiporder.xsd /classes /outputdir:D:\Code\Dotnet\ConsoleXML\
            //shiporder item = new shiporder();
            string xsdPath = "shiporder.xsd";
            string xmlPath = "shiporder.xml";
            Console.WriteLine(ValidateXML(xsdPath, xmlPath));
            using (var fileStream = File.Open("shiporder.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(shiporder));
                shiporder ship = (shiporder)serializer.Deserialize(fileStream);
                Console.WriteLine($"Item: {JsonConvert.SerializeObject(ship)}");
                //Console.WriteLine($"Item: {JsonConvert.SerializeObject(ship, Formatting.Indented)}");
            }
            Console.WriteLine("Hello World!");
            
        }
        public static bool ValidateXML(string xsdPath , string xmlPath){
            bool ans = true;
            XmlSchemaSet schema = new XmlSchemaSet();  
            schema.Add("",xsdPath);
            using(System.Xml.XmlReader rd = System.Xml.XmlReader.Create(xmlPath)){
                XDocument doc = XDocument.Load(rd);  
                doc.Validate(schema, (o, e) => {
                                    Console.WriteLine("{0}", e.Message);
                                    ans = false;
                                });  
            } 
            return ans;
        }
    }
}
