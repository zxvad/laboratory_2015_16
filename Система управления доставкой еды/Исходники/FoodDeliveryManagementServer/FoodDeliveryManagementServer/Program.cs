using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FoodDeliveryManagementServer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!File.Exists("server-port.cfg"))
            {
                ErrorHandler.CreateConfigurationFile();
            }
            int port = 0;
            using (StreamReader sr = new StreamReader("server-port.cfg"))
            {
                if (File.Exists("server-port.cfg"))
                {
                    
                    if (!int.TryParse(sr.ReadLine(), out port))
                    {
                        Exit("Error: port config file has wrong format");
                    }
                }
                else
                {
                    Exit("Error: port config file don't exist");
                }
            }
            new Listener(port);
        }

        static void Exit(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
