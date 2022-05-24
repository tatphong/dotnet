using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NTP_Synch
{
    class Program
    {
        public static DateTime GetNetworkTime1()
        {
            string ntpServer = ConfigurationManager.AppSettings.Get("NTPServer");
            int ntpPort = Int32.Parse(ConfigurationManager.AppSettings.Get("NTPPort"));
            Console.WriteLine(ntpServer);
            var ntpData = new byte[48];
            ntpData[0] = 0x1B; //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)
            var addresses = Dns.GetHostEntry(ntpServer).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], ntpPort);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);
                Console.WriteLine("Connected.");
                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 10000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }
            Console.WriteLine("Closed.");
            ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
            ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];
            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);
            return networkDateTime;
        }

        static async Task Main(string[] args)
        {
            DateTime ntp_server = GetNetworkTime1();
            DateTime now = DateTime.Now;
            TimeSpan span = ntp_server - now;
            double span_minu = span.Minutes + (span.Seconds * 1.0 / 60);
            if (span.Hours != 0 || Math.Abs(span_minu) >= 5)
                await new SendMail().SendMailAuto(span.Hours, Math.Abs(span_minu));

            Console.WriteLine("Complete.");
        }
    }
}
