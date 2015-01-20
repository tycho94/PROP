namespace Rental_App
{
    partial class Return
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
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(55, 23);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(206, 147);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(115, 186);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(55, 224);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(0, 13);
            this.lblShow.TabIndex = 2;
            // 
            // Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 338);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lbItems);
            this.Name = "Return";
            this.Text = "Return";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Return_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Return_FormClosed);
            this.Load += new System.EventHandler(this.Return_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblShow;
    }
}