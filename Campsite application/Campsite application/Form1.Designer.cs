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
            this.sitenrTb = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reserveBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FreeSiteslb = new System.Windows.Forms.ListBox();
            this.showBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Campsite)).BeginInit();
            this.SuspendLayout();
            // 
            // Campsite
            // 
            this.Campsite.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Campsite.Image = ((System.Drawing.Image)(resources.GetObject("Campsite.Image")));
            this.Campsite.Location = new System.Drawing.Point(199, 12);
            this.Campsite.Name = "Campsite";
            this.Campsite.Size = new System.Drawing.Size(761, 529);
            this.Campsite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Campsite.TabIndex = 0;
            this.Campsite.TabStop = false;
            // 
            // sitenrTb
            // 
            this.sitenrTb.Location = new System.Drawing.Point(12, 7);
            this.sitenrTb.Name = "sitenrTb";
            this.sitenrTb.Size = new System.Drawing.Size(82, 20);
            this.sitenrTb.TabIndex = 10;
            this.sitenrTb.Text = "SiteNumber";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(12, 33);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(159, 35);
            this.searchBtn.TabIndex = 11;
            this.searchBtn.Text = "Search on map";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "3. Click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Reserve a site:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "1. Scan RFID";
            // 
            // reserveBtn
            // 
            this.reserveBtn.Location = new System.Drawing.Point(12, 493);
            this.reserveBtn.Name = "reserveBtn";
            this.reserveBtn.Size = new System.Drawing.Size(159, 35);
            this.reserveBtn.TabIndex = 16;
            this.reserveBtn.Text = "Reserve!";
            this.reserveBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 466);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "2. Select site in the list";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cost per night:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Status:";
            // 
            // FreeSiteslb
            // 
            this.FreeSiteslb.FormattingEnabled = true;
            this.FreeSiteslb.Location = new System.Drawing.Point(12, 114);
            this.FreeSiteslb.Name = "FreeSiteslb";
            this.FreeSiteslb.ScrollAlwaysVisible = true;
            this.FreeSiteslb.Size = new System.Drawing.Size(167, 238);
            this.FreeSiteslb.TabIndex = 22;
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(12, 384);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(100, 20);
            this.showBtn.TabIndex = 21;
            this.showBtn.Text = "Show on map";
            this.showBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 553);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FreeSiteslb);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reserveBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.sitenrTb);
            this.Controls.Add(this.Campsite);
            this.Name = "Form1";
            this.Text = "Campsite Application";
            ((System.ComponentModel.ISupportInitialize)(this.Campsite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Campsite;
        private System.Windows.Forms.TextBox sitenrTb;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reserveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox FreeSiteslb;
        private System.Windows.Forms.Button showBtn;
    }
}

