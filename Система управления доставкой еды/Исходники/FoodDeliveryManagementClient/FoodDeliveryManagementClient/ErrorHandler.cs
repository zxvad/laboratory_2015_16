using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementClient
{
    class ErrorHandler
    {
        public static void CreateConnectionConfigFile()
        {
            using (StreamWriter sw = new StreamWriter("connection.cfg"))
            {
                sw.WriteLine("http://127.0.0.1:8080");
                sw.Close();
            }
        }
    }
}
