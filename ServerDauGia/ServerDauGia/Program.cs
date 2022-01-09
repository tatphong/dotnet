using ServerDauGia.DAO;
using ServerDauGia.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerDauGia
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 1234;
        static DBUtils db = new DBUtils();
        static Product currentProd { get; set; } = new Product();
        Dictionary<string, string> data = new Dictionary<string, string>();

        static ASCIIEncoding encoding = new ASCIIEncoding();

        static private string create_md5(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        static async Task ConsoleManager() 
        {
            while (true) 
            {
                string input = Console.ReadLine();
                Product nullprod = new Product();
                string res = Controller(input.ToLower(), ref nullprod);
                if (res == "00")
                    Console.WriteLine("Thêm thành công");
                else if (res == "98")
                    Console.WriteLine("Lỗi cơ sở dữ liệu");
                else
                    Console.WriteLine("Lỗi không xác định");
            }
        }

        static async Task Autorun()
        {
            Console.WriteLine("Auto task started");
            while (true)
            {
                int now = DateTime.Now.Minute;
                //trừ tiền và mở khoá cho người thắng
                if (!string.IsNullOrEmpty(currentProd.username))
                {
                    User user = db.GetUserData(currentProd.username);
                    db.updateUserData(user.username, "lock", "0");
                    int new_balance = user.balance - currentProd.final_price;
                    db.updateUserData(user.username, "balance", new_balance.ToString());

                    currentProd.sold = true;
                    currentProd.sold_time = DateTime.Now;
                    db.UpdateProduct(currentProd);
                    Console.WriteLine("New product is put on floor.");
                }
                //lấy sản phẩm mới
                currentProd = db.GetNewRandProduct();

                while (DateTime.Now.Minute == now)
                {

                }
            }
        }

        static string Controller(string input, ref Product prod)
        {
            string res = "99";
            string[] input_data = input.Split(";");    //format: cmd;username;data
            User user = db.GetUserData(input_data[1]);

            switch (input_data[0])
            {
                case "bet":
                    int price = Int32.Parse(input_data[2]);
                    //ktra đủ tiền chưa
                    if (user.balance < price)
                        return "51";
                    //ktra giá lớn nhất chưa
                    if (price <= currentProd.final_price)
                        return "01";

                    //mở khoá tài khoản trước đó đã bet
                    db.updateUserData(currentProd.username, "lock", "0");
                    //cập nhật dữ liệu
                    currentProd.final_price = price;
                    currentProd.username = user.username;
                    db.UpdateProduct(currentProd);
                    //khoá tài khoản
                    res = db.updateUserData(currentProd.username, "lock", "1");
                    break;
                case "authenticate":
                    if (string.IsNullOrEmpty(user.username))
                        res = "12";
                    else if ((user.hashpass.CompareTo(input_data[2])==0) && !user.block)
                        res = "00;"+user.balance;
                    else
                        res = "01";
                    break;
                case "check":
                    if (prod.id != currentProd.id)
                    {
                        res = prod.username + ";" + prod.final_price + ";" + currentProd.name + ";" + currentProd.org_price;
                        prod = currentProd;
                    }

                    if (prod.final_price != currentProd.final_price)
                    {
                        prod = currentProd;
                        res = prod.final_price.ToString();
                    }
                    break;
                case "insertuser":
                    User new_user = new User(input_data[1], create_md5(input_data[2]).ToLower(), Int32.Parse(input_data[3]), false);
                    res = db.addUser(new_user);
                    break;
                case "insertproduct":
                    Product new_prod = new Product(input_data[1], Int32.Parse(input_data[2]));
                    res = db.InsertProduct(new_prod);
                    break;
                default:
                    break;
            }
            return res;
        }

        static async Task ClientCommunicate()
        {
            Product prod = currentProd;
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(address, PORT_NUMBER);
                listener.Start();

                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

                while (true)
                {
                    byte[] data = new byte[BUFFER_SIZE];
                    string input = "";
                    socket.Receive(data);
                    input = encoding.GetString(data);
                    Console.WriteLine("server received: " + input);
                    string res = Controller(input.ToLower(), ref prod);

                    Console.WriteLine("server send: " + res);
                    socket.Send(encoding.GetBytes(res));
                }
                socket.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        static async Task Main(string[] args)
        {
            Task controller = new Task(() => Autorun());
            Task communicate = new Task(() => ClientCommunicate());
            //Task console = new Task(() => ConsoleManager());
            controller.Start();
            communicate.Start();
            //console.Start();
            await controller;
            await communicate;
            //await console;
            //Console.WriteLine(DateTime.Now);
        }
    }
}
