namespace Admin_application
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoneyLogList = new System.Windows.Forms.ListBox();
            this.VisitorsList = new System.Windows.Forms.ListBox();
            this.lblVisitors = new System.Windows.Forms.Label();
            this.StocksList = new System.Windows.Forms.ListBox();
            this.lblTickets = new System.Windows.Forms.Label();
            this.lblprofit = new System.Windows.Forms.Label();
            this.lblsold = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MoneyLogList
            // 
            this.MoneyLogList.FormattingEnabled = true;
            this.MoneyLogList.Location = new System.Drawing.Point(276, 31);
            this.MoneyLogList.Name = "MoneyLogList";
            this.MoneyLogList.Size = new System.Drawing.Size(200, 173);
            this.MoneyLogList.TabIndex = 0;
            // 
            // VisitorsList
            // 
            this.VisitorsList.FormattingEnabled = true;
            this.VisitorsList.Location = new System.Drawing.Point(26, 31);
            this.VisitorsList.Name = "VisitorsList";
            this.VisitorsList.Size = new System.Drawing.Size(200, 173);
            this.VisitorsList.TabIndex = 2;
            // 
            // lblVisitors
            // 
            this.lblVisitors.AutoSize = true;
            this.lblVisitors.Location = new System.Drawing.Point(23, 231);
            this.lblVisitors.Name = "lblVisitors";
            this.lblVisitors.Size = new System.Drawing.Size(96, 13);
            this.lblVisitors.TabIndex = 3;
            this.lblVisitors.Text = "Amount Of Visitors:";
            // 
            // StocksList
            // 
            this.StocksList.FormattingEnabled = true;
            this.StocksList.Location = new System.Drawing.Point(510, 31);
            this.StocksList.Name = "StocksList";
            this.StocksList.Size = new System.Drawing.Size(200, 173);
            this.StocksList.TabIndex = 4;
            // 
            // lblTickets
            // 
            this.lblTickets.AutoSize = true;
            this.lblTickets.Location = new System.Drawing.Point(23, 244);
            this.lblTickets.Name = "lblTickets";
            this.lblTickets.Size = new System.Drawing.Size(71, 13);
            this.lblTickets.TabIndex = 6;
            this.lblTickets.Text = "Tickets total: ";
            // 
            // lblprofit
            // 
            this.lblprofit.AutoSize = true;
            this.lblprofit.Location = new System.Drawing.Point(273, 231);
            this.lblprofit.Name = "lblprofit";
            this.lblprofit.Size = new System.Drawing.Size(105, 13);
            this.lblprofit.TabIndex = 9;
            this.lblprofit.Text = "Estimate profit made:";
            // 
            // lblsold
            // 
            this.lblsold.AutoSize = true;
            this.lblsold.Location = new System.Drawing.Point(273, 244);
            this.lblsold.Name = "lblsold";
            this.lblsold.Size = new System.Drawing.Size(83, 13);
            this.lblsold.TabIndex = 10;
            this.lblsold.Text = "Total items sold:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(342, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 296);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblsold);
            this.Controls.Add(this.lblprofit);
            this.Controls.Add(this.lblTickets);
            this.Controls.Add(this.StocksList);
            this.Controls.Add(this.lblVisitors);
            this.Controls.Add(this.VisitorsList);
            this.Controls.Add(this.MoneyLogList);
            this.Name = "Form1";
            this.Text = "Admin panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MoneyLogList;
        private System.Windows.Forms.ListBox VisitorsList;
        private System.Windows.Forms.Label lblVisitors;
        private System.Windows.Forms.ListBox StocksList;
        private System.Windows.Forms.Label lblTickets;
        private System.Windows.Forms.Label lblprofit;
        private System.Windows.Forms.Label lblsold;
        private System.Windows.Forms.Button btnRefresh;
    }
}

