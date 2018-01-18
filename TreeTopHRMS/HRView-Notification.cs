using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeTopHRMS
{
    public partial class HRView_Notification : Form
    {

        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height

        public HRView_Notification()
        {
            InitializeComponent();
        }

        private void HRView_Notification_Load(object sender, EventArgs e)
        {
            populateCategoryComboBox();
            populateEmployeeComboBox();
            populateTypeComboBox();
        }

        //to populate the employee names combo box
        public void populateEmployeeComboBox()
        {
            //----------populate employee name combobox------------
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            employee.Items.Add("All");
            string query = "Select Distinct Name from Employee"; // set query to fetch data 
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    //add to the combobox
                    employee.Items.Add("" + reader.GetString(0));
                }
                //close reader
                reader.Close();

            }
            //close connection
            db.CloseConnection();
        }

        //to populate the category combo box
        public void populateCategoryComboBox()
        {
            category.Items.Add("Leave");
            category.Items.Add("Salary");
        }

        //to populate the type combo box
        public void populateTypeComboBox()
        {
            notificationType.Items.Add("Both");
            notificationType.Items.Add("Email");
            notificationType.Items.Add("Print");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void generate_Click(object sender, EventArgs e)
        {
            //fetch user inputs
            string categor = (string)category.SelectedItem;
            string type = (string)notificationType.SelectedItem;
            string employe = (string)employee.SelectedItem;
            List<string> empList = new List<string>();
            if (string.IsNullOrEmpty(category.Text) || (category.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a category",
                   "Category Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(notificationType.Text) || (notificationType.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a type",
                   "Type Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(employee.Text) || (employee.SelectedIndex == -1))
            {
                MessageBox.Show("Please select an employee",
                   "Employee Not Selected", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else
            {

                if (employe.Equals("All"))
                {
                    //reference to dbconnect class
                    DBConnect db = new DBConnect();
                    string query = "Select Distinct Name from Employee"; // set query to fetch data 
                    if (db.OpenConnection() == true)
                    {
                        //Create Command
                        MySqlCommand cmd = new MySqlCommand(query, db.connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Read the data and store them
                        while (reader.Read())
                        {
                            //add to the combobox
                            empList.Add("" + reader.GetString(0));
                        }
                        //close reader
                        reader.Close();
                    }
                    db.CloseConnection();
                }


                //  MessageBox.Show(categor + " " + type, "Some title",
                //            MessageBoxButtons.OK, MessageBoxIcon.Question);
                populateGridView(employe, empList, categor, type);
            }
        }

        private void populateGridView(string employee, List<string> empList, string category, string type)
        {
            //variable to hold the employee ID
            int empID = 0;

            //reference to DBConnect class
            DBConnect db = new DBConnect();

            //datagridview column count and titles
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Employee";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "Type";

            //if only one employee is selected
            if (empList.Count.Equals(0))
            {
                ArrayList row = new ArrayList();

                //add employee name
                row.Add(employee);

                //add category and type
                row.Add(category);
                row.Add(type);

                dataGridView1.Rows.Add(row.ToArray());
            }
            else
            {
                Parallel.For(0, empList.Count, i =>

                // for (int i = 0; i < empList.Count; i++)
                {
                    ArrayList row = new ArrayList();
                    row.Add(empList[i]);
                    row.Add(category);
                    row.Add(type);
                    dataGridView1.Rows.Add(row.ToArray());
                });
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            //reference to dbconnect class
            DBConnect db = new DBConnect();
            //string category;
            //string type = "Email";
            //string employee = null;// "John Snow";
            try
            {
                Parallel.ForEach(dataGridView1.Rows.OfType<System.Windows.Forms.DataGridViewRow>(), (DataGridViewRow row) =>

                //foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                //fetch the category and type from datagridview
                string category = (string)row.Cells["Category"].Value;
                string type = (string)row.Cells["Type"].Value;
                string employee = Convert.ToString(row.Cells["Employee"].Value);
                    int empID = db.getEmpID(employee);
                    string email = db.getEmpEmail(empID);
                    if (type.Equals("Both"))
                    {

                        var t1 = new Task(() => GenerateEmailNotification(empID, category, email));
                        var t2 = new Task(() => GeneratePrintNotification(empID, category));
                        t1.Start();
                        t2.Start();
                       // Task.WaitAll(t1, t2);
                        MessageBox.Show("Notifications Sent!"+email,
                        "Notification", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    }
                    else if (type.Equals("Email"))
                    {

                        GenerateEmailNotification(empID, category, email);
                        MessageBox.Show("Notifications Sent!" + email+empID+employee+category,
                        "Notification", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    }
                    else if (type.Equals("Print"))
                    {
                        GeneratePrintNotification(empID, category);
                    }
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

        public void GenerateEmailNotification(int empID, string category, string email)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                message.From = new MailAddress("toptreep@gmail.com");
                message.To.Add(email);
                message.Subject = "You have been given " + category;
                message.Body = category;

                smtp.Port = 25;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("toptreep@gmail.com", "123456toptree");
                smtp.SendAsync(message, message.Subject);
                smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }

        }

        void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Email sending completed!");
        }

        public void GeneratePrintNotification(int empID, string category)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Customer Summary", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Customer Summary", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
