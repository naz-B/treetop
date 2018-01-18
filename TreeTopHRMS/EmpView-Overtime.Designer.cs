namespace TreeTopHRMS
{
    partial class EmpView_Overtime
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
            this.period = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.totalOThrs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // period
            // 
            this.period.AutoSize = true;
            this.period.Location = new System.Drawing.Point(41, 32);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(40, 13);
            this.period.TabIndex = 1;
            this.period.Text = "Period:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(858, 265);
            this.dataGridView1.TabIndex = 2;
            // 
            // totalOThrs
            // 
            this.totalOThrs.AutoSize = true;
            this.totalOThrs.Location = new System.Drawing.Point(23, 362);
            this.totalOThrs.Name = "totalOThrs";
            this.totalOThrs.Size = new System.Drawing.Size(103, 13);
            this.totalOThrs.TabIndex = 3;
            this.totalOThrs.Text = "Total Overtime/Hrs :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Overtime  Allowance:";
            // 
            // EmpView_Overtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalOThrs);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.period);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmpView_Overtime";
            this.Text = "EmpView_Overtime";
            this.Load += new System.EventHandler(this.EmpView_Overtime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label period;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label totalOThrs;
        private System.Windows.Forms.Label label2;
    }
}