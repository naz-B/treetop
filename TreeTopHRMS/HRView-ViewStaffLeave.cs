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
    public partial class HRView_ViewStaffLeave : Form
    {
        string empName;
        public HRView_ViewStaffLeave()
        {
            InitializeComponent();
        }

        private void HRView_ViewStaffLeave_Load(object sender, EventArgs e)
        {
            populateEmpComboBox();
        }
        private void populateEmpComboBox()
        {
            //----------populate employee name combobox------------
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            employee.Items.Add("All");
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
                    employee.Items.Add("" + reader.GetString(0));
                }
                //close reader
                reader.Close();

            }
            //close connection
            db.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empName = employee.SelectedItem.ToString();
            loadGrid();

        }

        private void loadGrid()
        {
            //reference to DBConnect class
            DBConnect db = new DBConnect();


            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Applied Date";
            dataGridView1.Columns[1].Name = "Start Day";
            dataGridView1.Columns[2].Name = "End Day";
            dataGridView1.Columns[3].Name = "Type";
            dataGridView1.Columns[4].Name = "Status";
            dataGridView1.Columns[5].Name = "ID";

            int empID = 0;
            string query = "Select empID from employee where name = '" + empName + "'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();


                //Read the data and store them
                while (reader.Read())
                {
                    empID = reader.GetInt16(0);
                }
                //close reader
                reader.Close();

                string query4 = "Select date, fromDay, toDay, type, status, leaveID from leaves where empID = " + empID + ""; // set query to fetch data 
                MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    ArrayList row = new ArrayList();
                    row.Add(reader4.GetDateTime(0));
                    row.Add(reader4.GetDateTime(1));
                    row.Add(reader4.GetDateTime(2));
                    row.Add(reader4.GetString(3));
                    row.Add(reader4.GetString(4));
                    row.Add(reader4.GetInt32(5));
                    dataGridView1.Columns[5].Visible = false;

                    dataGridView1.Rows.Add(row.ToArray());
                }

                //adding the update button column
                DataGridViewButtonColumn ubtn = new DataGridViewButtonColumn();
                ubtn.HeaderText = "Update";
                ubtn.Text = "Update";
                ubtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(ubtn);

                //adding the update button column
                DataGridViewButtonColumn dbtn = new DataGridViewButtonColumn();
                dbtn.HeaderText = "Delete";
                dbtn.Text = "Delete";
                dbtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(dbtn);

                //setting the cell click event
                dataGridView1.CellClick += new DataGridViewCellEventHandler(updateClickEvent);


            }
        }

        public void updateClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            DBConnect db = new DBConnect();
            DataGridView grdview = sender as DataGridView;

            //get ID of the entry
            int ID = Convert.ToInt32(grdview.Rows[e.RowIndex].Cells[5].Value);

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(6))
            {

                if (grdview != null)
                {
                    //get the new data given by user
                    string newtype = Convert.ToString(grdview.Rows[e.RowIndex].Cells[3].Value);
                    DateTime newStartDate = Convert.ToDateTime(grdview.Rows[e.RowIndex].Cells[1].Value);
                    string newStartDateS = newStartDate.ToString("yyyy-MM-dd");
                    DateTime newEndDate = Convert.ToDateTime(grdview.Rows[e.RowIndex].Cells[2].Value);
                    string newEndDateS = newEndDate.ToString("yyyy-MM-dd");


                    //call the method from DBConnect class
                    var t1 = new Task(() => db.updateLeave(newtype, ID, newStartDateS, newEndDateS));
                    var t2 = new Task(() => refresh());

                    t1.Start();
                    t2.Start();
                    //Task.WaitAll(t1, t2, t3);
                    //refresh();
                    MessageBox.Show("Entry Successfully updated", "Update Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex.Equals(7))
            {
                if (grdview != null)
                {
                    if (MessageBox.Show("Would you like to delete this entry?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //call the method from DBConnect class
                        var t1 = new Task(() => db.deleteLeave(ID));
                        var t2 = new Task(() => refresh());

                        t1.Start();
                        t2.Start();

                        MessageBox.Show("Entry Successfully Deleted", "Delete Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void refresh()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                loadGrid();
            }));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            empName = employee.SelectedItem.ToString();
            loadGrid();
        }
    }
}
