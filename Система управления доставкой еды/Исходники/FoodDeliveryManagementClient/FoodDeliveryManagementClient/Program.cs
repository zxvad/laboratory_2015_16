using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodDeliveryManagementClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IConnection connection = (IConnection) new ServerConnection();
            if (!File.Exists("companyIdentificator"))
            {
                if (connection.Ping())
                {
                    Application.Run(new RegCompany());
                }
            }
            Application.Run(new Form1());
        }
    }
}
