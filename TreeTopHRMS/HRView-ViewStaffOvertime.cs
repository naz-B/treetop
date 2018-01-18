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
    public partial class HRView_ViewStaffOvertime : Form
    {
        double Totalallowance;
        TimeSpan totalDuration;
        string empName;

        public HRView_ViewStaffOvertime()
        {
            InitializeComponent();
        }

        private void HRView_ViewStaffOvertime_Load(object sender, EventArgs e)
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


            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Start Time";
            dataGridView1.Columns[1].Name = "End Time";
            dataGridView1.Columns[2].Name = "Duration";
            dataGridView1.Columns[3].Name = "Amount";
            dataGridView1.Columns[4].Name = "Description";
            dataGridView1.Columns[5].Name = "Status";
            dataGridView1.Columns[6].Name = "ID";
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

                string query4 = "Select startTime, endTime, descr, status, overtimeID from overtime where empID = " + empID + ""; // set query to fetch data 
                MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    ArrayList row = new ArrayList();
                    row.Add(reader4.GetDateTime(0));
                    row.Add(reader4.GetDateTime(1));
                    TimeSpan duration = reader4.GetDateTime(1) - reader4.GetDateTime(0);
                    totalDuration += duration;

                    row.Add(duration);
                    double allowance = duration.TotalHours * 369;
                    Totalallowance += allowance;
                    row.Add(allowance);

                    row.Add(reader4.GetString(2));
                    row.Add(reader4.GetString(3));
                    row.Add(reader4.GetString(4));
                    dataGridView1.Columns[6].Visible = false;
                    //Button btn = new Button();
                    

                    dataGridView1.Rows.Add(row.ToArray());


                    

                }

                //setting the total duration and allowances
                setDurationAllowance(totalDuration, Totalallowance);
                

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
            int ID = Convert.ToInt32(grdview.Rows[e.RowIndex].Cells[6].Value);

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7))
            {
                
               if (grdview != null)
                {
                    //get the new data given by user
                    string newDescr = Convert.ToString(grdview.Rows[e.RowIndex].Cells[4].Value);
                    DateTime newStartTime = Convert.ToDateTime(grdview.Rows[e.RowIndex].Cells[0].Value);
                    string newStartTimeS = newStartTime.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime newEndTime = Convert.ToDateTime(grdview.Rows[e.RowIndex].Cells[1].Value);
                    string newEndTimeS = newEndTime.ToString("yyyy-MM-dd HH:mm:ss");

                    
                    
                    //call the method from DBConnect class
                    var t1 = new Task(() => db.updateOvertime(newDescr, ID, newStartTimeS, newEndTimeS));
                    var t2 = new Task(() => setDurationAllowance(totalDuration, Totalallowance));
                    var t3 = new Task(() => refresh());

                    t1.Start();
                    t2.Start();
                    t3.Start();
                    //Task.WaitAll(t1, t2, t3);
                    //refresh();
                    MessageBox.Show("Entry Successfully updated", "Update Successfull", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex.Equals(8))
            {
                if (grdview != null)
                {
                    if (MessageBox.Show("Would you like to delete this entry?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //call the method from DBConnect class
                        var t1 = new Task(() => db.deleteOvertime(ID));
                        var t2 = new Task(() => setDurationAllowance(totalDuration, Totalallowance));
                        var t3 = new Task(() => refresh());

                        t1.Start();
                        t2.Start();
                        t3.Start();

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

        //sets the duration and allowances label
        public void setDurationAllowance(TimeSpan duration, double allowance)
        {
            double sumDuration = 0;
            double sumAmount = 0;
            sumDuration += duration.TotalHours;
            sumAmount += allowance;
            Invoke(new MethodInvoker(delegate ()
            {
                totalOThrs.Text += sumDuration;
            }));
            Invoke(new MethodInvoker(delegate ()
            {
                label2.Text += allowance;

            }));

            
        }
    }
}
