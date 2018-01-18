using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeTopHRMS
{
    public partial class EmpView_Dashboard : Form
    {
        public EmpView_Dashboard()
        {
            InitializeComponent();
            label2.Text = LoginInfo.username + ", " + LoginInfo.usertype;
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void applyForLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmpView_Overtime ot = new EmpView_Overtime();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Overtime";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            ot.TopLevel = false;
            ot.Parent = tabpage;
            ot.Show();
            this.tabform.SelectedTab = tabpage;
            ot.Dock = DockStyle.Fill;
        }

        private void viewLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpView_ViewLeave viewLeave = new EmpView_ViewLeave();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Leave";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            viewLeave.TopLevel = false;
            viewLeave.Parent = tabpage;
            viewLeave.Show();
            this.tabform.SelectedTab = tabpage;
            viewLeave.Dock = DockStyle.Fill;
        }

        private void requestLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpView_RequestLeave requestLeave = new EmpView_RequestLeave();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Request Leave";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            requestLeave.TopLevel = false;
            requestLeave.Parent = tabpage;
            requestLeave.Show();
            this.tabform.SelectedTab = tabpage;
            requestLeave.Dock = DockStyle.Fill;
        }

        private void viewAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpView_ViewAttendance viewAttendance = new EmpView_ViewAttendance();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Attendance";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            viewAttendance.TopLevel = false;
            viewAttendance.Parent = tabpage;
            viewAttendance.Show();
            this.tabform.SelectedTab = tabpage;
            viewAttendance.Dock = DockStyle.Fill;
        }

        private void requestInOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpView_RequestInOut inOut = new EmpView_RequestInOut();
            TabPage tabpage = new TabPage();
            tabpage.Text = "In/Out";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            inOut.TopLevel = false;
            inOut.Parent = tabpage;
            inOut.Show();
            this.tabform.SelectedTab = tabpage;
            inOut.Dock = DockStyle.Fill;
        }

        private void EmpView_Dashboard_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.AliceBlue;
            tabform.Padding = new System.Drawing.Point(21, 5);
            EmpView_InnerDashboard dash = new EmpView_InnerDashboard();
            TabPage tabpage = new TabPage();
            tabpage.BorderStyle = BorderStyle.None;
            tabform.TabPages.Add(tabpage);
            tabpage.Text = "Dashboard";
            dash.TopLevel = false;
            dash.Parent = tabpage;
            dash.Show();
            dash.Focus();
            dash.Dock = DockStyle.None;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            LoginInfo.username = null;
            LoginInfo.usertype = null;
            this.Hide();
            login.Show();
            login.Focus();
        }

        private void viewRosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpView_Roster duty = new EmpView_Roster();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Duty Roster";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            duty.TopLevel = false;
            duty.Parent = tabpage;
            duty.Show();
            this.tabform.SelectedTab = tabpage;
            duty.Dock = DockStyle.Fill;
        }
    }
}
