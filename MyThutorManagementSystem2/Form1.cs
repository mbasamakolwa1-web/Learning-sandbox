using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace MyThutorManagementSystem2
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
    new OleDbConnectionStringBuilder
    {
        Provider = "Microsoft.ACE.OLEDB.12.0",
        DataSource = Path.Combine(
            AppContext.BaseDirectory,
            "Database8.accdb")
    }.ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool TestConnection()
        {
            if (!File.Exists(Path.Combine(
                AppContext.BaseDirectory, "Database8.accdb")))
            {
                MessageBox.Show("Database8.accdb was not found.");
                return false;
            }

            using (OleDbConnection connection =
                new OleDbConnection(connectionString))
            {
                connection.Open();
                return true;
            }
        }

        
        


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            string password = txtPassWord.Text;

            if (string.IsNullOrWhiteSpace(userID) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Enter your User ID and password.";
                return;
            }

            try
            {
                if (!TestConnection())
                    return;

                bool validLogin = false;
                string role = "";

                if (userID.StartsWith(
                    "ST", StringComparison.OrdinalIgnoreCase))
                {
                    validLogin = CheckCredentials(
                        "STUDENT", "StudentID", userID, password);

                    role = "Student";
                }
                else if (userID.StartsWith(
                    "AD", StringComparison.OrdinalIgnoreCase))
                {
                    validLogin = CheckCredentials(
                        "ADMINISTRATOR", "AdminID", userID, password);

                    role = "Admin";
                }
                
                

                if (!validLogin)
                {
                    lblMessage.Text = "Incorrect User ID or password.";
                    txtPassWord.Clear();
                    txtPassWord.Focus();
                    return;
                }

                OpenDashboard(role, userID);
            }
            catch (OleDbException)
            {
                MessageBox.Show(
                    "A database error occurred. Check the database " +
                    "file, provider and table/field names.");
            }
        }

        private bool CheckCredentials(
                   string tableName,
                   string idField,
                   string userID,
                   string password)
        {
            // These identifiers come only from the fixed choices
            // supplied by the login handler, not from user input.
            string sql =
                $"SELECT COUNT(*) FROM [{tableName}] " +
                $"WHERE [{idField}] = ? AND [PasswordHash] = ?";

            using (OleDbConnection connection =
                new OleDbConnection(connectionString))
            using (OleDbCommand command =
                new OleDbCommand(sql, connection))
            {
                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 20).Value = userID;

                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 255).Value = password;

                connection.Open();

                int count = Convert.ToInt32(
                    command.ExecuteScalar());

                return count == 1;
            }
        }

        private void OpenDashboard(string role, string userID)
        {
            Form dashboard;

            if (role == "Student")
            {
                dashboard = new StudentForm2(userID);
            }
            else
            {
                dashboard = new AdminForm2(userID);
            }

            this.Hide();

            dashboard.FormClosed += (s, args) => this.Close();

            dashboard.Show();
        }
    }
}
