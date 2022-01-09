using ServerDauGia.DAO;
using ServerDauGia.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerDauGia
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 1234;
        static DBUtils db = new DBUtils();
        static Product currentProd { get; set; }
        Dictionary<string, string> data = new Dictionary<string, string>();

        static ASCIIEncoding encoding = new ASCIIEncoding();
        static async Task Autorun()
        {
            while (true)
            {
                int now = DateTime.Now.Minute;
                while (DateTime.Now.Minute == now)
                {

                }
                //trừ tiền và mở khoá cho người thắng
                if (currentProd.username != null)
                {
                    User user = db.GetUserData(currentProd.username);
                    db.updateUserData(user.username, "lock", "0");
                    int new_balance = user.balance - currentProd.final_price;
                    db.updateUserData(user.username, "balance", new_balance.ToString());

                    currentProd.sold = true;
                    currentProd.sold_time = DateTime.Now;
                    db.UpdateProduct(currentProd);
                }

                //lấy sản phẩm mới
                currentProd = db.GetNewRandProduct();
            }
        }

        static string Controller(string input,ref Product prod)
        {
            string res = "99";
            string[] input_data = input.Split();    //format: cmd;username;data
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
                    if (user.hashpass == input_data[2])
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

                // 1. listen
                listener.Start();

                Console.WriteLine("Server started on " + listener.LocalEndpoint);

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

                byte[] data = new byte[BUFFER_SIZE];
                string input = "";
                while (!input.ToLower().Equals("bye"))
                {
                    socket.Receive(data);
                    input = encoding.GetString(data);
                    string res = Controller(input.ToLower(), ref prod);

                    socket.Send(encoding.GetBytes(res));
                }
                socket.Send(encoding.GetBytes("Close connect."));

                // 4. close
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
            controller.Start();
            communicate.Start();
            await controller;
            await communicate;
            //Console.WriteLine(DateTime.Now);
        }
    }
}
