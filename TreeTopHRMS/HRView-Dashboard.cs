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
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            label2.Text = LoginInfo.username + ", " + LoginInfo.usertype;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_ViewEmployee viewEmp = new HRView_ViewEmployee();
            TabPage tabpage = new TabPage();
            tabpage.Text = "View Employees";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            viewEmp.TopLevel = false;
            viewEmp.Parent = tabpage;
            viewEmp.Show();
            this.tabform.SelectedTab = tabpage;
            viewEmp.Dock = DockStyle.Fill;
        }

        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_AddNewEmployee addEmp = new HRView_AddNewEmployee();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Add Employee";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            addEmp.TopLevel = false;
            addEmp.Parent = tabpage;
            addEmp.Show();
            this.tabform.SelectedTab = tabpage;
            addEmp.Dock = DockStyle.Fill;
        }

        private void viewRequestedLeavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_RequestedLeaves reqLeaves = new HRView_RequestedLeaves();
            TabPage tabpage = new TabPage();
            tabpage.Text = "View Requested Leave";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            reqLeaves.TopLevel = false;
            reqLeaves.Parent = tabpage;
            reqLeaves.Show();
            this.tabform.SelectedTab = tabpage;
            reqLeaves.Dock = DockStyle.Fill;
        }

        private void viewRequestedOvertimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRequestedOvertime reqOT = new ViewRequestedOvertime();
            TabPage tabpage = new TabPage();
            tabpage.Text = "View Requested Overtime";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            reqOT.TopLevel = false;
            reqOT.Parent = tabpage;
            reqOT.Show();
            this.tabform.SelectedTab = tabpage;
            reqOT.Dock = DockStyle.Fill;
        }

        private void addSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_AddSalary addRemunuration = new HRView_AddSalary();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Add Salary";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            addRemunuration.TopLevel = false;
            addRemunuration.Parent = tabpage;
            addRemunuration.Show();
            this.tabform.SelectedTab = tabpage;
            addRemunuration.Dock = DockStyle.Fill;
        }

        private void generateSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_GenerateSalary generateSal = new HRView_GenerateSalary();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Generate Salary";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            generateSal.TopLevel = false;
            generateSal.Parent = tabpage;
            generateSal.Show();
            this.tabform.SelectedTab = tabpage;
            generateSal.Dock = DockStyle.Fill;
        }

        public void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_Notification notification = new HRView_Notification();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Notifcation";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            notification.TopLevel = false;
            notification.Parent = tabpage;
            notification.Show();
            this.tabform.SelectedTab = tabpage;
            notification.Dock = DockStyle.Fill;
        }

        private void viewAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HRView_ViewEmployee viewEmp = new HRView_ViewEmployee();
            TabPage tabpage = new TabPage();
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabpage.Text = "View Employees";
            tabform.TabPages.Add(tabpage);
            viewEmp.TopLevel = false;
            viewEmp.Parent = tabpage;
            viewEmp.Show();
            viewEmp.Focus();
            this.tabform.SelectedTab = tabpage;
            viewEmp.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
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

        public void nextEmpClick()
        {
            HRView_AddNewEmployeeSalary addEmpSal = new HRView_AddNewEmployeeSalary();
            TabPage tabpage = new TabPage();
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            tabpage.Text = "Add Employee Salary";
            addEmpSal.TopLevel = false;
            addEmpSal.Parent = tabpage;
            addEmpSal.Show();
            addEmpSal.Focus();
            this.tabform.SelectedTab = tabpage;
            addEmpSal.Dock = DockStyle.Fill;
        }

        private void tabform_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabform_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("X", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabform.TabPages[e.Index].Text, e.Font, 
                Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabform_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabform.TabPages.Count; i++)
            {
                Rectangle r = tabform.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabform.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // menuStrip1.BackColor = Color.AliceBlue;
            tabform.Padding = new System.Drawing.Point(21, 5);
            HRView_InnerDashboard dash = new HRView_InnerDashboard();
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

        private void updateSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_AddSalary updateSalary = new HRView_AddSalary();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Update Salary";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            updateSalary.TopLevel = false;
            updateSalary.Parent = tabpage;
            updateSalary.Show();
            updateSalary.Focus();
            updateSalary.Dock = DockStyle.Fill;
            this.tabform.SelectedTab = tabpage;
        }

        private void search_Enter(object sender, EventArgs e)
        {
           
        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string query = search.Text;
                HRView_Search srch = new HRView_Search();
                
                if (srch.viewSearch(query))
                {
                    TabPage tabpage = new TabPage();
                    tabpage.Text = "Search Result";
                    tabpage.BorderStyle = BorderStyle.Fixed3D;
                    tabform.TabPages.Add(tabpage);
                    srch.TopLevel = false;
                    srch.Parent = tabpage;
                    srch.Show();
                    srch.Focus();
                    this.tabform.SelectedTab = tabpage;
                    srch.Dock = DockStyle.Fill;
                }
            }
            
        }

        private void switchViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string usernameT = LoginInfo.username;
            LoginInfo.usertype = db.checkUserDesignation(usernameT);
            EmpView_Dashboard dashboard = new EmpView_Dashboard();
            //Form1 HRDashboard = new Form1();
            this.Hide();
            dashboard.Show();
            dashboard.Focus();

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_Report report = new HRView_Report();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Report";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            report.TopLevel = false;
            report.Parent = tabpage;
            report.Show();
            report.Focus();
            this.tabform.SelectedTab = tabpage;
            report.Dock = DockStyle.Fill;
        }

        private void search_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewOvertimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_ViewStaffOvertime overtime = new HRView_ViewStaffOvertime();
            TabPage tabpage = new TabPage();
            tabpage.Text = "View Overtime";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            overtime.TopLevel = false;
            overtime.Parent = tabpage;
            overtime.Show();
            overtime.Focus();
            this.tabform.SelectedTab = tabpage;
            overtime.Dock = DockStyle.Fill;
        }

        private void generateAllowancesDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_GenerateAllowanceDeduction allowancededuction = new HRView_GenerateAllowanceDeduction();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Add Allowance/Deduction";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            allowancededuction.TopLevel = false;
            allowancededuction.Parent = tabpage;
            allowancededuction.Show();
            allowancededuction.Focus();
            this.tabform.SelectedTab = tabpage;
            allowancededuction.Dock = DockStyle.Fill;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HRView_ViewStaffLeave leaves = new HRView_ViewStaffLeave();
            TabPage tabpage = new TabPage();
            tabpage.Text = "Add Allowance/Deduction";
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            leaves.TopLevel = false;
            leaves.Parent = tabpage;
            leaves.Show();
            leaves.Focus();
            this.tabform.SelectedTab = tabpage;
            leaves.Dock = DockStyle.Fill;
        }
    }
}
