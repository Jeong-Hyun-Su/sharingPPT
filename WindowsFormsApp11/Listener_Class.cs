using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace WindowsFormsApp11
{
    class Listener_Class
    {
        Socket socket;
        
        public bool Listening
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public Listener_Class(int port)
        {
            Port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start(string tcpServerIP)
        {
            if (Listening)
                return;

            socket.Bind(new IPEndPoint(IPAddress.Parse(tcpServerIP), Port));
            socket.Listen(0);
            socket.BeginAccept(callback, null);
            Listening = true;
        }

        public void Stop()
        {
            if (!Listening)
                return;

            socket.Close();
            socket.Dispose();
            Listening = false;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void callback(IAsyncResult ar)
        {
            try
            {
                Socket s = this.socket.EndAccept(ar);
                if(SocketAccepted != null)
                    SocketAccepted(s);

                this.socket.BeginAccept(callback, null);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
