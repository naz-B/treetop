using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TreeTopHRMS
{
    class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public string connectionString;
        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "dbtreetophrms";
            uid = "root";
            password = "";
            
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; Convert Zero Datetime=True";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                      //  MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert employee to database
        public int InsertEmployee(string name, int NIC, string address, int contact, string dob, string doj, string email)
        {
            int empID = getLastEmpID()+1;
            string query = "INSERT into employee(EmpID, NIC, Name, Address, ContactNo, " +
                "DateOfBirth, DateOfJoin, email) VALUES("+ empID + ", "+ NIC + ", '"+name+"', '"+ 
                address + "', "+ contact + ", '"+ dob + "', '"+ doj + "', '"+email+"')";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                    //close Data Reader
                    reader.Close();

                //close Connection
                this.CloseConnection();

                

            }
            return empID;
        }

        //Update overtime description
        public int updateOvertimeDesc(string desc, int overtimeID)
        {
            string query = "UPDATE overtime SET descr = '"+desc+"' WHERE overtimeID = "+overtimeID+"";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
                


            }
            return 1;
        }

        //Update status
        public int updateStatus(string status, int ID, string tableName, string tableID)
        {
            string query = "UPDATE "+tableName+" SET status = '" + status + "' WHERE "+tableID+" = " + ID + "";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
                
            }
            return 1;
        }

        //Update status
        public int updateLeaveBal(int empID, string type, TimeSpan duration)
        {
            int balance = getLeaveBal(empID, type);
            int durationI = (Int32)duration.TotalDays;
            balance -= durationI;
            string query = "UPDATE leaves SET balance = "+balance+"  WHERE empID = " + empID + " AND type =  '" + type + "' AND status = 'Balance'";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
            return 1;
        }

        //Gets leave balance of employees
        public int getLeaveBal(int empID, string type)
        {
            int balance = 0;
            string query = "SELECT balance FROM leaves  WHERE empID = " + empID + " AND type =  '" + type + "' AND status = 'Balance'";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //Read the data and store them
                while (reader.Read())
                {
                    balance = reader.GetInt32(0);
                }
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
            return balance;
        }

        //Update overtime 
        public int updateOvertime(string desc, int overtimeID, string startTime, string endTime)
        {
            string query = "UPDATE overtime SET descr = '"+ desc + "', startTime = '"+ startTime + "', " +
                "endTime = '"+ endTime + "' WHERE overtimeID = "+ overtimeID + "";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();



            }
            return 1;
        }

        //Update overtime 
        public int updateLeave(string type, int leaveID, string startDay, string endDay)
        {
            string query = "UPDATE leaves SET type = '" + type + "', fromDay = '" + startDay + "', " 
                + "toDay = '" + endDay + "' WHERE leaveID = " + leaveID + "";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
                
            }
            return 1;
        }


        //get empID 
        public int getLastEmpID()
        {
            int empID = 0;
            string query = "SELECT EmpID from employee  ORDER BY EmpID DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    empID = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                CloseConnection();
            
            
                
            }
            return empID;
        }

        //to check if user exists
        public bool isUserExist(string username, string password)
        {
            bool flag = false;
            string pass = null;
            string query = "SELECT Password FROM user WHERE Username ='" + username + "'";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    pass = "" + reader.GetString(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

                //change flag if passwords match
                if (pass.Equals(password))
                {
                    flag = true;
                }
                
            }
            return flag;
        }

        //get empID of logged in user
        public int getEmpIDs(string username)
        {
            int empID = 0;
            string query = "Select empID from user where username = '" + username + "'"; // set query to fetch data 
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
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
            this.CloseConnection();
            return empID;
        }

        //insert leave entry 
        public void requestLeave(int empID, string type, string from, string to, string reason)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            int leaveID = getLastLeaveID() + 1;
            int balance = 30;
            string status = "N";
            string query = "INSERT into leaves(leaveID, empID, type, fromDay, toDay, Date, balance, status) " +
               "VALUES(" + leaveID + ", " + empID + ", '" + type + ": "+reason+"', '" + from + "', '" + to + "', '" + date + "', " + balance + ", '"+status+"')";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
                

            }


        }

        //request In Out
        public void requestInOut(int empID, string type, string date, string reason)
        {
            int reqID = getLastReqNo() + 1;
            string status = "N";
            string query = "INSERT into request(reqID, empID, type, datetime, reason, status) " +
               "VALUES(" + reqID + ", " + empID + ", '"+type+"', '" + date + "', '" + reason + "', '" + status + "')";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();


            }


        }
        
        //generate salary
        public bool generateSal(int empID, double basicSal, double allowance, double deduction, double netSal)
        {
            bool flag = false;
            int payrollNo = getLastPayrollNo() + 1;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "INSERT into payroll(payrollNo, date, empID, basicSalary, allowance, " +
                "deduction, netSalary) VALUES(" + payrollNo + ", '" + date + "', " + empID + ", " 
                + basicSal + ", " + allowance + ", " + deduction + ", " + netSal + ")";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
                flag = true;
               

            }
            return flag;

        }

        public bool updateeSal(int empID, double amount, string type)
        {
            bool flag = false;
            int salNo = getLastSalNo() + 1;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "INSERT INTO salary(SalNo, EmpID, date, type, amount, status)" +
                            "VALUES("+salNo+", " + empID + ", '" + date + "', '"+type+"', "+amount+", 'current')";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
                flag = true;


            }
            return flag;

        }

        //check the department of the user
        public string checkUserDept(string username)
        {
            string department = null;
            int empID = 0;
            //SELECT Department FROM employee WHERE EmpID = 1
            string query = "SELECT EmpID FROM user WHERE Username ='" + username + "'";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data
                while (reader.Read())
                {
                    empID = reader.GetInt16(0);
                }
                reader.Close();
                string query2 = "SELECT Department FROM employee WHERE EmpID = "+empID+"";

                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader reader2 = cmd2.ExecuteReader();

                    //fetch the department from the database
                    while (reader2.Read())
                    {
                        department = ""+reader2.GetString(0);
                    }

                    //close Data Reader
                    reader2.Close();

                //close Connection
                this.CloseConnection();
            }
            return department;
        }

        //check user designation
        public string checkUserDesignation(string username)
        {
            string designation = null;
            int empID = 0;
            //SELECT Department FROM employee WHERE EmpID = 1
            string query = "SELECT EmpID FROM user WHERE Username ='" + username + "'";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data
                while (reader.Read())
                {
                    empID = reader.GetInt16(0);
                }
                reader.Close();
                string query2 = "SELECT Designation FROM employee WHERE EmpID = " + empID + "";

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                //fetch the department from the database
                while (reader2.Read())
                {
                    designation = "" + reader2.GetString(0);
                }
                
                //close Data Reader
                reader2.Close();

                //close Connection
                this.CloseConnection();
                
            }
            return designation;
        }

        //get employee ID
        public int getEmpID(string employee)
        {
            int empID = 0;
            //SELECT Department FROM employee WHERE EmpID = 1
            string query = "SELECT EmpID FROM employee WHERE Name ='" + employee + "'";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data
                while (reader.Read())
                {
                    empID = reader.GetInt16(0);
                }
                reader.Close();
            }

                //close Connection
                this.CloseConnection();

            
            return empID;
        }

        //check user designation
        public string getEmpEmail(int employee)
        {
            string email = null;
            //SELECT Department FROM employee WHERE EmpID = 1
            string query = "SELECT email FROM employee WHERE empID =" + employee + "";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data
                while (reader.Read())
                {
                    email = reader.GetString(0);
                }
                reader.Close();
            }

            //close Connection
            this.CloseConnection();


            return email;
        }

        //update employee department and designation
        public bool updateEmployee(int empID, string dept, string desig)
        {
            bool flag = false;
            string query = "UPDATE employee SET department = '" + dept + "', " +
                "Designation = '" + desig + "' where EmpID = " + empID + "";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                flag = true;

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();



            }
            return flag;
        }

        //update database with employees salary
        public bool addEmpSalary(int empID, string type, double amount, string status)
        {
            bool flag = false;
            int salNo = getLastSalNo()+1;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "INSERT into salary(SalNo, EmpID, Date, Type, Amount, status) " +
                "VALUES(" + salNo + ", " + empID + ", '" + date + "', '" + type + "', " + 
                amount + ", '"+status+"')";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                flag = true;

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
            return flag;
        }

        //update database with employees deduction
        public bool addDeduction(int empID, string type, double amount, string status)
        {
            bool flag = false;
            int deductionID = getLastDeducID() + 1;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "INSERT into deduction(deductionID, EmpID, Date, descr, Amount, status) " +
                "VALUES(" + deductionID + ", " + empID + ", '" + date + "', '" + type + "', " + amount + ", '" + status + "')";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                flag = true;

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
            return flag;
        }

        public void deleteOvertime(int overtimeID)
        {
            string query = "Delete from overtime where overtimeID = "+overtimeID+"";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                
                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
        }

        public void deleteLeave(int leaveID)
        {
            string query = "Delete from leaves where leaveID = " + leaveID + "";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
        }

        //get salNo
        public int getLastSalNo()
        {
            int salNo = 0;
            string query = "SELECT SalNo from salary ORDER BY SalNo DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    salNo = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
            return salNo;
        }

        //get salNo
        public int getLastDeducID()
        {
            int deductionID = 0;
            string query = "SELECT deductionID from deduction ORDER BY deductionID DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    deductionID = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
            return deductionID;
        }

        //get salNo
        public int getLastReqNo()
        {
            int reqID = 0;
            string query = "SELECT reqID from request ORDER BY reqID DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    reqID = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
            return reqID;
        }

        //get leaveNo
        public int getLastLeaveNo()
        {
            int leaveID = 0;
            string query = "SELECT leaveID from leaves ORDER BY leaveID DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    leaveID = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
            return leaveID;
        }


        //add leaves
        public bool addEmpLeave(int empID, string type, string fromday, string today, int balance, string status)
        {
            bool flag = false;
            int leaveID = getLastLeaveID() + 1;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "INSERT into leaves(leaveID, EmpID, type, fromDay, toDay, date, balance, status) " +
                "VALUES(" + leaveID + ", " + empID + ", '" + type + "', '" + fromday + "', '" + today + "', '" + date + "'," + balance + ", '"+status+"' )";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                flag = true;

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();

            }
            return flag;
        }

        //get leaveID
        public int getLastLeaveID()
        {
            int leaveID = 0;
            string query = "SELECT leaveID from leaves ORDER BY leaveID DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    leaveID = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
            return leaveID;
        }

        public int getLastPayrollNo()
        {
            int payrollNo = 0;
            string query = "SELECT payrollNo from payroll ORDER BY payrollNo DESC LIMIT 1";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                    payrollNo = reader.GetInt16(0);
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
            return payrollNo;
        }

        //change the sal status of employees
        public void changeSalStatus(int empID, string status, string type)
        {
            string query = "UPDATE salary set status = '"+status+"' where empID = "+empID+" " +
             "and type = '"+type+"'";//query to fetch data
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read the data and store them
                while (reader.Read())
                {
                   
                }

                //close Data Reader
                reader.Close();

                //close Connection
                this.CloseConnection();
            }
        }
    }
}
