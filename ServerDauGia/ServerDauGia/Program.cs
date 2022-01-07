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

        static async Task Controller()
        {
            while (true)
            {
                int now = DateTime.Now.Minute;
                while (DateTime.Now.Minute == now)
                {
                    

                }
                currentProd = db.GetNewRandProduct();

            }
        }

        static async Task ClientCommunicate()
        {
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


                    socket.Send(encoding.GetBytes("Response."));

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
            //Task controller = new Task(() => Controller());
            //Task communicate = new Task(() => ClientCommunicate());
            //controller.Start();
            //communicate.Start();
            //await controller;
            //await communicate;
            Console.WriteLine(DateTime.Now.TimeOfDay);
        }
    }
}
