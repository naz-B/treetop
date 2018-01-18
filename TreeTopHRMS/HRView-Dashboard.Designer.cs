namespace TreeTopHRMS
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
            this.tabform = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRequestedLeavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRequestedOvertimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOvertimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateAllowancesDeductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabform
            // 
            this.tabform.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabform.Location = new System.Drawing.Point(12, 124);
            this.tabform.Name = "tabform";
            this.tabform.SelectedIndex = 0;
            this.tabform.Size = new System.Drawing.Size(899, 425);
            this.tabform.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabform.TabIndex = 0;
            this.tabform.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabform_DrawItem);
            this.tabform.SelectedIndexChanged += new System.EventHandler(this.tabform_SelectedIndexChanged);
            this.tabform.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabform_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(654, 22);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "user, designation";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(852, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkLabel1.Size = new System.Drawing.Size(53, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "logout";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.leavesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salaryToolStripMenuItem,
            this.notificationToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.switchViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(12, 50);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(771, 41);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(98, 33);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem,
            this.addNewEmployeeToolStripMenuItem});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(97, 33);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.viewAllToolStripMenuItem.Text = "View All";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.viewAllToolStripMenuItem_Click_1);
            // 
            // addNewEmployeeToolStripMenuItem
            // 
            this.addNewEmployeeToolStripMenuItem.Name = "addNewEmployeeToolStripMenuItem";
            this.addNewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addNewEmployeeToolStripMenuItem.Text = "Add New Employee";
            this.addNewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addNewEmployeeToolStripMenuItem_Click);
            // 
            // leavesToolStripMenuItem
            // 
            this.leavesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRequestedLeavesToolStripMenuItem,
            this.viewLeaveToolStripMenuItem});
            this.leavesToolStripMenuItem.Name = "leavesToolStripMenuItem";
            this.leavesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.leavesToolStripMenuItem.Size = new System.Drawing.Size(69, 33);
            this.leavesToolStripMenuItem.Text = "Leaves";
            // 
            // viewRequestedLeavesToolStripMenuItem
            // 
            this.viewRequestedLeavesToolStripMenuItem.Name = "viewRequestedLeavesToolStripMenuItem";
            this.viewRequestedLeavesToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.viewRequestedLeavesToolStripMenuItem.Text = "View Requested Leaves";
            this.viewRequestedLeavesToolStripMenuItem.Click += new System.EventHandler(this.viewRequestedLeavesToolStripMenuItem_Click);
            // 
            // viewLeaveToolStripMenuItem
            // 
            this.viewLeaveToolStripMenuItem.Name = "viewLeaveToolStripMenuItem";
            this.viewLeaveToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.viewLeaveToolStripMenuItem.Text = "View Leave";
            this.viewLeaveToolStripMenuItem.Click += new System.EventHandler(this.viewLeaveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRequestedOvertimeToolStripMenuItem,
            this.viewOvertimeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 33);
            this.toolStripMenuItem1.Text = "Overtime";
            // 
            // viewRequestedOvertimeToolStripMenuItem
            // 
            this.viewRequestedOvertimeToolStripMenuItem.Name = "viewRequestedOvertimeToolStripMenuItem";
            this.viewRequestedOvertimeToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.viewRequestedOvertimeToolStripMenuItem.Text = "View Requested Overtime";
            this.viewRequestedOvertimeToolStripMenuItem.Click += new System.EventHandler(this.viewRequestedOvertimeToolStripMenuItem_Click);
            // 
            // viewOvertimeToolStripMenuItem
            // 
            this.viewOvertimeToolStripMenuItem.Name = "viewOvertimeToolStripMenuItem";
            this.viewOvertimeToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.viewOvertimeToolStripMenuItem.Text = "View Overtime";
            this.viewOvertimeToolStripMenuItem.Click += new System.EventHandler(this.viewOvertimeToolStripMenuItem_Click);
            // 
            // notificationToolStripMenuItem
            // 
            this.notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
            this.notificationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.notificationToolStripMenuItem.Size = new System.Drawing.Size(103, 33);
            this.notificationToolStripMenuItem.Text = "Notification";
            this.notificationToolStripMenuItem.Click += new System.EventHandler(this.notificationToolStripMenuItem_Click);
            // 
            // salaryToolStripMenuItem
            // 
            this.salaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateSalaryToolStripMenuItem,
            this.updateSalaryToolStripMenuItem,
            this.generateAllowancesDeductionsToolStripMenuItem});
            this.salaryToolStripMenuItem.Name = "salaryToolStripMenuItem";
            this.salaryToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.salaryToolStripMenuItem.Size = new System.Drawing.Size(121, 33);
            this.salaryToolStripMenuItem.Text = "Remuneration";
            // 
            // generateSalaryToolStripMenuItem
            // 
            this.generateSalaryToolStripMenuItem.Name = "generateSalaryToolStripMenuItem";
            this.generateSalaryToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.generateSalaryToolStripMenuItem.Text = "Generate Salary";
            this.generateSalaryToolStripMenuItem.Click += new System.EventHandler(this.generateSalaryToolStripMenuItem_Click);
            // 
            // updateSalaryToolStripMenuItem
            // 
            this.updateSalaryToolStripMenuItem.Name = "updateSalaryToolStripMenuItem";
            this.updateSalaryToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.updateSalaryToolStripMenuItem.Text = "Update Salary";
            this.updateSalaryToolStripMenuItem.Click += new System.EventHandler(this.updateSalaryToolStripMenuItem_Click);
            // 
            // generateAllowancesDeductionsToolStripMenuItem
            // 
            this.generateAllowancesDeductionsToolStripMenuItem.Name = "generateAllowancesDeductionsToolStripMenuItem";
            this.generateAllowancesDeductionsToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.generateAllowancesDeductionsToolStripMenuItem.Text = "Generate Allowances/Deductions";
            this.generateAllowancesDeductionsToolStripMenuItem.Click += new System.EventHandler(this.generateAllowancesDeductionsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(76, 33);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // switchViewToolStripMenuItem
            // 
            this.switchViewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.switchViewToolStripMenuItem.Name = "switchViewToolStripMenuItem";
            this.switchViewToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.switchViewToolStripMenuItem.Size = new System.Drawing.Size(106, 33);
            this.switchViewToolStripMenuItem.Text = "Switch View";
            this.switchViewToolStripMenuItem.Click += new System.EventHandler(this.switchViewToolStripMenuItem_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(745, 98);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(157, 20);
            this.search.TabIndex = 5;
            this.search.Text = "Search";
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.Enter += new System.EventHandler(this.tabPage1_Click);
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            this.search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.search_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(923, 561);
            this.Controls.Add(this.search);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabform);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TreeTop HRMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leavesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRequestedLeavesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewRequestedOvertimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOvertimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchViewToolStripMenuItem;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ToolStripMenuItem updateSalaryToolStripMenuItem;
        public System.Windows.Forms.TabControl tabform;
        private System.Windows.Forms.ToolStripMenuItem generateAllowancesDeductionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLeaveToolStripMenuItem;
    }
}

