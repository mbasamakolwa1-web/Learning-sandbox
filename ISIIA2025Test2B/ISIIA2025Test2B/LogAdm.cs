using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIIA2025Test2B
{
    public partial class LogAdm : Form
    {
        public LogAdm()
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
        // enter your student number as a comment
        private void loginAddItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declare local variables
            
            bool blnValidPswd = true;
            int intSelectedIndex = 0;

            // call the method to validate the passwords
            blnValidPswd = ValidatePassword(blnValidPswd,intSelectedIndex);

            if (blnValidPswd == true)
            {    // if Admin is chosen - use the index
                if (cboLogin.SelectedIndex==0)
                {
                    // declate the array in this context
                    string[] NewSneaker = new string[3];
                    double[] NewCostPrice = new double[3];

                    // declare the array count
                    int intArrayCount;

                    // loop to fill the arrays
                    for (intArrayCount = 0; intArrayCount < NewSneaker.Length; ++intArrayCount)
                    {
                        // enter the details of 3 types of sneakers & 3 corresponding cost prices from input boxes into 2 separate arrays 
                        NewSneaker[intArrayCount] = InputBox("Please Enter Sneaker", "SneakerInput", "");
                        NewCostPrice[intArrayCount] = Convert.ToDouble(InputBox("Please Enter Price ", "PriceInput", ""));
                       
                    }
                    //assign to the public arrays
                    ArrayClass.Sneaker = NewSneaker;
                    ArrayClass.CostPrice = NewCostPrice;

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
        private bool ValidatePassword(bool blnValidPswd,int intSelectedIndex)
        {
            intSelectedIndex = cboLogin.SelectedIndex;
            // this method validates the passwords - the LoginAdmin password is LA and the Customer password is CP
            if (intSelectedIndex==0 && txtPswd.Text!="LA")
            {
                blnValidPswd = false;
                MessageBox.Show("Invalid Admin Password", "Error");
            }
            else
                if (intSelectedIndex==1 && txtPswd.Text!="CP")
            {
                blnValidPswd = false;
                MessageBox.Show("Invalid Customer Password", "Error");
            }
            return blnValidPswd;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cboLogin.SelectedIndex = -1;
            txtPswd.Clear();
            cboLogin.Focus();
        }
    }
}
