using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementServer
{
    interface IServer
    {
        void Start(TcpClient client);
    }
}
