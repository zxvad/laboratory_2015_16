using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodDeliveryManagementClient
{
    public partial class Form1 : Form
    {
        private IConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = (IConnection)new ServerConnection();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
            Update();
            try
            {
                Text = string.Format("FoodDeliveryManagement - {0}", connection.Ping() ? "Online" : "Offline");
                using (StreamReader sr = new StreamReader("companyIdentificator"))
                {
                    connection.AuthCompany(sr.ReadLine());
                }
            }
            catch
            {
                Text = "FoodDeliveryManagement - Offline";
            }
        }
    }
}
