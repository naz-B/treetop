using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TreeTopHRMS
{
    public partial class HRView_Report : Form
    {
        public HRView_Report()
        {
            InitializeComponent();
        }

        private void HRView_Report_Load(object sender, EventArgs e)
        {
            //call the combo box populate method
            populateReportType();

            
        }

        private void populateReportType()
        {
            reportType.Items.Add("Employees");
            reportType.Items.Add("Duty Roster");
            reportType.Items.Add("Leaves");
        }

        private void gnrte_Click(object sender, EventArgs e)
        {
            //get the selected report
            string tblName = reportType.Text;
            
            //declare variable to hold the name of the table
            string table = null;
            if (string.IsNullOrEmpty(reportType.Text) || (reportType.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a report",
                   "Report Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            {
                //choose the database table according to user selection
                if (tblName.Equals("Employees"))
                {
                    table = "employee";
                }
                else if (tblName.Equals("Duty Roster"))
                {
                    table = "duty";
                }
                else
                {
                    table = "leaves";
                }

                //get the data from the database
                DBConnect db = new DBConnect();
                string query = "Select * from " + table + ""; // set query to fetch data 
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
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            var t1 = new Task(() => downloadReport());
            t1.Start();
            //downloadReport();
        }

        private void downloadReport()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            Int16 i, j;

            xlApp = new Excel.Application();
//            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Parallel.For(0, dataGridView1.RowCount - 2, l =>
            //for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                Parallel.For(0, dataGridView1.ColumnCount - 1, m =>
                //for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[l + 1, m + 1] = dataGridView1[m, l].Value.ToString();
                });
            });

            xlWorkBook.SaveAs(@"d:\treetopReport.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("Download Complete!",
                    "Downloading", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
