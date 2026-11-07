using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIIA2025Test2A
{
    public partial class LogAdmin : Form
    {
        public LogAdmin()
        {
            InitializeComponent();
        }

        public static string InputBox(string prompt, string title, string defaultValue)
        {
            // code for Input Box - do not change this code
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            return s;
        }
        // type your student number as a comment

           
        private void loginAddItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declare local variables
            
            bool blnValidPswd = true;

            // call the method to validate the passwords
            blnValidPswd = ValidatePassword(blnValidPswd);

            if (blnValidPswd == true)
            {    // if Admin is chosen - use the index
                if (cboLogin.SelectedIndex==0)
                {
                    // declare the array in this context
                    string[] NewDenimItem = new string[2];
                    double[] NewItemCost = new double[2];

                    // declare the array count
                    int intArrayCount;

                    // loop to fill the arrays
                    for (intArrayCount = 0; intArrayCount < NewDenimItem.Length; ++intArrayCount)
                    {    // enter the details of 2 denim items & 2 corresponding cost prices for the small item from input boxes into 2 separate arrays 
                        NewDenimItem[intArrayCount] = InputBox("Please Enter Item ", "IntemInput");
                        NewItemCost[intArrayCount] = Convert.ToDouble(InputBox("Please Enter Item Cost ", "ItemCostInput"));
                    }
                    //assign to the public arrays
                    ArrayClass.DenimItem = NewDenimItem;
                    ArrayClass.ItemCost = NewItemCost;

                }
                else
                    // if Customer is chosen - you can use the index or any other approach
                    if (cboLogin.SelectedIndex==1)
                {
                    // go to the purchase form
                    Purchase NewPurchase = new Purchase();
                    this.Visible = false;
                    NewPurchase.ShowDialog();
                }
            }
            
        }

        private bool ValidatePassword(bool blnValidPswd)
        {
            // this method validates the passwords - the LoginAdmin password is LA and the Customer password is CP
            if (cboLogin.SelectedIndex==0 &&  txtPswd.Text != "LA")
            {
                blnValidPswd = false;
                MessageBox.Show("Invalid admin password", "Error");
            }
            else
                if (cboLogin.SelectedIndex==1 &&  txtPswd.Text != "CP")
            {
                blnValidPswd = false;
                MessageBox.Show("Invalid customer password", "Error");
            }
            return blnValidPswd;
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear the form
            cboLogin.Text = string.Empty;
            txtPswd.Text = "";
            cboLogin.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the form
            Application.Exit();
        }

    }
}
