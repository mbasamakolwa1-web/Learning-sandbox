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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
        }
        const double dblVATRate = 0.15;
        const double dblWide = 100;
        const double dblLaces = 50;
        const double dblDecorated = 150;

        private void sneakerPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declare local variables
            int intQty;
            double dblAmount;

            double dblCost;
            bool blnValidInput = true;

            // convert the quantity  
            intQty = Convert.ToInt16(nudQuantity.Value);

            // call the method to validate the input
            blnValidInput = ValidateInput(intQty, blnValidInput);

            // continue processing if all the input is valid
            if (blnValidInput == true)
            {
                // format the date for output
                string formatDate = dtpDeliveryDate.Value.ToString("dddd dd MMMM yy");
                // get the cost of the sneaker chosen
                int index = cboSneaker.SelectedIndex;
                dblCost = ArrayClass.CostPrice[index];

                // calculate the amount
                dblAmount = (intQty * dblCost);

                // call the method to add extras
                dblAmount = AddExtras(dblAmount);

                // recalculate the amount
                dblAmount += dblAmount * dblVATRate;


                lblMessage1.Text = "You have bought " + intQty + "of" + cboSneaker.SelectedItem.ToString() + "to be delivered on " + formatDate;
                lblMessage2.Text = "Amount owing is " + dblAmount;
            }
        }

        private bool ValidateInput(int intQty, bool blnValidInput)
        {
            // this method validates the input on the form
            // the sneaker must be chosen
            if (cboSneaker.SelectedIndex==-1)
            {
                MessageBox.Show("Please select sneaker", "Input error");
                blnValidInput = false;
            }
            // the quantity must be greater than zero
            if (intQty <=0 )
            {
                MessageBox.Show("Please select quantity", "Input error");
                blnValidInput = false;
            }
           
            // the chosen delivery date must be at least 5 days from today 
            if (dtpDeliveryDate.Value < DateTime.Now.Date.AddDays(5))
            {
                blnValidInput = false;
                MessageBox.Show("Delivery date must be at least 5 days in advance", "Input error");
            }
            return blnValidInput;
        }

        private double AddExtras(double dblAmount)
        {
            // add extra amounts depending on the customer's choices
            if (chkWide.Checked)
            { dblAmount += dblWide; }
           
            if (chkLaces.Checked)
            { dblAmount += dblLaces; }
          
            if (chkDecorate.Checked)
            { dblAmount += dblDecorated; }

            return dblAmount;
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this method clears the form and sets focus to the sneaker selection
            // complete the code for this method; the cleared date should show today's date
            cboSneaker.SelectedIndex = -1;
            dtpDeliveryDate.Value = DateTime.Now;
            nudQuantity.Value = 0;
            chkWide.Checked = false;
            chkLaces.Checked = false;
            chkDecorate.Checked = false;
            lblMessage1.Text = "xxxxx";
            lblMessage2.Text = "xxxxx";
            cboSneaker.Focus();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // go to the login form
            LogAdm NewLogAdmin = new LogAdm();
            this.Visible = false;
            NewLogAdmin.ShowDialog();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            // this method loads the sneakers into the combo box from the array
            int Count;
            for (Count = 0; Count < ArrayClass.Sneaker.Length; ++Count)
            {
                cboSneaker.Items.Add(ArrayClass.Sneaker[Count]);
            }
                
        }
    }
}
