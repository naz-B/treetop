namespace TreeTopHRMS
{
    partial class HRView_AddNewEmployeeSalary
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
            this.label1 = new System.Windows.Forms.Label();
            this.addEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.designation = new System.Windows.Forms.ComboBox();
            this.allowances = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.leaves = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.salary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Employee";
            // 
            // addEmployee
            // 
            this.addEmployee.Location = new System.Drawing.Point(230, 403);
            this.addEmployee.Name = "addEmployee";
            this.addEmployee.Size = new System.Drawing.Size(75, 23);
            this.addEmployee.TabIndex = 10;
            this.addEmployee.Text = "Add";
            this.addEmployee.UseVisualStyleBackColor = true;
            this.addEmployee.Click += new System.EventHandler(this.addEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Designation";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // department
            // 
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(368, 67);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(207, 21);
            this.department.TabIndex = 13;
            this.department.SelectedValueChanged += new System.EventHandler(this.department_SelectedValueChanged);
            // 
            // designation
            // 
            this.designation.FormattingEnabled = true;
            this.designation.Location = new System.Drawing.Point(368, 106);
            this.designation.Name = "designation";
            this.designation.Size = new System.Drawing.Size(207, 21);
            this.designation.TabIndex = 14;
            // 
            // allowances
            // 
            this.allowances.FormattingEnabled = true;
            this.allowances.Location = new System.Drawing.Point(368, 194);
            this.allowances.Name = "allowances";
            this.allowances.Size = new System.Drawing.Size(207, 49);
            this.allowances.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Allowances";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Leaves";
            // 
            // leaves
            // 
            this.leaves.FormattingEnabled = true;
            this.leaves.Location = new System.Drawing.Point(368, 271);
            this.leaves.Name = "leaves";
            this.leaves.Size = new System.Drawing.Size(207, 49);
            this.leaves.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Salary";
            // 
            // salary
            // 
            this.salary.Location = new System.Drawing.Point(368, 147);
            this.salary.Name = "salary";
            this.salary.Size = new System.Drawing.Size(207, 20);
            this.salary.TabIndex = 22;
            // 
            // HRView_AddNewEmployeeSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.salary);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.leaves);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.allowances);
            this.Controls.Add(this.designation);
            this.Controls.Add(this.department);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addEmployee);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HRView_AddNewEmployeeSalary";
            this.Text = "HRView_AddNewEmployeeSalary";
            this.Load += new System.EventHandler(this.HRView_AddNewEmployeeSalary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.ComboBox designation;
        private System.Windows.Forms.CheckedListBox allowances;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox leaves;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox salary;
    }
}