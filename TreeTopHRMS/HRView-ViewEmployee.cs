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
    public partial class HRView_ViewEmployee : Form
    {
        public HRView_ViewEmployee()
        {
            InitializeComponent();
        }

        private void HRView_ViewEmployee_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "Select * from employee"; // set query to fetch data 
            if (db.OpenConnection() == true)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
