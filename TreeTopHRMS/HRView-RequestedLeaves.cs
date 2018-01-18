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
    public partial class HRView_RequestedLeaves : Form
    {
        TimeSpan duration;
        public HRView_RequestedLeaves()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HRView_RequestedLeaves_Load(object sender, EventArgs e)
        {
            //reference to DBConnect class
            DBConnect db = new DBConnect();
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Employee ID";
            dataGridView1.Columns[1].Name = "Date";
            dataGridView1.Columns[2].Name = "Start Date";
            dataGridView1.Columns[3].Name = "End Date";
            dataGridView1.Columns[4].Name = "Duration";
            dataGridView1.Columns[5].Name = "Type";
            dataGridView1.Columns[6].Name = "Balance";
            dataGridView1.Columns[7].Name = "Status";
            dataGridView1.Columns[8].Name = "ID";

            if (db.OpenConnection() == true)
            {
                
                string query4 = "Select empID, Date, fromDay, toDay, type, balance, status, leaveID from leaves where status = 'N'"; // set query to fetch data 
                MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    ArrayList row = new ArrayList();
                    row.Add(reader4.GetInt16(0));
                    row.Add(reader4.GetDateTime(1).Date.ToString("dd/MM/yyyy"));
                    row.Add(reader4.GetDateTime(2).Date.ToString("dd/MM/yyyy"));
                    row.Add(reader4.GetDateTime(3).Date.ToString("dd/MM/yyyy"));
                    duration = reader4.GetDateTime(2) - reader4.GetDateTime(1);
                    row.Add(duration.Days);
                    row.Add(reader4.GetString(4));
                    row.Add(reader4.GetInt16(5));
                    row.Add(reader4.GetString(6));
                    row.Add(reader4.GetInt16(7));
                    dataGridView1.Columns[8].Visible = false;
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
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(9))
            {
                DBConnect db = new DBConnect();
                EmpView_Dashboard dashboard = new EmpView_Dashboard();

                DataGridView grdview = sender as DataGridView;
                if (grdview != null)
                {
                    //get the new data given by user
                    string newStatus = Convert.ToString(grdview.Rows[e.RowIndex].Cells[7].Value);
                    int empID = Convert.ToInt32(grdview.Rows[e.RowIndex].Cells[0].Value);
                    int ID = Convert.ToInt32(grdview.Rows[e.RowIndex].Cells[8].Value);
                    string type = Convert.ToString(grdview.Rows[e.RowIndex].Cells[5].Value);
                    string[] tokens = type.Split(':');
                    string newtype = tokens[0];
                    if (newStatus.Equals("A") || newStatus.Equals("R"))
                    {
                        // call the method from DBConnect class
                        db.updateStatus(newStatus, ID, "leaves", "leaveID");
                        if(newStatus.Equals("A"))
                        db.updateLeaveBal(empID, newtype + " Leave", duration);
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
