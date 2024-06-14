using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleClockHMSoketServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Loopback;

            Socket udpSocket = new Socket(iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(iPAddress, 56754);


            Console.WriteLine("Server start...");

            while (true)
            {
                string currentTime = DateTime.Now.ToLongTimeString();
                byte[] data = Encoding.UTF8.GetBytes(currentTime);

                udpSocket.SendTo(data, endPoint);
                Console.WriteLine($"Send time: {currentTime}");

                Thread.Sleep(1000);
            }
        }
    }
}
