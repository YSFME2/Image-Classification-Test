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

namespace Image_Classification_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text) || !File.Exists(txtPath.Text))
                return;
            ModelInput sampleData = new ModelInput()
            {
                ImageSource = txtPath.Text,
            };
            // Make a single prediction on the sample data and print results
            txtResult.Text = ConsumeModel.Predict(sampleData).Prediction;
        }
    }
}
