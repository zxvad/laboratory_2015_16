using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FoodDeliveryManagementClient
{
    class ServerConnection : IConnection
    {
        private string baseUrl { get; set; }

        public ServerConnection()
        {
            if (!File.Exists("connection.cfg")) ErrorHandler.CreateConnectionConfigFile();
            using (StreamReader sr = new StreamReader("connection.cfg"))
            {
                baseUrl = sr.ReadLine();
            }
        }

        bool IConnection.Ping()
        {
            using (var client = new HttpClient())
            {
                var method = "/Ping";
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync(method);
                //if(response.Result.StatusCode==HttpStatusCode.)
                return response.Result.IsSuccessStatusCode;

            }
        }

        void IConnection.RegCompany(string companyName)
        {
            using (var client = new HttpClient())
            {
                var method = "/RegCompany";
                client.BaseAddress = new Uri(baseUrl);
                HttpContent content = new ByteArrayContent(Encoding.UTF8.GetBytes(companyName));
                HttpContent httpContent = null;
                var response = client.PostAsync(method, content)
                                    .ContinueWith(responseTask =>
                                    {
                                        httpContent = responseTask.Result.Content;
                                    });
                response.Wait();
                string responseFromServer = httpContent.ReadAsStringAsync().Result;
                using (StreamWriter sw = new StreamWriter("companyIdentificator"))
                {
                    sw.WriteLine(responseFromServer);
                    sw.Close();
                }
            }
        }

        void IConnection.AuthCompany(string companyKey)
        {
            using (var client = new HttpClient())
            {
                var method = "/AuthCompany";
                client.BaseAddress = new Uri(baseUrl);
                HttpContent content = new ByteArrayContent(Encoding.UTF8.GetBytes(companyKey));
                HttpContent httpContent = null;
                var response = client.PostAsync(method, content)
                                    .ContinueWith(responseTask =>
                                    {
                                        httpContent = responseTask.Result.Content;
                                    });
                response.Wait();
                string responseFromServer = httpContent.ReadAsStringAsync().Result;
            }
        }
    }
}
