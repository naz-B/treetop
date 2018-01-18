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
    public partial class EmpView_Roster : Form
    {
        public EmpView_Roster()
        {
            InitializeComponent();
        }

        private void EmpView_Roster_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            int empID = getEmpID();
            string query = "Select * from duty where empID = " + empID + ""; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        

                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    db.CloseConnection();
                }
            }
            
        }

        public int getEmpID()
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
            return empID;
        }
    }
}
