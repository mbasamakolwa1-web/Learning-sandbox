using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIIA2026ProgTest2
{
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }
        public static string InputBox(string prompt, string title, string defaultValue)
        {
            // input box code - do not make any changes to this code
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            return s;
        }

        // type in your student name here as a comment
        //Mbasa Issa Makolwa

        //Create count Variable for invalid for both login IDs
        int AttemptCount ;
        private void loginAddServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declare the boolean variable
            bool blnValidPswd = true;
            

            // call the method to validate the passwords
            blnValidPswd = ValidatePswd(blnValidPswd);

            // continue if the passwords are valid
            if (blnValidPswd == true)
            {
                // if Admin is chosen - use the index of the combo box
                if (cboLoginID.SelectedIndex==0)
                {
                    // declare the array in this context
                    string[] ServicePackage = new string[2];
                    double[] BaseCost = new double[2];

                    // declare the array count
                    int intArrayCount;

                    // loop to fill the arrays
                    for (intArrayCount = 0; intArrayCount < ServicePackage.Length; ++intArrayCount)
                    {    // enter the details of 2 service packages & 2 corresponding base costs from input boxes into 2 separate arrays 
                        ServicePackage[intArrayCount] = InputBox("Please Enter the Service Package ", "ServiceInput", "");
                        BaseCost[intArrayCount] = Convert.ToDouble(InputBox("Please Enter Service Cost", "BaseCostInput", ""));
                        
                    }
                    //assign to the public arrays
                    ServiceArrayClass.ServicePackage = ServicePackage;
                    ServiceArrayClass.BaseCost = BaseCost;
                }
                else
                    // if Customer is chosen - you can use the index or any other approach
                    if (cboLoginID.SelectedIndex==1)
                {
                    // go to the services form
                    Services NewService = new Services();
                    this.Visible = false;
                    NewService.ShowDialog();
                }
            }
           
            // close the program if 3 or more passwords have been incorrectly entered
            if(AttemptCount>=3)
            { Application.Exit(); }

           
            } 

        private bool ValidatePswd(bool blnValidPswd)
        {
            // validate the login ID with the corresponding password
            // if the administrator is logging in, the password should be A
            // if the customer is logging in, the password should be C
            // use the index of the login id combo box
            // as a comment directly below this comment, briefly explain why using the index is the better approach when accessing the items in a combo box
            //This  is  to account  for  scenarios where  you  may  have  a  large collection of items/elements , using the index is simply more efficient .

            if (cboLoginID.SelectedIndex==0 && txtPswd.Text!="A")
            {
                AttemptCount += 1;
                MessageBox.Show("Invalid admin password", "Error");
                blnValidPswd = false;
            }
            else
            if (cboLoginID.SelectedIndex==1 && txtPswd.Text!="C")
            {
                AttemptCount += 1;
                MessageBox.Show("Invalid customer password", "Error");
                blnValidPswd = false;
            }
            return blnValidPswd;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear the form
            cboLoginID.SelectedIndex = -1;
            txtPswd.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit the program
            Application.Exit();
        }
    }
}
