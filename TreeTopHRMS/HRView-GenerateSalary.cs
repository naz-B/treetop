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
    public partial class HRView_GenerateSalary : Form
    {
        public HRView_GenerateSalary()
        {
            InitializeComponent();
        }

        private void HRView_GenerateSalary_Load(object sender, EventArgs e)
        {
            populateDepartmentEmployees();
        }

        //populate comboboxes: department and employees
        private void populateDepartmentEmployees()
        {
            //----------populate department combobox------------
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            deptSelect.Items.Add("All");
            string query = "Select Distinct Department from Employee"; // set query to fetch data 
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
                    deptSelect.Items.Add("" + reader.GetString(0));
                }
                //close reader
                reader.Close();


            }
            //close connection
            db.CloseConnection();

        }


        private void deptSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            empSelect.Items.Clear();
            string selectedValue = deptSelect.SelectedItem as string;
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
                query2 = "Select Distinct Name from Employee where department = '" + selectedValue + "'"; // set query to fetch data 

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

        private void generateSalary_Click(object sender, EventArgs e)
        {
            //fetch user inputs
            string department = deptSelect.SelectedText;
            string employee = (string)empSelect.SelectedItem;
            List<string> empList = new List<string>();
            if (string.IsNullOrEmpty(deptSelect.Text) || (deptSelect.SelectedIndex == -1))
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
            else
            {
                if (employee.Equals("All"))
                {
                    //reference to dbconnect class
                    DBConnect db = new DBConnect();
                    string query = "Select Distinct Name from Employee"; // set query to fetch data 
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
                            empList.Add("" + reader.GetString(0));
                        }
                        //close reader
                        reader.Close();
                    }
                    db.CloseConnection();
                }


                populateGridView(employee, empList);
            }
        }

        private void populateGridView(string employee, List<string> empList)
        {
            //variable to hold the employee ID
            int empID = 0;
            //variable to hold the net salary
            double netSal = 0;
            //reference to DBConnect class
            DBConnect db = new DBConnect();

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Employee";
            dataGridView1.Columns[1].Name = "Designation";
            dataGridView1.Columns[2].Name = "Basic Salary";
            dataGridView1.Columns[3].Name = "Allowance";
            dataGridView1.Columns[4].Name = "Deduction";
            dataGridView1.Columns[5].Name = "Net Salary";



            if (empList.Count == 0)
            {
                ArrayList row = new ArrayList();
                //add employee name
                row.Add(employee);

                string query = "Select Designation, empID from Employee where name = '" + employee + "'"; // set query to fetch data 
                if (db.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string designation = "";
                    //Read the data and store them
                    while (reader.Read())
                    {
                        designation = "" + reader.GetString(0);
                    }

                    //add designation
                    row.Add(designation);
                    empID = reader.GetInt32(1);

                    //close reader
                    reader.Close();

                    string query2 = "Select Amount from salary where empID = " + empID + " " +
                        "and type = 'basic salary' and status = 'current'";  
                    MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                    MySqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        //add basic salary
                        row.Add(reader2.GetDouble(0));
                        netSal = reader2.GetDouble(0);
                    }
                    reader2.Close();

                    string query3 = "Select Amount from salary where empID = " + empID + " and type " +
                        "like '%Allowance%' and status ='current'"; // set query to fetch data 
                    MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
                    MySqlDataReader reader3 = cmd3.ExecuteReader();
                    double allowance = 0;
                    while (reader3.Read())
                    {
                        //add allowance

                        allowance += reader3.GetDouble(0);

                    }
                    row.Add(allowance);
                    netSal += allowance;
                    reader3.Close();

                    string query4 = "Select Amount from deduction where empID = " + empID + " and " +
                        "status = 'current'"; // set query to fetch data 
                    MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                    MySqlDataReader reader4 = cmd4.ExecuteReader();
                    double deduction = 0;
                    while (reader4.Read())
                    {
                        deduction += reader4.GetDouble(0);
                    }
                    //adding deduction
                    row.Add(deduction);
                    netSal -= deduction;
                    reader4.Close();

                    //show net salary
                    row.Add(netSal);

                    dataGridView1.Rows.Add(row.ToArray());
                }
            }
            else if (empList.Count != 0)
            {
                if (db.OpenConnection() == true)
                {
                    Parallel.For(0, empList.Count, i =>
                    //for (int i = 0; i < empList.Count; i++)
                    {
                        ArrayList row = new ArrayList();
                        //add employee name
                        row.Add(empList[i]);


                        string query = "Select Designation, empID from Employee where name = '" + empList[i] + "'"; // set query to fetch data 

                        //Create Command
                        MySqlCommand cmd = new MySqlCommand(query, db.connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader reader = cmd.ExecuteReader();

                        string designation = "";
                        //Read the data and store them
                        while (reader.Read())
                        {
                            designation = "" + reader.GetString(0);
                        }

                        //add designation
                        row.Add(designation);
                        empID = reader.GetInt32(1);


                        //close reader
                        reader.Close();

                        string query2 = "Select Amount from salary where empID = " + empID + " and type = 'basic salary' and status = 'current'"; // set query to fetch data 
                        MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                        MySqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            //add basic salary
                            row.Add(reader2.GetDouble(0));
                            netSal = reader2.GetDouble(0);
                        }
                        reader2.Close();

                        string query3 = "Select Amount from salary where empID = " + empID + " and type like '%Allowance%' and status ='current'"; // set query to fetch data 
                        MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
                        MySqlDataReader reader3 = cmd3.ExecuteReader();
                        double allowance = 0;
                        while (reader3.Read())
                        {
                            //add allowance

                            allowance += reader3.GetDouble(0);

                        }
                        row.Add(allowance);
                        netSal += allowance;
                        reader3.Close();

                        string query4 = "Select Amount from deduction where empID = " + empID + " and status = 'current'"; // set query to fetch data 
                        MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                        MySqlDataReader reader4 = cmd4.ExecuteReader();
                        double deduction = 0;
                        while (reader4.Read())
                        {
                            deduction += reader4.GetDouble(0);
                        }
                        //adding deduction
                        row.Add(deduction);
                        netSal -= deduction;
                        reader4.Close();

                        //show net salary
                        row.Add(netSal);

                        dataGridView1.Rows.Add(row.ToArray());

                    });

                }
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            dataGridView1.AllowUserToAddRows = false;
            try { 
             
            Parallel.ForEach(dataGridView1.Rows.OfType<System.Windows.Forms.DataGridViewRow>(), (DataGridViewRow row) =>

            //foreach (DataGridViewRow row in dataGridView1.Rows)
             {
             string employee = (string)row.Cells["Employee"].Value;
              int empID = db.getEmpID(employee);
            //DateTime date = new DateTime();
           // string date1 = DateTime.Now.ToString("yyyy-MM-dd");
                 int payrollNo = 21;// db.getLastPayrollNo() + 1;
                 double basicSal = Convert.ToDouble(row.Cells["Basic Salary"].Value);
                 double allowance = Convert.ToDouble(row.Cells["Allowance"].Value);
                 double deduction = Convert.ToDouble(row.Cells["Deduction"].Value);
                 double netSal = Convert.ToDouble(row.Cells["Net Salary"].Value);
                 if(db.generateSal(empID, basicSal, allowance, deduction, netSal))
                 {
                     DialogResult result = MessageBox.Show("Would you like to generate notification?", 
                     "Successfull Salary Generation",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if(result == System.Windows.Forms.DialogResult.Yes)
                     {
                         Form1 dashboard = new Form1();
                         HRView_Notification notification = new HRView_Notification();
                         TabPage tabpage = new TabPage();
                         tabpage.Text = "Notifcation";
                         tabpage.BorderStyle = BorderStyle.Fixed3D;
                         dashboard.tabform.TabPages.Add(tabpage);
                         notification.TopLevel = false;
                         notification.Parent = tabpage;
                         notification.Show();
                         notification.Dock = DockStyle.Fill;
                     }
                 }
                 
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
    }
}
