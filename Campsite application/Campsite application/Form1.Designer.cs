namespace Campsite_application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Campsite = new System.Windows.Forms.PictureBox();
            this.lbFreeSites = new System.Windows.Forms.ListBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.reserveBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Campsite)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Campsite
            // 
            this.Campsite.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Campsite.Image = ((System.Drawing.Image)(resources.GetObject("Campsite.Image")));
            this.Campsite.Location = new System.Drawing.Point(252, -3);
            this.Campsite.Name = "Campsite";
            this.Campsite.Size = new System.Drawing.Size(656, 557);
            this.Campsite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Campsite.TabIndex = 0;
            this.Campsite.TabStop = false;
            // 
            // lbFreeSites
            // 
            this.lbFreeSites.FormattingEnabled = true;
            this.lbFreeSites.Location = new System.Drawing.Point(9, 3);
            this.lbFreeSites.Name = "lbFreeSites";
            this.lbFreeSites.ScrollAlwaysVisible = true;
            this.lbFreeSites.Size = new System.Drawing.Size(167, 264);
            this.lbFreeSites.TabIndex = 28;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(6, 300);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(75, 13);
            this.lblCost.TabIndex = 30;
            this.lblCost.Text = "Cost per night:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 287);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Reserve a site:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "2. Select site in the list";
            // 
            // reserveBtn
            // 
            this.reserveBtn.BackColor = System.Drawing.Color.LightGreen;
            this.reserveBtn.Location = new System.Drawing.Point(4, 62);
            this.reserveBtn.Name = "reserveBtn";
            this.reserveBtn.Size = new System.Drawing.Size(159, 35);
            this.reserveBtn.TabIndex = 31;
            this.reserveBtn.Text = "Reserve!";
            this.reserveBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "3. Click";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "1. Scan RFID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.lbFreeSites);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblCost);
            this.panel1.Location = new System.Drawing.Point(12, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 326);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.reserveBtn);
            this.panel2.Location = new System.Drawing.Point(12, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 98);
            this.panel2.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.lblSite);
            this.panel3.Controls.Add(this.lblMoney);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Location = new System.Drawing.Point(13, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 89);
            this.panel3.TabIndex = 38;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(5, 54);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(69, 13);
            this.lblSite.TabIndex = 33;
            this.lblSite.Text = "Site number: ";
            this.lblSite.Visible = false;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(5, 31);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(45, 13);
            this.lblMoney.TabIndex = 32;
            this.lblMoney.Text = "Money: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(5, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 31;
            this.lblName.Text = "Name: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 550);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Campsite);
            this.Name = "Form1";
            this.Text = "Campsite Application";
            ((System.ComponentModel.ISupportInitialize)(this.Campsite)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Campsite;
        private System.Windows.Forms.ListBox lbFreeSites;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button reserveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblName;
    }
}

