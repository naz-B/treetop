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
    public partial class EmpView_InnerDashboard : Form
    {
        public EmpView_InnerDashboard()
        {
            InitializeComponent();
        }

        private void EmpView_InnerDashboard_Load(object sender, EventArgs e)
        {
            var t1 = new Task(() => loadLeaveView());
            var t2 = new Task(() => loadRequestView());
            var t3 = new Task(() => loadNotices());

            
                t1.Start();
                t2.Start();
                t3.Start();
           
          

        }

        private void loadLeaveView()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                //reference to DBConnect class
                DBConnect db = new DBConnect();


            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Applied Date";
            dataGridView1.Columns[1].Name = "Start Date";
            dataGridView1.Columns[2].Name = "End Date";
            dataGridView1.Columns[3].Name = "Leave Type";
            dataGridView1.Columns[4].Name = "Status";

            int empID = 0;
            string username = LoginInfo.username;
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

                string query4 = "Select Date, fromDay, toDay, type, status from leaves where empID = " + empID + ""; // set query to fetch data 
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
                    dataGridView1.Rows.Add(row.ToArray());

                }



                //setting the cell click event
                dataGridView1.CellClick += new DataGridViewCellEventHandler(updateClickEvent);


            }
            }));
        }

        private void loadRequestView()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                //reference to DBConnect class
                DBConnect db = new DBConnect();


            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = "Applied Date";
            dataGridView2.Columns[1].Name = "Request Type";
            dataGridView2.Columns[2].Name = "Reason";
            dataGridView2.Columns[3].Name = "Status";

            int empID = 0;
            string username = LoginInfo.username;
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

                string query4 = "Select datetime, type, reason, status from request where empID = " + empID + ""; // set query to fetch data 
                MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    ArrayList row = new ArrayList();
                    row.Add(reader4.GetDateTime(0));
                    row.Add(reader4.GetString(1));
                    row.Add(reader4.GetString(2));
                    row.Add(reader4.GetString(3));
                    dataGridView2.Rows.Add(row.ToArray());
                }
                

                //setting the cell click event
                dataGridView2.CellClick += new DataGridViewCellEventHandler(updateClickEvent);


            }
            }));
        }

        public void updateClickEvent(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadNotices()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                textBox1.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        }));
        }
    }
}
