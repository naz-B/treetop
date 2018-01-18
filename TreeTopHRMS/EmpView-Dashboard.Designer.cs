namespace TreeTopHRMS
{
    partial class EmpView_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpView_Dashboard));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestInOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dutyRosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabform = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(870, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(51, 16);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "logout";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(721, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "user, designation";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.leavesToolStripMenuItem,
            this.attendanceToolStripMenuItem,
            this.toolStripMenuItem1,
            this.dutyRosterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 46);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(558, 29);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(98, 25);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // leavesToolStripMenuItem
            // 
            this.leavesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLeaveToolStripMenuItem,
            this.requestLeaveToolStripMenuItem});
            this.leavesToolStripMenuItem.Name = "leavesToolStripMenuItem";
            this.leavesToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
            this.leavesToolStripMenuItem.Text = "Leaves";
            // 
            // viewLeaveToolStripMenuItem
            // 
            this.viewLeaveToolStripMenuItem.Name = "viewLeaveToolStripMenuItem";
            this.viewLeaveToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.viewLeaveToolStripMenuItem.Text = "View Leave";
            this.viewLeaveToolStripMenuItem.Click += new System.EventHandler(this.viewLeaveToolStripMenuItem_Click);
            // 
            // requestLeaveToolStripMenuItem
            // 
            this.requestLeaveToolStripMenuItem.Name = "requestLeaveToolStripMenuItem";
            this.requestLeaveToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.requestLeaveToolStripMenuItem.Text = "Request Leave";
            this.requestLeaveToolStripMenuItem.Click += new System.EventHandler(this.requestLeaveToolStripMenuItem_Click);
            // 
            // attendanceToolStripMenuItem
            // 
            this.attendanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAttendanceToolStripMenuItem,
            this.requestInOutToolStripMenuItem});
            this.attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            this.attendanceToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.attendanceToolStripMenuItem.Text = "Attendance";
            // 
            // viewAttendanceToolStripMenuItem
            // 
            this.viewAttendanceToolStripMenuItem.Name = "viewAttendanceToolStripMenuItem";
            this.viewAttendanceToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.viewAttendanceToolStripMenuItem.Text = "View Attendance";
            this.viewAttendanceToolStripMenuItem.Click += new System.EventHandler(this.viewAttendanceToolStripMenuItem_Click);
            // 
            // requestInOutToolStripMenuItem
            // 
            this.requestInOutToolStripMenuItem.Name = "requestInOutToolStripMenuItem";
            this.requestInOutToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.requestInOutToolStripMenuItem.Text = "Request In/Out";
            this.requestInOutToolStripMenuItem.Click += new System.EventHandler(this.requestInOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 25);
            this.toolStripMenuItem1.Text = "Overtime";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dutyRosterToolStripMenuItem
            // 
            this.dutyRosterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRosterToolStripMenuItem,
            this.requestChangeToolStripMenuItem});
            this.dutyRosterToolStripMenuItem.Name = "dutyRosterToolStripMenuItem";
            this.dutyRosterToolStripMenuItem.Size = new System.Drawing.Size(104, 25);
            this.dutyRosterToolStripMenuItem.Text = "Duty Roster";
            // 
            // viewRosterToolStripMenuItem
            // 
            this.viewRosterToolStripMenuItem.Name = "viewRosterToolStripMenuItem";
            this.viewRosterToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.viewRosterToolStripMenuItem.Text = "View Roster";
            this.viewRosterToolStripMenuItem.Click += new System.EventHandler(this.viewRosterToolStripMenuItem_Click);
            // 
            // requestChangeToolStripMenuItem
            // 
            this.requestChangeToolStripMenuItem.Name = "requestChangeToolStripMenuItem";
            this.requestChangeToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.requestChangeToolStripMenuItem.Text = "Request Change";
            // 
            // tabform
            // 
            this.tabform.Location = new System.Drawing.Point(20, 124);
            this.tabform.Name = "tabform";
            this.tabform.SelectedIndex = 0;
            this.tabform.Size = new System.Drawing.Size(899, 425);
            this.tabform.TabIndex = 8;
            // 
            // EmpView_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(923, 561);
            this.Controls.Add(this.tabform);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmpView_Dashboard";
            this.Text = "EmpView_Dashboard";
            this.Load += new System.EventHandler(this.EmpView_Dashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem leavesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestInOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutyRosterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRosterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.TabControl tabform;
    }
}