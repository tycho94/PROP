using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_application
{
    public partial class Form1 : Form
    {
        DatabaseConnection data;
        public Form1()
        {
            InitializeComponent();
            RefreshPanel();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void RefreshPanel()
        {
            data = new DatabaseConnection();
            VisitorsList.DataSource = data.GetNames();
            data = new DatabaseConnection();
            MoneyLogList.DataSource = data.GetItemPrices();
            data = new DatabaseConnection();
            StocksList.DataSource = data.GetStock();
            data = new DatabaseConnection();

            lblVisitors.Text = "Amount Of Visitors:" + Convert.ToString(data.GetVisitors());
            data = new DatabaseConnection();
            lblTickets.Text = "Tickets total: " + Convert.ToString(data.GetTickets());
            data = new DatabaseConnection();
            lblsold.Text = "Total items sold:" + Convert.ToString(data.TotalSold());
            data = new DatabaseConnection();
            lblprofit.Text = "Estimate profit made: " + Convert.ToString(data.GetProfit());

        }
    }
}
