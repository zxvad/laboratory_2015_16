using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodDeliveryManagementServer
{
    class Server :IServer
    {
        

        private string ReadClientMessage(TcpClient Client)
        {
            byte[] Buffer = new byte[Client.ReceiveBufferSize];
            int count;
            try
            {
                count = Client.GetStream().Read(Buffer, 0, Buffer.Length);
                return (count > 0) ? Encoding.UTF8.GetString(Buffer, 0, count) : null;
            }
            catch
            {
                Client.Close();
                return null;
            }
        }
        void IServer.Start(TcpClient Client)
        {
            string Request = ReadClientMessage(Client);
            if (!Client.Connected) return;
            Match ReqMatch = Regex.Match(Request, @"^\w+\s+[\W]+([^\s\?]+)[^\s]*\s+HTTP/.*|");
            if (ReqMatch == Match.Empty)
            {
                SendError(Client, 400);
                return;
            }

            string RequestUri = String.Empty;
            RequestUri = ReqMatch.Groups[1].Value;
            RequestUri = Uri.UnescapeDataString(RequestUri);

            if (RequestUri.IndexOf("..") >= 0)
            {
                SendError(Client, 400);
                return;
            }
            var methods = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                if (method.Name == RequestUri)
                {
                    method.Invoke(this, (method.GetParameters().Length == 1) ? new object[] { Client }
                    : new object[] { Client, Request });
                    Console.WriteLine("Invoked {0}",method.Name);
                    return;
                }
            }
            SendError(Client, 404);
        }

        private void SendError(TcpClient Client, int Code)
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("Error");
            Console.ForegroundColor = ConsoleColor.Gray;
            string MessageText = String.Format("HTTP/1.1 {0} {1}\n\n", Code, (HttpStatusCode)Code);
            byte[] buf = Encoding.UTF8.GetBytes(MessageText);
            Client.GetStream().Write(buf, 0, buf.Length);
            Client.Close();
        }

        public Server()
        {
           
        }

        private void Ping(TcpClient Client)
        {
            string MessageText = "HTTP/1.1 200 OK\n\n";
            byte[] buf = Encoding.UTF8.GetBytes(MessageText);
            Client.GetStream().Write(buf, 0, buf.Length);
            Client.Close();
        }

        private void RegCompany(TcpClient Client,string Request)
        {
            try
            {
                if (Request.IndexOf("Expect: 100-continue") > 0)
                {
                    Request = Expect100Handler(Client);
                    if (!Client.Connected) return;
                }
                string resource = Guid.NewGuid().ToString();
                string MessageText = string.Format(
                    "HTTP/1.1 200 OK\nContent-Length:{0}\n\n{1}",
                    resource.Length, resource);
                byte[] buf = Encoding.UTF8.GetBytes(MessageText);
                Client.GetStream().Write(buf, 0, buf.Length);
                Client.Close();
            }
            catch
            {
                SendError(Client,400);
            }
        }

        private void AuthCompany(TcpClient Client, string Request)
        {
            try
            {
                if (Request.IndexOf("Expect: 100-continue") > 0)
                {
                    Request = Expect100Handler(Client);
                    if (!Client.Connected) return;
                }
                string MessageText = "HTTP/1.1 200 OK\n\n";
                byte[] buf = Encoding.UTF8.GetBytes(MessageText);
                Client.GetStream().Write(buf, 0, buf.Length);
                Client.Close();
            }
            catch
            {
                SendError(Client, 400);
            }
        }

        private string Expect100Handler(TcpClient Client)
        {
            string MessageText = "HTTP/1.1 100 Continue\n\n";
            byte[] buf = Encoding.UTF8.GetBytes(MessageText);
            Client.GetStream().Write(buf, 0, buf.Length);
            return ReadClientMessage(Client);
        }
    }
}
