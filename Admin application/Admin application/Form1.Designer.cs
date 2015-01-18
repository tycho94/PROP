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
            this.VisitorsLabel = new System.Windows.Forms.Label();
            this.StocksList = new System.Windows.Forms.ListBox();
            this.StocksLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            // VisitorsLabel
            // 
            this.VisitorsLabel.AutoSize = true;
            this.VisitorsLabel.Location = new System.Drawing.Point(23, 231);
            this.VisitorsLabel.Name = "VisitorsLabel";
            this.VisitorsLabel.Size = new System.Drawing.Size(96, 13);
            this.VisitorsLabel.TabIndex = 3;
            this.VisitorsLabel.Text = "Amount Of Visitors:";
            // 
            // StocksList
            // 
            this.StocksList.FormattingEnabled = true;
            this.StocksList.Location = new System.Drawing.Point(510, 31);
            this.StocksList.Name = "StocksList";
            this.StocksList.Size = new System.Drawing.Size(200, 173);
            this.StocksList.TabIndex = 4;
            // 
            // StocksLabel
            // 
            this.StocksLabel.AutoSize = true;
            this.StocksLabel.Location = new System.Drawing.Point(507, 231);
            this.StocksLabel.Name = "StocksLabel";
            this.StocksLabel.Size = new System.Drawing.Size(109, 13);
            this.StocksLabel.TabIndex = 5;
            this.StocksLabel.Text = "Amount of stocks left:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total entered: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total left:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Estimate profit made:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(507, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total items sold:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total items returned(DOA):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 296);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StocksLabel);
            this.Controls.Add(this.StocksList);
            this.Controls.Add(this.VisitorsLabel);
            this.Controls.Add(this.VisitorsList);
            this.Controls.Add(this.MoneyLogList);
            this.Name = "Form1";
            this.Text = "Admin App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MoneyLogList;
        private System.Windows.Forms.ListBox VisitorsList;
        private System.Windows.Forms.Label VisitorsLabel;
        private System.Windows.Forms.ListBox StocksList;
        private System.Windows.Forms.Label StocksLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}

