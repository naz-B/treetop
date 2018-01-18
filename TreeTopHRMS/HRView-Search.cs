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
    public partial class HRView_Search : Form
    {
        public HRView_Search()
        {
            InitializeComponent();
        }

        private void HRView_Search_Load(object sender, EventArgs e)
        {
            
            dataGridView1.CellClick += new DataGridViewCellEventHandler(CellClickEvent);
        }

        public void CellClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grdview = sender as DataGridView;
            if (grdview != null)
            {
                string empName = Convert.ToString(grdview.Rows[e.RowIndex].Cells[2].Value);
                MessageBox.Show("empName",
                   "Employee Name", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        public bool viewSearch(string name)
        {
            bool flag = false;

            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "EmpID";
            dataGridView1.Columns[1].Name = "NIC";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Address";
            dataGridView1.Columns[3].Name = "Contact Number";
            dataGridView1.Columns[4].Name = "Date of Birth";
            dataGridView1.Columns[5].Name = "Department";
            dataGridView1.Columns[6].Name = "Designation";
            dataGridView1.Columns[7].Name = "Date of Join";

            ArrayList rows = new ArrayList();

            DBConnect db = new DBConnect();
            string query = "Select * from employee where name like '%"+name+"%'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        try
                        {
                            Parallel.ForEach(data.AsEnumerable(), row =>
                            // foreach (DataRow row in data.Rows)
                            {
                                rows.Add(row["EmpID"]);
                                rows.Add(row["NIC"]);
                                rows.Add(row["Name"]);
                                rows.Add(row["Address"]);
                                rows.Add(row["ContactNo"]);
                                rows.Add(row["DateOfBirth"]);
                                rows.Add(row["Department"]);
                                rows.Add(row["Designation"]);
                                rows.Add(row["DateOfJoin"]);
                                dataGridView1.Rows.Add(rows.ToArray());
                                flag = true;
                            });
                        }
                        catch (AggregateException ex)
                        {
                            foreach (Exception innerEx in ex.InnerExceptions)
                            {
                                Console.WriteLine(innerEx.ToString());
                                // Do something considering the innerEx Exception
                            }
                        }
                    }

                    db.CloseConnection();
                }
            }
            
            return flag;
        }


    }
}
