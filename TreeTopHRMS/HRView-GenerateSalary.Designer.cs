namespace TreeTopHRMS
{
    partial class HRView_GenerateSalary
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
            this.deptSelect = new System.Windows.Forms.ComboBox();
            this.empSelect = new System.Windows.Forms.ComboBox();
            this.generateSalary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // deptSelect
            // 
            this.deptSelect.FormattingEnabled = true;
            this.deptSelect.Location = new System.Drawing.Point(339, 39);
            this.deptSelect.Name = "deptSelect";
            this.deptSelect.Size = new System.Drawing.Size(197, 21);
            this.deptSelect.TabIndex = 1;
            this.deptSelect.Text = "Select Department";
            this.deptSelect.SelectedIndexChanged += new System.EventHandler(this.deptSelect_SelectedIndexChanged);
            // 
            // empSelect
            // 
            this.empSelect.FormattingEnabled = true;
            this.empSelect.Location = new System.Drawing.Point(339, 84);
            this.empSelect.Name = "empSelect";
            this.empSelect.Size = new System.Drawing.Size(197, 21);
            this.empSelect.TabIndex = 2;
            this.empSelect.Text = "Select Employee";
            // 
            // generateSalary
            // 
            this.generateSalary.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.generateSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateSalary.Location = new System.Drawing.Point(393, 128);
            this.generateSalary.Name = "generateSalary";
            this.generateSalary.Size = new System.Drawing.Size(75, 23);
            this.generateSalary.TabIndex = 3;
            this.generateSalary.Text = "Generate";
            this.generateSalary.UseVisualStyleBackColor = false;
            this.generateSalary.Click += new System.EventHandler(this.generateSalary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selection";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 165);
            this.dataGridView1.TabIndex = 5;
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Location = new System.Drawing.Point(393, 390);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 6;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // HRView_GenerateSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generateSalary);
            this.Controls.Add(this.empSelect);
            this.Controls.Add(this.deptSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HRView_GenerateSalary";
            this.Text = "HRView_GenerateSalary";
            this.Load += new System.EventHandler(this.HRView_GenerateSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox deptSelect;
        private System.Windows.Forms.ComboBox empSelect;
        private System.Windows.Forms.Button generateSalary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button confirm;
    }
}