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
        DatabaseConnection data = new DatabaseConnection();
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
            VisitorsList.DataSource = data.GetNames();
            MoneyLogList.DataSource = data.GetItemPrices();
            StocksList.DataSource = data.GetStock();

            lblVisitors.Text = "Amount Of Visitors:" + Convert.ToString(data.GetVisitors());
            lblTickets.Text = "Tickets total: " + Convert.ToString(data.GetTickets());
            lblsold.Text = "Total items sold:" + Convert.ToString(data.TotalSold());
            lblprofit.Text = "Estimate profit made: " + Convert.ToString(data.GetProfit());

        }
    }
}
