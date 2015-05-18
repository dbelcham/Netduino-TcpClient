using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Netduino.Contrib.TcpClient {
    public class TcpClient : IDisposable
    {
        private readonly IPAddress _host;
        private readonly int _port;
        
        public TcpClient(IPAddress host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Send(string content)
        {
            using (var socket = InitializeSocket())
            {
                socket.Send(Encoding.UTF8.GetBytes(content));
                socket.Send(Encoding.UTF8.GetBytes("\r\n"));
                socket.Close();
            }
        }


        private Socket InitializeSocket()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(_host, _port));
            return socket;
        }

        public void Dispose()
        {
            
        }
    }
}