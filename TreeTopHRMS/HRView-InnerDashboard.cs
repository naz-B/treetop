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
    public partial class HRView_InnerDashboard : Form
    {
        public HRView_InnerDashboard()
        {
            InitializeComponent();
        }

        private void HRView_InnerDashboard_Load(object sender, EventArgs e)
        {

            var t1 = new Task(() => populateRosterLB());
            var t2 = new Task(() => populateInOutLB());
            var t3 = new Task(() => populateLeaveLB());
            var t4 = new Task(() => populateOvertimeLB());
            // Start the tasks
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            // Wait for all the tasks to finish
            //Task.WaitAll(t1, t2, t3, t4);
            
        }

        private void populateOvertimeLB()
        {
            int empID = 0;
            DBConnect db = new DBConnect();
            string query = "Select empID from overtime where status = 'N'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                        //Read the data and store them
                        while (reader.Read())
                        {
                            empID = reader.GetInt16(0);
                        }
                   string query2 = "Select name from employee where empID = "+empID+"";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        //Overtime.Items.Clear();
                        try {
                            Parallel.ForEach(data.AsEnumerable(), row =>
                            //foreach (DataRow row in data.Rows)
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    Overtime.Items.Add(row["name"]);

                                }));
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
        }

        private void populateLeaveLB()
        {
            ArrayList empIDs = new ArrayList();
           // int empID = 0;
            DBConnect db = new DBConnect();
            string query = "Select empID, type from leaves where status = 'N'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    empIDs.Clear();
                    //Read the data and store them
                    while (reader.Read())
                    {
                       empIDs.Add(reader.GetInt16(0));
                       
                    }
                    for (int i = 0; i < empIDs.Count; i++)
                    {
                        string query2 = "Select name from employee where empID = " + empIDs[i] + "";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                        {
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            //Overtime.Items.Clear();
                            try
                            {
                                Parallel.ForEach(data.AsEnumerable(), row =>
                                //foreach (DataRow row in data.Rows)
                                {
                                    Invoke(new MethodInvoker(delegate ()
                                    {
                                        Leave.Items.Add(row["name"]);

                                    }));
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
                    }

                    db.CloseConnection();
                }
            }
        }

        private void populateInOutLB()
        {
            ArrayList empIDs = new ArrayList();
            // int empID = 0;
            DBConnect db = new DBConnect();
            string query = "Select empID from request where status = 'N'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    empIDs.Clear();
                    //Read the data and store them
                    while (reader.Read())
                    {
                        empIDs.Add(reader.GetInt16(0));

                    }
                    for (int i = 0; i < empIDs.Count; i++)
                    {
                        string query2 = "Select name from employee where empID = " + empIDs[i] + "";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                        {
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            //InOut.Items.Clear();
                            try
                            {
                                Parallel.ForEach(data.AsEnumerable(), row =>
                                //foreach (DataRow row in data.Rows)
                                {
                                    Invoke(new MethodInvoker(delegate ()
                                    {
                                        InOut.Items.Add(row["name"]);

                                    }));
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
                    }

                    db.CloseConnection();
                }
            }
        }

        private void populateRosterLB()
        {
            ArrayList empIDs = new ArrayList();
            // int empID = 0;
            DBConnect db = new DBConnect();
            string query = "Select empID from request where status = 'N'"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(db.connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    empIDs.Clear();
                    //Read the data and store them
                    while (reader.Read())
                    {
                        empIDs.Add(reader.GetInt16(0));

                    }
                    for (int i = 0; i < empIDs.Count; i++)
                    {
                        string query2 = "Select name from employee where empID = " + empIDs[i] + "";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                        {
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            //Roster.Items.Clear();
                            try
                            {
                                Parallel.ForEach(data.AsEnumerable(), row =>
                                //foreach (DataRow row in data.Rows)
                                {
                                    Invoke(new MethodInvoker(delegate ()
                                    {
                                        Roster.Items.Add(row["name"]);

                                    }));
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
                    }

                    db.CloseConnection();
                }
            }
        }
    }
}
