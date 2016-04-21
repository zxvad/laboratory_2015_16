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
    public partial class MainForm : Form
    {
        string[] Images;
        List<Bitmap> Bitmaps;
        ContoursParamsForm contoursParamsForm;
        OffsetParamsForm offsetParamsForm;
        ImageProcessor Processor;
        DataStorage Storage;

        public MainForm()
        {
            InitializeComponent();
            Bitmaps = new List<Bitmap>();
            contoursParamsForm = new ContoursParamsForm();
            offsetParamsForm = new OffsetParamsForm();
            ImagesListBox.SelectedIndexChanged += ImagesListBox_SelectedIndexChanged;
        }

        private void OpenImagesButton_Click(object sender, EventArgs e)
        {
            if (OpenImagesDialog.ShowDialog() == DialogResult.OK)
            {
                Images = OpenImagesDialog.FileNames;
                ImagesListBox.Items.AddRange(OpenImagesDialog.SafeFileNames);
                foreach (var image in OpenImagesDialog.FileNames)
                {
                    Bitmaps.Add(new Bitmap((string)image));
                }
            }
        }

        private void ImagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ImagesListBox.SelectedIndex == -1)
            {
                pictureBox.Image = null;
                return;
            }
            pictureBox.Image = Bitmaps[ImagesListBox.SelectedIndex];
        }

        private void SelectAllImagesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ImagesListBox.Items.Count; i++)
                ImagesListBox.SetItemChecked(i, true);
        }

        private void UnselectAllImagesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ImagesListBox.Items.Count; i++)
                ImagesListBox.SetItemChecked(i, false);
        }

        private void InvertSelectedImagesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ImagesListBox.Items.Count; i++)
                ImagesListBox.SetItemChecked(i, !ImagesListBox.GetItemChecked(i));
        }

        private void DeleteSelectedImagesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ImagesListBox.Items.Count;)
                if (ImagesListBox.GetItemChecked(i))
                {
                    ImagesListBox.Items.RemoveAt(i);
                    Bitmaps.RemoveAt(i);
                }
                else
                    i++;
        }

        private void AddContoursParamsButton_Click(object sender, EventArgs e)
        {
            if (contoursParamsForm.ShowDialog() == DialogResult.OK)
            {
                ContoursParamsListBox.Items.Add(contoursParamsForm.param);
            }
        }

        private void DeleteContoursParamsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ContoursParamsListBox.Items.Count;)
                if (ContoursParamsListBox.GetItemChecked(i))
                    ContoursParamsListBox.Items.RemoveAt(i);
                else
                    i++;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddOffsetParamsButton_Click(object sender, EventArgs e)
        {
            if (offsetParamsForm.ShowDialog() == DialogResult.OK)
            {
                OffsetParamsListBox.Items.Add(offsetParamsForm.param);
            }
        }

        private void DeleteOffsetParamsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OffsetParamsListBox.Items.Count;)
                if (OffsetParamsListBox.GetItemChecked(i))
                    OffsetParamsListBox.Items.RemoveAt(i);
                else
                    i++;
        }
    }
}