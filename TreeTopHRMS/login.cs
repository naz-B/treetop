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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reference to DBConnect class
            DBConnect db = new DBConnect();

            //take user input from textboxes
            string usernameT = username.Text; 
            string passwordT = password.Text; 
            //if username and password matches load dashboard
            if (db.isUserExist(usernameT, passwordT))
            {
                //check user type and load dashboard for HR
                if (db.checkUserDept(usernameT).Equals("Human Resources"))
                {
                    LoginInfo.username = usernameT;
                    LoginInfo.usertype = db.checkUserDesignation(usernameT);
                    Form1 dashboard = new Form1();
                    this.Hide();
                    dashboard.Show();
                    dashboard.Focus();
                    

                }
                //dashboard for regular employee
                else
                {
                    LoginInfo.username = usernameT;
                    LoginInfo.usertype = db.checkUserDesignation(usernameT);
                    EmpView_Dashboard dashboard = new EmpView_Dashboard();
                    this.Hide();
                    dashboard.Show();
                    dashboard.Focus();
                   

                }
                
            }
            else
            {
                //if username and password does not match
                MessageBox.Show("Please enter username and password again", 
                    "Invalid Username or Password", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                username.Clear();
                password.Clear();
                username.Focus();
            }   
            

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
