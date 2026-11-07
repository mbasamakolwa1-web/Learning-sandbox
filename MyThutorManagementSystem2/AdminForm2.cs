using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace MyThutorManagementSystem2
{
    public partial class AdminForm2 : Form
    {
        private readonly string adminID;

        public AdminForm2(string userID)
        {
            InitializeComponent();

            adminID = userID;
        }
        public AdminForm2()
        {
            InitializeComponent();
        }

        private void AdminForm2_Load(object sender, EventArgs e)
        {

        }
    }
}