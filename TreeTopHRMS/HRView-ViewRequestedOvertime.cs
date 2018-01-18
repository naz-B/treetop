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
    public partial class ViewRequestedOvertime : Form
    {
        public ViewRequestedOvertime()
        {
            InitializeComponent();
        }

        private void ViewRequestedOvertime_Load(object sender, EventArgs e)
        {
            //reference to DBConnect class
            DBConnect db = new DBConnect();


            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Employee ID";
            dataGridView1.Columns[1].Name = "Start Time";
            dataGridView1.Columns[2].Name = "End Time";
            dataGridView1.Columns[3].Name = "Duration";
            dataGridView1.Columns[4].Name = "Amount";
            dataGridView1.Columns[5].Name = "Description";
            dataGridView1.Columns[6].Name = "Status";
            dataGridView1.Columns[7].Name = "ID";

            if (db.OpenConnection() == true)
            {
                

                string query4 = "Select empID, startTime, endTime, descr, status, " +
                    "overtimeID from overtime where status = 'N'";  
                MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    ArrayList row = new ArrayList();
                    row.Add(reader4.GetInt16(0));
                    row.Add(reader4.GetDateTime(1));
                    row.Add(reader4.GetDateTime(2));
                    TimeSpan duration = reader4.GetDateTime(2) - reader4.GetDateTime(1);
                    row.Add(duration);
                    double allowance = duration.TotalHours * 369;
                    row.Add(allowance);

                    row.Add(reader4.GetString(3));
                    row.Add(reader4.GetString(4));
                    row.Add(reader4.GetString(5));
                    dataGridView1.Columns[7].Visible = false;
                    //Button btn = new Button();
                    //row.Add(btn);

                    dataGridView1.Rows.Add(row.ToArray());




                }

                //adding the update button column
                DataGridViewButtonColumn dbtn = new DataGridViewButtonColumn();
                dbtn.HeaderText = "Update";
                dbtn.Text = "Update";
                dbtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(dbtn);

                //setting the cell click event
                dataGridView1.CellClick += new DataGridViewCellEventHandler(updateClickEvent);

            }
            }

            public void updateClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(8))
            {
                DBConnect db = new DBConnect();
                EmpView_Dashboard dashboard = new EmpView_Dashboard();

                DataGridView grdview = sender as DataGridView;
                if (grdview != null)
                {
                    //get the new data given by user
                    string newStatus = Convert.ToString(grdview.Rows[e.RowIndex].Cells[6].Value);
                    int ID = Convert.ToInt32(grdview.Rows[e.RowIndex].Cells[7].Value);
                    if (newStatus.Equals("A") || newStatus.Equals("R"))
                    {
                       // call the method from DBConnect class
                        db.updateStatus(newStatus, ID, "overtime", "overtimeID");
    }
                    else
                    {
                        //if the new status is not valid
                        MessageBox.Show("Please re-enter a status. Help: R - Reject. A - Approve",
                        "Invalid status", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }


                }
            }
        }
    }
}
