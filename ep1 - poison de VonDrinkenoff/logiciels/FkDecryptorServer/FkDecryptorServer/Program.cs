using System;
using System.Net;
using System.Net.Sockets;

namespace FkDecryptorServer
{
    internal class Program
    {
        static int portTCP = 31337;
        static bool listening = false;


        static void Main(string[] args)
        {
            Log("[+] Program starting");
            ListenTCP();
            Log("[+] Program end");
            Console.Read();
        }

        static void Log(string s)
        {
            Console.WriteLine(s);
        }

        static void ListenTCP()
        {
            TcpListener tl;

            tl = new TcpListener(new IPEndPoint(IPAddress.Any, portTCP));

            try
            {
                tl.Start();
                listening = true;
                Log("[+] TCP listening");
            }
            catch (Exception e)
            {
                Log("[+] TCP listening failed - " + e.Message);
            }

            while (listening)
            {
                TcpClient tc = tl.EndAcceptTcpClient(tl.BeginAcceptTcpClient(delegate { }, new Object()));
                Log("[+] New client : " + tc.Client.RemoteEndPoint.ToString());
            }

            tl.Stop();
        }
    }
}
