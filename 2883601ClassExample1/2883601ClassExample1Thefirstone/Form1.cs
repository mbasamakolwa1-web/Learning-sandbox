using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2883601ClassExample1Thefirstone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            lblMessage1.Text = "Welcome to so Yum !" + txtName.Text;
            lblMessage2.Text = "You are assigned Table" + txtTableNo.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtTableNo.Clear();
            txtName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
