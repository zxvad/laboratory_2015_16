using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirNavSystem
{
    public partial class OffsetParamsForm : Form
    {
        public PointsAlgorithmParams param;

        public OffsetParamsForm()
        {
            InitializeComponent();
            param = null;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            param = new PointsAlgorithmParams
            {
                SmallMedianFilterSize = (int)SmallMedFilterUpDown.Value, 
                LargeMedianFilterSize = (int)LargeMedFilterUpDown.Value
            };
        }
    }
}