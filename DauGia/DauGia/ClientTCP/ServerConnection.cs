using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DauGia
{
    public class ServerConnection
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 1234;
        
        TcpClient client = new TcpClient();
        Stream stream;
        static ASCIIEncoding encoding = new ASCIIEncoding();

        public ServerConnection()
        {
            try
            {
                client.Connect("127.0.0.1", PORT_NUMBER);
                stream = client.GetStream();

                Console.WriteLine("Connected to Server DauGia.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error open Connection: " + ex);
            }
        }

        public string Send(string input)
        {
            byte[] data = encoding.GetBytes(input);
            stream.Write(data, 0, data.Length);

            data = new byte[BUFFER_SIZE];
            stream.Read(data, 0, BUFFER_SIZE);

            return encoding.GetString(data);
        }

        public void closeConnection()
        {
            try
            {
                stream.Close();
                client.Close();
                Console.WriteLine("Connection to server closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error close connect: ", ex);
            }
        }
    }
}
