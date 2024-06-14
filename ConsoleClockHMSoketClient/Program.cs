using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClockHMSoketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Loopback;
            Socket socket = new Socket(iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(iPAddress, 56754));

            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Waiting...");

            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int received = socket.ReceiveFrom(buffer, ref remoteEndPoint);
                    string currentTime = Encoding.UTF8.GetString(buffer, 0, received);

                    Console.Clear();
                    Console.WriteLine($"Current time: {currentTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
