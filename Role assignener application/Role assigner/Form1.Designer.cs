namespace Role_assigner
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
            this.btAssign = new System.Windows.Forms.Button();
            this.roleDropdown = new System.Windows.Forms.ComboBox();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbEmpNr = new System.Windows.Forms.Label();
            this.lbDob = new System.Windows.Forms.Label();
            this.empNameDropdown = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAssign
            // 
            this.btAssign.Location = new System.Drawing.Point(32, 229);
            this.btAssign.Name = "btAssign";
            this.btAssign.Size = new System.Drawing.Size(121, 32);
            this.btAssign.TabIndex = 0;
            this.btAssign.Text = "Assign";
            this.btAssign.UseVisualStyleBackColor = true;
            this.btAssign.Click += new System.EventHandler(this.button1_Click);
            // 
            // roleDropdown
            // 
            this.roleDropdown.FormattingEnabled = true;
            this.roleDropdown.Location = new System.Drawing.Point(32, 183);
            this.roleDropdown.Name = "roleDropdown";
            this.roleDropdown.Size = new System.Drawing.Size(121, 21);
            this.roleDropdown.TabIndex = 1;
            this.roleDropdown.Text = "Select a role";
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Location = new System.Drawing.Point(29, 128);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(64, 13);
            this.lbRole.TabIndex = 2;
            this.lbRole.Text = "Current job: ";
            // 
            // lbEmpNr
            // 
            this.lbEmpNr.AutoSize = true;
            this.lbEmpNr.Location = new System.Drawing.Point(29, 79);
            this.lbEmpNr.Name = "lbEmpNr";
            this.lbEmpNr.Size = new System.Drawing.Size(69, 13);
            this.lbEmpNr.TabIndex = 6;
            this.lbEmpNr.Text = "Employee #: ";
            // 
            // lbDob
            // 
            this.lbDob.AutoSize = true;
            this.lbDob.Location = new System.Drawing.Point(29, 103);
            this.lbDob.Name = "lbDob";
            this.lbDob.Size = new System.Drawing.Size(33, 13);
            this.lbDob.TabIndex = 7;
            this.lbDob.Text = "DOB:";
            // 
            // empNameDropdown
            // 
            this.empNameDropdown.FormattingEnabled = true;
            this.empNameDropdown.Location = new System.Drawing.Point(32, 36);
            this.empNameDropdown.Name = "empNameDropdown";
            this.empNameDropdown.Size = new System.Drawing.Size(121, 21);
            this.empNameDropdown.TabIndex = 9;
            this.empNameDropdown.Text = "Select a employee";
            this.empNameDropdown.SelectedIndexChanged += new System.EventHandler(this.empNrDropdown_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(254, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 313);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.empNameDropdown);
            this.Controls.Add(this.lbDob);
            this.Controls.Add(this.lbEmpNr);
            this.Controls.Add(this.lbRole);
            this.Controls.Add(this.roleDropdown);
            this.Controls.Add(this.btAssign);
            this.Name = "Form1";
            this.Text = "Role Assigner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAssign;
        private System.Windows.Forms.ComboBox roleDropdown;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label lbEmpNr;
        private System.Windows.Forms.Label lbDob;
        private System.Windows.Forms.ComboBox empNameDropdown;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
    }
}

