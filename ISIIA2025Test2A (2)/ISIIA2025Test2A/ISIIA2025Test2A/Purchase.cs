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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
        }
        const double dblMedMarkUp = 0.01;
        const double dblLargeMarkUp = 0.02;
        const double dblXLargeMarkUp = 0.05;
        const double dblVATRate = 0.15;

        private void denimPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declare local variables
            int intQty;
            double dblAmount;
            string strDeliveryDate;
            
            double dblCost;
            bool blnValidInput = true;

            // convert the quantity  
            intQty =Convert.ToInt32( nudQuantity.Value) ;

            // call the method to validate the input
            blnValidInput = ValidateInput(intQty, blnValidInput);

            // continue processing if all the input is valid
            if (blnValidInput == true)
            {
                // format the date for output
                strDeliveryDate = dtpDeliveryDate.Value.ToString("dddd dd MM yy");

                // get the cost of the item chosen
                int selectedIndex = cboDenimItem.SelectedIndex;
                dblCost = ArrayClass.ItemCost[selectedIndex];

                // call the method to calculate the actual cost
                dblCost = CalcCost(dblCost);
                              
                // calculate the final amount
                dblAmount = (intQty * dblCost);
                dblAmount += dblAmount * dblVATRate;


                lblMessage1.Text = "You have bought " + intQty + "of" + cboDenimItem.SelectedItem.ToString() + "to be delivered on " + strDeliveryDate;
                lblMessage2.Text = "Amount owing is " + dblAmount;
            }
        }
            private bool ValidateInput(int intQty, bool blnValidInput)
            {
                // this method validates the input on the form
                // the denim item must be chosen
                if (cboDenimItem.SelectedIndex==-1)
                {
                    MessageBox.Show("Please select denim item", "Input error");
                    blnValidInput = false;
                }
                // the quantity must be greater than zero
                if (intQty <=0)
                {
                    MessageBox.Show("Please select quantity", "Input error");
                    blnValidInput = false;
                }
                // the size must be chosen 
                if (radSmall.Checked == false && radMedium.Checked == false && radLarge.Checked == false && radXLarge.Checked == false)
                {
                    MessageBox.Show("Please select the size", "Input error");
                    blnValidInput = false;
                }
                // the chosen delivery date must be at least 10 days from today 
                if (dtpDeliveryDate.Value < DateTime.Now.AddDays(10))
                {
                blnValidInput = false;
                MessageBox.Show("Delivery date must be at least 10 days in advance", "Input error"); 
                }
            return blnValidInput;
            }

        private double CalcCost(double dblCost)
        {
            // calculate the actual cost depending on the size
            if (radMedium.Checked)
            { dblCost += dblCost * dblMedMarkUp; }
            else
            if (radLarge.Checked)
            { dblCost += dblCost * dblLargeMarkUp; }
            else
            if (radXLarge.Checked)
            { dblCost += dblCost * dblXLargeMarkUp; }

            return dblCost;
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this method clears the form and sets focus to the denim item
            // complete the code for this method; the cleared date should show today's date
            cboDenimItem.SelectedIndex =-1;
            dtpDeliveryDate.Value = DateTime.Now;
                nudQuantity.Value = 0;
                radSmall.Checked = false;
                radMedium.Checked = false;
                radLarge.Checked = false;
                radXLarge.Checked = false;
                lblMessage1.Text = "xxxxx";
                lblMessage2.Text = "xxxxx";
                cboDenimItem.Focus();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            // this method loads the denim items into the combo box from the array
            int Count;
            for (Count = 0; Count < ArrayClass.DenimItem.Length; ++Count)
            {
                cboDenimItem.Items.Add(ArrayClass.DenimItem[Count]);
            }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // go to the login form
            LogAdmin NewLogAdmin = new LogAdmin();
            this.Visible = false;
            NewLogAdmin.ShowDialog();
        }
    }
}
