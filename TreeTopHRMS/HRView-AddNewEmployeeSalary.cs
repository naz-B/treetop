using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class HRView_AddNewEmployeeSalary : Form
    {
        public HRView_AddNewEmployeeSalary()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void HRView_AddNewEmployeeSalary_Load(object sender, EventArgs e)
        {
            LoadDepartment();
            populateListBoxes();
        }

        //fetch department names from database and load into the combobox
        private void LoadDepartment()
        {
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            string query = "Select Distinct Name from Department"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                   department.Items.Add("" + reader.GetString(0));
                }
                reader.Close();
            }
            db.CloseConnection();

        }

        //populate the listboxes: allowances and leaves
        private void populateListBoxes()
        {
            allowances.Items.Add("Risk Allowance");
            allowances.Items.Add("Travel Allowance");
            allowances.Items.Add("Food Allowance");
            allowances.Items.Add("Accomodation Allowance");
            leaves.Items.Add("Annual Leave");
            leaves.Items.Add("Medical Leave");
            leaves.Items.Add("Emergency Leave");
        }

        private void department_SelectedValueChanged(object sender, EventArgs e)
        {
            //get selected department
            string dept = department.Text;
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            string query = "Select Distinct Designation from Department where name ='"+dept+"'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    designation.Items.Add("" + reader.GetString(0));
                }
            }
        }

        //fetch user inputs and add to database
        private void addEmployee_Click(object sender, EventArgs e)
        {
            //get user inputs
            string dept = department.Text;
            string desig = designation.Text;
            double sal = Double.Parse(salary.Text);
            if (string.IsNullOrEmpty(department.Text) || (department.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a department",
                   "Department Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(designation.Text) || (designation.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a designation",
                   "Designation Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(salary.Text) || System.Text.RegularExpressions.Regex.IsMatch(salary.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid salary",
                    "Invalid Salary", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {


                string status = "current";
                //get user inputs from checklists
                List<string> allowance = new List<string>();
                allowance = allowances.CheckedItems.OfType<string>().ToList();
                List<string> leave = new List<string>();
                leave = leaves.CheckedItems.OfType<string>().ToList();
                //database class reference
                DBConnect db = new DBConnect();
                //previous form reference
                HRView_AddNewEmployee previous = new HRView_AddNewEmployee();
                int empID = db.getLastEmpID();
                //update employee record with department and designation
                if (db.updateEmployee(empID, dept, desig))
                {
                    //add employees basic salary
                    db.addEmpSalary(empID, "basic salary", sal, status);

                    //add employees allowances
                    for (int i = 0; i < allowance.Count(); i++)
                    {
                        string type = allowance[i];
                        double amount = 1000;
                        db.addEmpSalary(empID, type, amount, status);
                    }
                    //add employees leaves
                    for (int i = 0; i < leave.Count; i++)
                    {
                        string type = leave[i];
                        string status1 = "initial";
                        int balance;
                        //determine the leave balance according to leave type
                        if (type.Equals("Emergency Leave"))
                        {
                            balance = 10;
                        }
                        else
                        {
                            balance = 30;
                        }
                        db.addEmpLeave(empID, type, "", "", balance, status1);
                    }

                }
            }
        }
    }
}
