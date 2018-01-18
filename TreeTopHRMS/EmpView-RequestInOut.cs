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
    public partial class EmpView_RequestInOut : Form
    {
        public EmpView_RequestInOut()
        {
            InitializeComponent();
        }

        private void EmpView_RequestInOut_Load(object sender, EventArgs e)
        {
            populateTypeList();
            date.CustomFormat = "yyyy-MM-dd hh:mm:ss";
        }
        
        //to populate the combo box with types
        private void populateTypeList()
        {
            type.Items.Add("Fail to Sign In");
            type.Items.Add("Fail to Sign Out");

        }

        private void submit_Click(object sender, EventArgs e)
        {
            string typed = type.Text;
            string dates = date.Value.ToString("yyyy-MM-dd h:mm:ss");
            string reasons = reason.Text;
            if (string.IsNullOrEmpty(type.Text) || (type.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a type",
                   "Type Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(reason.Text))
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

                db.requestInOut(empID, typed, dates, reasons);

            }
        }
    }
}
