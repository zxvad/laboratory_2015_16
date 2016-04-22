using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodDeliveryManagementClient
{
    public partial class RegCompany : Form
    {
        public RegCompany()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            IConnection connection = (IConnection) new ServerConnection();
            connection.RegCompany(companyName.Text);
            Close();
        }
    }
}
