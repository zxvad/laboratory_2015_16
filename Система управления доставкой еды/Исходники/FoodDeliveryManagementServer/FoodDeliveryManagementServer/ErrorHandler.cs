using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FoodDeliveryManagementServer
{
    class ErrorHandler
    {
        public static void CreateConfigurationFile()
        {
            using (StreamWriter sw = new StreamWriter("server-port.cfg"))
            {
                sw.WriteLine("8080");
                sw.Close();
            }
        }
    }
}
