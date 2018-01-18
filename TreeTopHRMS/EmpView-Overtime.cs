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
    public partial class EmpView_Overtime : Form
    {

        double Totalallowance;
        TimeSpan totalDuration;

        public EmpView_Overtime()
        {
            InitializeComponent();
        }

        private void EmpView_Overtime_Load(object sender, EventArgs e)
        {
            populateGridView();
        }

        private void populateGridView()
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

            String username = LoginInfo.username;
            int empID = 0;
            string query = "Select empID from user where username = '" + username + "'"; // set query to fetch data 
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

                string query4 = "Select startTime, endTime, descr, status, overtimeID from overtime where empID = " + empID +""; // set query to fetch data 
                MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    ArrayList row = new ArrayList();
                    row.Add(reader4.GetDateTime(0));
                    row.Add(reader4.GetDateTime(1));
                    TimeSpan duration = reader4.GetDateTime(1) - reader4.GetDateTime(0);
                    row.Add(duration);
                    totalDuration += duration;
                    double allowance = duration.TotalHours * 369;
                    row.Add(allowance);
                    Totalallowance += allowance;
                    row.Add(reader4.GetString(2));
                    row.Add(reader4.GetString(3));
                    row.Add(reader4.GetString(4));
                    dataGridView1.Columns[6].Visible = false;
                    //Button btn = new Button();
                    //row.Add(btn);

                    dataGridView1.Rows.Add(row.ToArray());
                    //adding the update button column
                    DataGridViewButtonColumn dbtn = new DataGridViewButtonColumn();
                    dbtn.HeaderText = "Update";
                    dbtn.Text = "Update";
                    dbtn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(dbtn);

                    
                    //making the columns readonly except for description column
                    for(int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[2].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[3].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[5].ReadOnly = true;

                    }

                    //setting the total duration and allowances
                    setDurationAllowance(duration, allowance);

                    //setting the cell click event
                    dataGridView1.CellClick += new DataGridViewCellEventHandler(updateClickEvent);

                }

                

            }
            

        }

        public void updateClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7))
            {
                DBConnect db = new DBConnect();
                EmpView_Dashboard dashboard = new EmpView_Dashboard();

                DataGridView grdview = sender as DataGridView;
                if (grdview != null)
                {
                    //get the new description given by user
                    string newDescr = Convert.ToString(grdview.Rows[e.RowIndex].Cells[4].Value);
                    //get ID of the entry
                    int ID = Convert.ToInt32(grdview.Rows[e.RowIndex].Cells[6].Value);
                    //call the method from DBConnect class
                   // db.updateOvertimeDesc(newDescr, ID);
                    var t1 = new Task(() => db.updateOvertimeDesc(newDescr, ID));
                    var t2 = new Task(() => setDurationAllowance(totalDuration, Totalallowance));
                    
                    t1.Start();
                    t2.Start();
                    
                }
            }
        }

        public void refresh()
        {
            EmpView_Overtime ot = new EmpView_Overtime();
            Invoke(new MethodInvoker(delegate ()
            {
                this.Refresh();
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
