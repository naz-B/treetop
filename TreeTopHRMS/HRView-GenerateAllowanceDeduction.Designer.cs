namespace TreeTopHRMS
{
    partial class HRView_GenerateAllowanceDeduction
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.remType = new System.Windows.Forms.ComboBox();
            this.select = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.TextBox();
            this.empSelect = new System.Windows.Forms.ComboBox();
            this.descr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            this.descrComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Type";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Select Employee";
            // 
            // remType
            // 
            this.remType.FormattingEnabled = true;
            this.remType.Location = new System.Drawing.Point(375, 90);
            this.remType.Name = "remType";
            this.remType.Size = new System.Drawing.Size(180, 21);
            this.remType.TabIndex = 17;
            this.remType.SelectedIndexChanged += new System.EventHandler(this.remType_SelectedIndexChanged);
            // 
            // select
            // 
            this.select.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select.Location = new System.Drawing.Point(341, 201);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 15;
            this.select.Text = "Add";
            this.select.UseVisualStyleBackColor = false;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(375, 163);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(180, 20);
            this.amount.TabIndex = 14;
            // 
            // empSelect
            // 
            this.empSelect.FormattingEnabled = true;
            this.empSelect.Location = new System.Drawing.Point(375, 54);
            this.empSelect.Name = "empSelect";
            this.empSelect.Size = new System.Drawing.Size(180, 21);
            this.empSelect.TabIndex = 13;
            this.empSelect.SelectedIndexChanged += new System.EventHandler(this.empSelect_SelectedIndexChanged);
            // 
            // descr
            // 
            this.descr.Location = new System.Drawing.Point(375, 128);
            this.descr.Name = "descr";
            this.descr.Size = new System.Drawing.Size(180, 20);
            this.descr.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Description";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(875, 101);
            this.dataGridView1.TabIndex = 24;
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Location = new System.Drawing.Point(341, 374);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 25;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // descrComboBox
            // 
            this.descrComboBox.FormattingEnabled = true;
            this.descrComboBox.Location = new System.Drawing.Point(375, 127);
            this.descrComboBox.Name = "descrComboBox";
            this.descrComboBox.Size = new System.Drawing.Size(180, 21);
            this.descrComboBox.TabIndex = 26;
            // 
            // HRView_GenerateAllowanceDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.descrComboBox);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remType);
            this.Controls.Add(this.select);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.empSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HRView_GenerateAllowanceDeduction";
            this.Text = "HRView_GenerateAllowanceDeduction";
            this.Load += new System.EventHandler(this.HRView_GenerateAllowanceDeduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox remType;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.ComboBox empSelect;
        private System.Windows.Forms.TextBox descr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.ComboBox descrComboBox;
    }
}