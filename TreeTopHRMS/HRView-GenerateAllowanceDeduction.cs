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
    public partial class HRView_GenerateAllowanceDeduction : Form
    {
        public HRView_GenerateAllowanceDeduction()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void HRView_GenerateAllowanceDeduction_Load(object sender, EventArgs e)
        {
            populateEmpBox();
            remType.Items.Add("Allowance");
            remType.Items.Add("Deduction");
            descrComboBox.Visible = false;
            descr.Visible = true;
        }

        private void populateEmpBox()
        {
            DBConnect db = new DBConnect();
            string query2 = "Select Distinct Name from Employee"; // set query to fetch data 

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

        private void select_Click(object sender, EventArgs e)
        {
            string employee = (string)empSelect.SelectedItem;
            string type = (string)remType.SelectedItem;
            double amounts = 0;
            string description;
            string description1 = descr.Text;
            string description2 = (string)descrComboBox.SelectedItem;
            if (string.IsNullOrWhiteSpace(descr.Text))
            {
                description = description2;
            }

            else
            {
                description = description1;
            }
            //validate amount textbox
            if (string.IsNullOrWhiteSpace(amount.Text) || System.Text.RegularExpressions.Regex.IsMatch(amount.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid amount",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
            //validate type combobox
            else if (string.IsNullOrEmpty(remType.Text) || (remType.SelectedIndex == -1)){
                MessageBox.Show("Please select a type",
                   "Type Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(empSelect.Text) || (empSelect.SelectedIndex == -1))
            {
                MessageBox.Show("Please select an employee",
                   "Employee Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (type.Equals("Allowance"))
            {
                if (string.IsNullOrEmpty(descrComboBox.Text) || (descrComboBox.SelectedIndex == -1))
                {
                    MessageBox.Show("Please select a description",
                       "Description Not Selected", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
            else if (type.Equals("Deduction"))
            {
                if (string.IsNullOrWhiteSpace(descr.Text))
                {
                    MessageBox.Show("Please enter a valid description",
                        "Invalid Description", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                amounts = Double.Parse(amount.Text);
                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "Employee";
                dataGridView1.Columns[1].Name = "Type";
                dataGridView1.Columns[2].Name = "Description";
                dataGridView1.Columns[3].Name = "Amount";

                ArrayList row = new ArrayList();
                row.Add(employee);
                row.Add(type);
                row.Add(description);
                row.Add(amounts);
                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            try
            {

                Parallel.ForEach(dataGridView1.Rows.OfType<System.Windows.Forms.DataGridViewRow>(), 
                (DataGridViewRow row) =>
                // foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string employee = (string)row.Cells["Employee"].Value;
                    string type = (string)row.Cells["Type"].Value;
                    string description = (string)row.Cells["Description"].Value;
                    double amounts = (double)row.Cells["Amount"].Value;
                    int empID = db.getEmpID(employee);
                    string status = "current";
                    if (type.Equals("Allowance"))
                    {
                        db.addEmpSalary(empID, description, amounts, status);
                    }
                    else
                    {
                        db.addDeduction(empID, description, amounts, status);
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

        private void empSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void remType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = (string)remType.SelectedItem;
            if (type.Equals("Allowance"))
            {
                descr.Visible = false;
                descrComboBox.Visible = true;
                descrComboBox.Items.Add("Risk Allowance");
                descrComboBox.Items.Add("Food Allowance");
                descrComboBox.Items.Add("Accomodation Allowance");
                descrComboBox.Items.Add("Annual Bonus");
            }
            else if (remType.Equals("Deduction"))
            {
                descrComboBox.Visible = false;
                descr.Visible = true;
            }
        }
    }
}
