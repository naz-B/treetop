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
    public partial class HRView_AddNewEmployee : Form
    {
        public int empID;
        public HRView_AddNewEmployee()
        {
            InitializeComponent();
        }

        private void HRView_AddNewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void nextEmployee_Click(object sender, EventArgs e)
        {
            //get the user inputs
            int NIC = Int32.Parse(nic.Text);
            string ename = name.Text;
            string eaddress = address.Text;
            int econtact = Int32.Parse(contactno.Text);
            string edob = dob.Value.ToString("yyyy-MM-dd");
            string edoj = doj.Value.ToString("yyyy-MM-dd");
            string email = emails.Text;
            if (string.IsNullOrWhiteSpace(name.Text) || System.Text.RegularExpressions.Regex.IsMatch(name.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Please enter a valid name",
                    "Invalid Name", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(address.Text))
            {
                MessageBox.Show("Please enter a valid address",
                    "Invalid Address", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(contactno.Text) || System.Text.RegularExpressions.Regex.IsMatch(contactno.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid contact no",
                    "Invalid Contact No", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                //reference to DBConnect class
                DBConnect db = new DBConnect();

                empID = db.InsertEmployee(ename, NIC, eaddress, econtact, edob, edoj, email);
                HRView_AddNewEmployeeSalary addsal = new HRView_AddNewEmployeeSalary();
                addsal.Show();
                MessageBox.Show(empID.ToString(),
                        "Invalid Username or Password", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        

    }
}
