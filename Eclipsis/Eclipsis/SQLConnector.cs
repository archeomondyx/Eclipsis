using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Windows.Forms;
using EclipsisTransactionProtocol;
using System.IO;
using System.Diagnostics;

namespace Eclipsis
{
    public class SQLConnector
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public SQLConnector()
        {
            Initialize();
        }
    

        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + Properties.Settings.Default.sqlserver + ";" +
                                "DATABASE=" + Properties.Settings.Default.database + ";" +
                                "UID=" + Properties.Settings.Default.userid + ";" +
                                "PASSWORD=" + Properties.Settings.Default.passw + ";";

            if (connection != null)
                CloseConnection();

            connection = new MySqlConnection(connectionString);

            Properties.Settings.Default.connectionString = connectionString;
            Properties.Settings.Default.Save();
        }
        
        public void Initialize(string serv, string dat, string userid, string pass )
        {
            SetParams(serv, dat, userid, pass);
            Initialize();
            
        }

        public void SetParams(string serv, string dat, string userid, string pass )
        {
            server = serv;
            database = dat;
            uid = userid;
            password = pass;
        }

        public bool OpenConnection(bool suppressOutput)
        {
            string message = String.Empty;
            try
            {
                if (connection == null)
                    Initialize();

                if(connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return true;
            }
            catch (MySqlException exc)
            {
                switch (exc.Number)
                {
                    case 0:
                        message = "Cannot connect to server.\n" + exc.Message;
                        break;
                    case 1045:
                        message = "Invalid username/password, please try again";
                        break;
                    default:
                        message =  exc.Message;
                        break;
                }

                if(!suppressOutput)
                    MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool CloseConnection()
        {
            try
            {
                if (connection == null)
                    return true;
                connection.Close();
                connection = null;

            }
            catch (MySqlException exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // just as failsafe 
            return true;
        }

        public ActionResult PerformAction(SQLActionType actType, string table, ColValues[] values, string condition)
        {       
            int? sqlcode = null;
            
            // make sure that we are not going to use empty table
            if (String.IsNullOrWhiteSpace(table))
                return ActionResult.TableNullOrEmpty;

            switch (actType)
            {
                case SQLActionType.Insert:
                    sqlcode = this.Insert(table, values);
                    break;
                case SQLActionType.Update:
                    if (!String.IsNullOrWhiteSpace(condition))
                        sqlcode = this.Update(table, values, condition);
                    break;
                case SQLActionType.Delete:
                    if (!String.IsNullOrWhiteSpace(condition))
                        sqlcode = this.Delete(table, condition);
                    break;
                case SQLActionType.Backup:
                    // todo
                    break;
                case SQLActionType.Restore:
                    // todo
                    break;
                case SQLActionType.Count:
                    // todo
                    break;
                
            }
            return sqlcode.HasValue || sqlcode.Value >= 0 ? ActionResult.Ok : ActionResult.OtherError; 
        }

        public List<ColValues> PerformSelect(string table, string condition, List<ColValues> columns)
        {
            return Select(table, condition, columns);
        }

        # region data manipulation block
        private int? Insert(string table, ColValues[] values)
        {
            int? sqlcode = null;
            
            string query = "INSERT INTO " + table + " ( ";
            query += values[0].Column;
            
            for (int i = 1; i < values.GetLength(0); i++)
                query += ", " + values[i].Column ;

            query += " ) VALUES ( '" + values[0].Value + "' ";

            for (int i = 1; i < values.GetLength(0); i++)
                query += ", '" + values[i].Value + "' ";

            query += ") ; ";

            //open connection
            if (this.OpenConnection(true) == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Execute command
               sqlcode  = cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
            return sqlcode;          
        }

        private int? Update(string table, ColValues[] values, string condition)
        {
            int? sqlcode = null;
            string query = "UPDATE " + table + " SET ";

            // create SQL statement for update
            for (int i = 0; i < values.GetLength(0); i++)
            {
                query += values[i].Column + "= '" + values[i].Value + "'";
                if (i != values.GetLength(0) - 1) query += " , "; 
            }

            query += " WHERE " + condition;
            
            //Open connection
            if (this.OpenConnection(true) == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                sqlcode = cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }

            return sqlcode;
        }

        private int? Delete(string table, string condition)
        {
            int? sqlcode = null;
            string query = "DELETE FROM " + table + " WHERE " + condition;

            if (this.OpenConnection(true) == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                sqlcode = cmd.ExecuteNonQuery();
                this.CloseConnection();

            }

            return sqlcode;
        }

        // get the values
        private List<ColValues> Select(string table, string condition,List<ColValues> Columns)
        {
            string columns = String.Empty;

            // go through the columns
            for (int i=0;i < Columns.Count ; i++ )
            {
                columns += Columns[i].Column;
                if (i != Columns.Count - 1)
                    columns += ", ";
            }
            // add columns to query
            string query = "SELECT "+ columns +" FROM " + table;

            // add condition
            if (!String.IsNullOrEmpty(condition))
                query += " WHERE " + condition;
             //Open connection
            if (this.OpenConnection(true) == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                
                while (dataReader.Read())
                {
                    for (int i = 0; i < Columns.Count; i++)
                    {
                        Columns[i].Value.Add(dataReader[Columns[i].Column] + "");
                    }
                }
                dataReader.Close();
            }
            return Columns;
        }

        // Count from table
        private int? Count(string table, string condition)
        {
            string query = "SELECT Count(*) FROM " + table + " WHERE " + condition ;
            int Count = -1;

            //Open Connection
            if (this.OpenConnection(true) == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();
            }
            return Count;
        }

        //Backup
        public void Backup(string filename, string path)
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to  with the current date
                path = path+"\\"+ filename +"--" + year + "-" + month + "-" + day +
                "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = filename;
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error during backup!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Restore
        public void Restore(string filename, string path)
        {
            try
            {
                //Read file from C:\
                path = path + "\\" + filename + ".sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = filename;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error during restore!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        # endregion
    }

   

    public enum ActionResult
    {
        TableNullOrEmpty = -1,
        OtherError = -99,
        Ok = 0
    }
}
