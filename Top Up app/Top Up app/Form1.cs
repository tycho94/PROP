using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;


namespace Top_Up_app
{
    public partial class Form1 : Form
    {
        Databaseconnection data;
        string filelocation;

        public Form1()
        {
            InitializeComponent();
        }
       
    }
}
