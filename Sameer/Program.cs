using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class Program
    {
        // Server settings
        static string ipAddress = "127.0.0.1";
        static int port = 8080;

        static void Main(string[] args)
        {
            // Connect to the server
            TcpClient client = new TcpClient(ipAddress, port);

            Console.WriteLine("Connected to server");

            // Send a string to the server
            string sendString = "SetA-One";
            byte[] data = Encoding.ASCII.GetBytes(sendString);
            client.GetStream().Write(data, 0, data.Length);

            // Receive data from the server
            byte[] buffer = new byte[1024];
            int bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);
            // Decode the received string
            string receivedString = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Received string from server: {receivedString}");

            // Close the connection
            client.Close();
        }
    }
}

