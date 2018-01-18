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
    public partial class HRView_AddSalary : Form
    {
        public HRView_AddSalary()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HRView_AddSalary_Load(object sender, EventArgs e)
        {
            populateDesignation();
            populateRemuneration();
        }

        //populate comboboxes: designation and employees
        private void populateDesignation()
        {
            //----------populate designation combobox------------

            desigSelect.Items.Add("All");
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            string query = "Select Distinct Designation from Employee"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    //add to the combobox
                    desigSelect.Items.Add("" + reader.GetString(0));
                }
                //close reader
                reader.Close();
                //-------------populate employee combobox--------------
                
            }
            //close connection
            db.CloseConnection();
           
        }

        //populate remuneration combobox
        private void populateRemuneration()
        {
            remType.Items.Add("Basic Salary");
            remType.Items.Add("Risk Allowance");
            remType.Items.Add("Food Allowance");
            remType.Items.Add("Accomodation Allowance");
            remType.Items.Add("Annual Bonus");
        }

        private void select_Click(object sender, EventArgs e)
        {
            string designation = (string)desigSelect.SelectedItem;
            string employee = (string)empSelect.SelectedItem;
            string type = (string)remType.SelectedItem;
            double amnt = Double.Parse(amount.Text);
            List<string> employeeList = new List<string>();
            if (string.IsNullOrEmpty(desigSelect.Text) || (desigSelect.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a designation",
                   "Designation Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(empSelect.Text) || (empSelect.SelectedIndex == -1))
            {
                MessageBox.Show("Please select an employee",
                   "Employee Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(remType.Text) || (remType.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a type",
                   "Type Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(amount.Text) || System.Text.RegularExpressions.Regex.IsMatch(amount.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid amount",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (employee.Equals("All"))
                {

                    //reference to dbconnect class
                    DBConnect db = new DBConnect();
                    string query = "Select Distinct Name from Employee where designation = '" + designation + "'"; // set query to fetch data 
                    if (db.OpenConnection() == true)
                    {
                        //Create Command
                        MySqlCommand cmd = new MySqlCommand(query, db.connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Read the data and store them
                        while (reader.Read())
                        {
                            //add to the combobox
                            employeeList.Add("" + reader.GetString(0));
                        }
                        //close reader
                        reader.Close();
                    }
                    db.CloseConnection();
                }
                //method call to populate the grid view
                populateGridView(designation, employee, employeeList, amnt, type);
            }
        }

        //populate the grid view
        private void populateGridView(string designation, string employee, List<string> empList, double amount, string type)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Employee";
            dataGridView1.Columns[1].Name = "Designation";
            dataGridView1.Columns[2].Name = "Type";
            dataGridView1.Columns[3].Name = "Amount";

            //if only one employee
            if (empList.Count == 0)
            {
                ArrayList row = new ArrayList();
                //add employee name
                row.Add(employee);
                row.Add(designation);
                row.Add(type);
                row.Add(amount);
                dataGridView1.Rows.Add(row.ToArray());
            }
            else if(empList.Count != 0)
            {
                for(int i = 0; i < empList.Count; i++)
                {
                    ArrayList row = new ArrayList();
                    row.Add(empList[i]);
                    row.Add(designation);
                    row.Add(type);
                    row.Add(amount);
                    dataGridView1.Rows.Add(row.ToArray());
                }
            }
            
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            try
            {

                Parallel.ForEach(dataGridView1.Rows.OfType<System.Windows.Forms.DataGridViewRow>(), (DataGridViewRow row) =>
                // foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    string employee = (string)row.Cells["Employee"].Value;
                    int empID = db.getEmpID(employee);

                    //change salary status from previous database record
                    string status = "expired";


                    string type = Convert.ToString(row.Cells["Type"].Value);
                    double amount = Convert.ToDouble(row.Cells["Amount"].Value);
                    db.changeSalStatus(empID, status, type);
                    db.updateeSal(empID, amount, type);

                });
            }
            catch (AggregateException ex)
            {
                foreach (Exception innerEx in ex.InnerExceptions)
                {
                    MessageBox.Show("Error" + ex.Message, "Some title",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }

        
        }

        private void desigSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            empSelect.Items.Clear();
            string selectedValue = desigSelect.SelectedItem as string;
            empSelect.Items.Add("All");
            DBConnect db = new DBConnect();
            string query2;
            //-------------populate employee combobox--------------
            if (selectedValue.Equals("All"))
            {
                query2 = "Select Distinct Name from Employee"; // set query to fetch data 

            }
            else
            {
                query2 = "Select Distinct Name from Employee where designation = '" + selectedValue + "'"; // set query to fetch data 

            }
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                //Read the data and store them
                while (reader2.Read())
                {
                    //add to the combobox
                    empSelect.Items.Add("" + reader2.GetString(0));
                }
                //close reader
                reader2.Close();
            }
            //close connection
            db.CloseConnection();
        }
    }
}
