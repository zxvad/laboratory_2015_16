using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementServer
{
    class Listener
    {
        TcpListener listener;
        IServer server = (IServer)new Server();
        public Listener(int Port)
        {
            listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
            while (true)
            {
                GetClientRequest(listener.AcceptTcpClient());
            }
        }

        void GetClientRequest(Object StateInfo)
        {
            server.Start((TcpClient)StateInfo);
        }

        ~Listener()
        {
            if (listener != null)
            {
                listener.Stop();
            }
        }
    }
}
