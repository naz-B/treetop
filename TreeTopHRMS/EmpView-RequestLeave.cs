using MySql.Data.MySqlClient;
using System;
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
    public partial class EmpView_RequestLeave : Form
    {
        public EmpView_RequestLeave()
        {
            InitializeComponent();
        }

        private void populateList()
        {
            leaveType.Items.Add("Annual");
            leaveType.Items.Add("Medical");
            leaveType.Items.Add("Emergency");
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string type = leaveType.Text;
            string from = leaveFrom.Value.ToString("yyyy-MM-dd");
            string to = leaveTo.Value.ToString("yyyy-MM-dd");
            string reason = purpose.Text;
            if (string.IsNullOrEmpty(leaveType.Text) || (leaveType.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a type",
                   "Type Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(purpose.Text))
            {
                MessageBox.Show("Please enter a reason",
                   "Reason not entered", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else
            {
                DBConnect db = new DBConnect();
                string username = LoginInfo.username;
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
                }
                db.CloseConnection();

                db.requestLeave(empID, type, from, to, reason);
                this.Close();

            }
        }

        private void EmpView_RequestLeave_Load(object sender, EventArgs e)
        {
            populateList();
        }
    }
}
