using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2883601C_MiniProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        int AdminAttempt = 0;
        int FanAttempt = 0;

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            string Password = txtUserPassword.Text;

            if ( comBoxLogin.SelectedIndex ==0 && Password != "666")
            {
                AdminAttempt += 1;
                MessageBox.Show("Please Enter  the  correct Password ", "Password Error");
                if (AdminAttempt == 3)
                { Application.Exit(); }


            }
            else
                if (comBoxLogin.SelectedIndex ==1 && Password != "333")
            {
                FanAttempt += 1;
                MessageBox.Show("Please Enter  the  correct Password ", "Password Error");
                if (FanAttempt == 3)
                { Application.Exit(); }

            }
            else
            {
                if (comBoxLogin.SelectedIndex == 0)
                {
                    // declares a new instance of the Admin form (which, by default, is not visible)
                    Admin f1 = new Admin();
                    // makes the current form “invisible”
                    this.Visible = false;
                    // shows the new instance of the Admin form
                    f1.ShowDialog();
                }
                else if (comBoxLogin.SelectedIndex == 1)
                {
                    // declares a new instance of the Admin form (which, by default, is not visible)
                    Booking f1 = new Booking();
                    // makes the current form “invisible”
                    this.Visible = false;
                    // shows the new instance of the Admin form
                    f1.ShowDialog();
                }

            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            comBoxLogin.SelectedIndex = -1;
            txtUserPassword.Clear();
            comBoxLogin.Focus();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }    
}
