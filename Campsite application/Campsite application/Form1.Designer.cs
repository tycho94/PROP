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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.panelcampspot = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnAddDelete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Campsite)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelcampspot.SuspendLayout();
            this.SuspendLayout();
            // 
            // Campsite
            // 
            this.Campsite.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Campsite.Image = ((System.Drawing.Image)(resources.GetObject("Campsite.Image")));
            this.Campsite.Location = new System.Drawing.Point(433, -3);
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
            this.lbFreeSites.Size = new System.Drawing.Size(167, 290);
            this.lbFreeSites.TabIndex = 28;
            this.lbFreeSites.SelectedIndexChanged += new System.EventHandler(this.lbFreeSites_SelectedIndexChanged);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(7, 302);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(75, 13);
            this.lblCost.TabIndex = 30;
            this.lblCost.Text = "Cost per night:";
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
            this.reserveBtn.Click += new System.EventHandler(this.reserveBtn_Click);
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
            this.panel1.Controls.Add(this.lblCost);
            this.panel1.Location = new System.Drawing.Point(206, 13);
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
            this.panel2.Location = new System.Drawing.Point(13, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 144);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "Status";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Red;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(672, 256);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(16, 18);
            this.lbl1.TabIndex = 36;
            this.lbl1.Text = "1";
            this.lbl1.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Red;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(672, 237);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(16, 18);
            this.lbl2.TabIndex = 40;
            this.lbl2.Text = "2";
            this.lbl2.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.Color.Red;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(672, 217);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(16, 18);
            this.lbl3.TabIndex = 41;
            this.lbl3.Text = "3";
            this.lbl3.Visible = false;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.Color.Red;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(672, 192);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(16, 18);
            this.lbl4.TabIndex = 42;
            this.lbl4.Text = "4";
            this.lbl4.Visible = false;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.Color.Red;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(684, 192);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(16, 18);
            this.lbl5.TabIndex = 43;
            this.lbl5.Text = "5";
            this.lbl5.Visible = false;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.BackColor = System.Drawing.Color.Red;
            this.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(706, 192);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(16, 18);
            this.lbl6.TabIndex = 44;
            this.lbl6.Text = "6";
            this.lbl6.Visible = false;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.Color.Red;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(728, 192);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(16, 18);
            this.lbl7.TabIndex = 45;
            this.lbl7.Text = "7";
            this.lbl7.Visible = false;
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.Color.Red;
            this.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.Location = new System.Drawing.Point(761, 192);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(16, 18);
            this.lbl8.TabIndex = 46;
            this.lbl8.Text = "8";
            this.lbl8.Visible = false;
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.Color.Red;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.Location = new System.Drawing.Point(806, 192);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(16, 18);
            this.lbl9.TabIndex = 47;
            this.lbl9.Text = "9";
            this.lbl9.Visible = false;
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.BackColor = System.Drawing.Color.Red;
            this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.Location = new System.Drawing.Point(798, 210);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(24, 18);
            this.lbl10.TabIndex = 48;
            this.lbl10.Text = "10";
            this.lbl10.Visible = false;
            // 
            // panelcampspot
            // 
            this.panelcampspot.BackColor = System.Drawing.Color.LightCoral;
            this.panelcampspot.Controls.Add(this.btnAddDelete);
            this.panelcampspot.Controls.Add(this.btnContinue);
            this.panelcampspot.Controls.Add(this.label9);
            this.panelcampspot.Controls.Add(this.label8);
            this.panelcampspot.Controls.Add(this.label7);
            this.panelcampspot.Controls.Add(this.label5);
            this.panelcampspot.Controls.Add(this.lblSecond);
            this.panelcampspot.Controls.Add(this.lblFirst);
            this.panelcampspot.Controls.Add(this.label4);
            this.panelcampspot.Location = new System.Drawing.Point(12, 344);
            this.panelcampspot.Name = "panelcampspot";
            this.panelcampspot.Size = new System.Drawing.Size(382, 210);
            this.panelcampspot.TabIndex = 37;
            this.panelcampspot.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Add/remove someone to your campspot";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(10, 135);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(41, 13);
            this.lblFirst.TabIndex = 34;
            this.lblFirst.Text = "Name: ";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(235, 135);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(41, 13);
            this.lblSecond.TabIndex = 35;
            this.lblSecond.Text = "Name: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "1. Scan camper RFID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "2. Press Continue";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "3. Scan acquaintance RFID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "4. Press Add";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(5, 174);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 40;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnAddDelete
            // 
            this.btnAddDelete.Location = new System.Drawing.Point(238, 174);
            this.btnAddDelete.Name = "btnAddDelete";
            this.btnAddDelete.Size = new System.Drawing.Size(75, 23);
            this.btnAddDelete.TabIndex = 41;
            this.btnAddDelete.Text = "Add (max 3)";
            this.btnAddDelete.UseVisualStyleBackColor = true;
            this.btnAddDelete.Visible = false;
            this.btnAddDelete.Click += new System.EventHandler(this.btnAddDelete_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 580);
            this.Controls.Add(this.panelcampspot);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.statusStrip1);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelcampspot.ResumeLayout(false);
            this.panelcampspot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Campsite;
        private System.Windows.Forms.ListBox lbFreeSites;
        private System.Windows.Forms.Label lblCost;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Panel panelcampspot;
        private System.Windows.Forms.Button btnAddDelete;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

