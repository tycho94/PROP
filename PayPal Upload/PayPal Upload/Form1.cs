using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PayPal_Upload
{
    public partial class Form1 : Form
    {
        OpenFileDialog fDialog = new OpenFileDialog();
        TextFileHelper filer;
        string file = "C:/Users/Tycho/Documents/School/Fontys/ProP/PROP/PayPal Upload/PayPal Upload/paypal.txt";
        List<string> list = new List<string>();
        Databaseconnection data;

        public Form1()
        {
            InitializeComponent();
            Dialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = fDialog.FileName;
                tbFile.Text = file;
            }
        }

        private void Dialog()
        {
            fDialog.Title = "Open XML/UML File";
            fDialog.Filter = "TXT Files|*.txt";
            fDialog.InitialDirectory = @"C:\Users\Tycho\Documents\School\Fontys\ProP\PROP\PayPal Upload\PayPal Upload";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filer = new TextFileHelper(file);
            list = filer.LoadFromFile();
            listBox1.DataSource = list;
            data = new Databaseconnection();
            data.Upload(list);            
        }
    }
}
