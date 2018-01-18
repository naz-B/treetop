namespace TreeTopHRMS
{
    partial class HRView_InnerDashboard
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
            this.Overtime = new System.Windows.Forms.ListBox();
            this.Leave = new System.Windows.Forms.ListBox();
            this.InOut = new System.Windows.Forms.ListBox();
            this.Roster = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Overtime
            // 
            this.Overtime.BackColor = System.Drawing.Color.MintCream;
            this.Overtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Overtime.FormattingEnabled = true;
            this.Overtime.Location = new System.Drawing.Point(70, 32);
            this.Overtime.Name = "Overtime";
            this.Overtime.Size = new System.Drawing.Size(255, 158);
            this.Overtime.TabIndex = 0;
            // 
            // Leave
            // 
            this.Leave.BackColor = System.Drawing.Color.MintCream;
            this.Leave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Leave.FormattingEnabled = true;
            this.Leave.Location = new System.Drawing.Point(423, 32);
            this.Leave.Name = "Leave";
            this.Leave.Size = new System.Drawing.Size(255, 158);
            this.Leave.TabIndex = 1;
            // 
            // InOut
            // 
            this.InOut.BackColor = System.Drawing.Color.MintCream;
            this.InOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InOut.FormattingEnabled = true;
            this.InOut.Location = new System.Drawing.Point(70, 224);
            this.InOut.Name = "InOut";
            this.InOut.Size = new System.Drawing.Size(255, 145);
            this.InOut.TabIndex = 2;
            // 
            // Roster
            // 
            this.Roster.BackColor = System.Drawing.Color.MintCream;
            this.Roster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Roster.FormattingEnabled = true;
            this.Roster.Location = new System.Drawing.Point(423, 224);
            this.Roster.Name = "Roster";
            this.Roster.Size = new System.Drawing.Size(255, 145);
            this.Roster.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Overtime To Approve";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(420, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Leave To Approve";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Request To Approve";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(420, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duty Roster To Approve";
            // 
            // HRView_InnerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Roster);
            this.Controls.Add(this.InOut);
            this.Controls.Add(this.Leave);
            this.Controls.Add(this.Overtime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HRView_InnerDashboard";
            this.Text = "HRView_InnerDashboard";
            this.Load += new System.EventHandler(this.HRView_InnerDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Overtime;
        private System.Windows.Forms.ListBox Leave;
        private System.Windows.Forms.ListBox InOut;
        private System.Windows.Forms.ListBox Roster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}