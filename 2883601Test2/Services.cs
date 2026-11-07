using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIIA2026ProgTest2
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

    
        // declare constants
        const double dblMedSizeMarkup = 0.05;
        const double dblLarSizeMarkup = 0.1;
        const double dblFertilisationPrice = 500;
        const double dblTreeFellingPrice = 1000;
        const double dblVATRate = 0.1; // 10% for ease of calculations
        //Create Count  Variable for invalid form 
        int inValForm;

        private void processServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declare local variables
            bool blnValidInput = true;
            double dblBaseCost = 0;
            double dblCost = 0;
            int intFrequency;
            string strStartDate;

            intFrequency = Convert.ToInt16(nudFrequency.Value);

            // call the method to validate the input
            blnValidInput = ValidateInput(blnValidInput, intFrequency);

            // continue if the input is valid
            if (blnValidInput == true)
            {
                // get the base cost of the service chosen
                int CorrIndex = cboService.SelectedIndex;
                dblBaseCost = ServiceArrayClass.BaseCost[CorrIndex];
               

             // call the method to determine the cost depending on the garden size   
                dblCost = DetermineSizeCost(dblBaseCost,dblCost);

             // calculate the cost using the frequency of the service
                dblCost = dblCost * intFrequency;

             // call the method to add on the extras required
                dblCost = AddExtras(dblCost);

             // add VAT to the cost, to get the total cost
                dblCost = dblCost + (dblCost * dblVATRate);

                // format the date for output - format should be day of the week (in full), 2-digit date and full name of the month
                strStartDate = dtpStartDate.Value.ToString("dddd dd MMMM");

             // call the method to display the output
                DisplayOutput(strStartDate,dblCost,intFrequency);
            }
            else
            { inValForm++; lblTotInvReq.Text = inValForm.ToString(); }

          
        }
        private bool ValidateInput(bool blnValidInput, int intFrequency)
        {
            // validate the input (see the question paper for the validation rules)
            // there is no need to code additional comments in this method
            if (cboService.SelectedIndex==-1)
            {
                blnValidInput = false;
                MessageBox.Show("please choose a service", "Error");
            }
            if (intFrequency != 1 && intFrequency != 2 && intFrequency != 4)
            {
                blnValidInput = false;
                MessageBox.Show("please enter the correct frequency", "Error");
            }
            if (dtpStartDate.Value < DateTime.Now.Date.AddDays(10))
            {
                blnValidInput = false;
                MessageBox.Show("please choose a date that is at least 10 days in advance", "Error");
            }
            if (radSmall.Checked == false && radMedium.Checked == false & radLarge.Checked == false)
            {
                blnValidInput = false;
                MessageBox.Show("please select the size of the garden", "Error");
            }
            return blnValidInput;
        }

        private double DetermineSizeCost(double dblBaseCost,double dblCost)
        {
            // calculate the cost depending on the size of the garden
            if (radMedium.Checked == true)
            { dblCost = dblBaseCost + (dblBaseCost * dblMedSizeMarkup); }
            else
                if (radLarge.Checked == true)
                { dblCost = dblBaseCost + (dblBaseCost * dblLarSizeMarkup); }
            else
                { dblCost = dblBaseCost; }

            return dblCost;
        }

        private double AddExtras(double dblCost)
        {
            // add to the cost depending on whether extras have been chosen
            if (chkFertilisation.Checked == true)
            { dblCost = dblCost + dblFertilisationPrice; }

            if (chkTreeFelling.Checked == true)
            { dblCost = dblCost + dblTreeFellingPrice; }

            return dblCost;
        }
        private void DisplayOutput(string strStarDate ,double dblCost , int intFrequency)
        {
            // display the output, using the label variables specified on the form
            lblPackage.Text = cboService.SelectedItem.ToString();
            lblStartDate.Text = strStarDate.ToString();
            lblFrequency.Text = intFrequency.ToString();
            lblTotalCost.Text = dblCost.ToString();
           
        }
        private void Services_Load(object sender, EventArgs e)
        {
            // this method loads the combo box from the service package array when the form loads
            int intArrayCount; ;

            for (intArrayCount = 0; intArrayCount < ServiceArrayClass.ServicePackage.Length; ++intArrayCount)
            {
                cboService.Items.Add(ServiceArrayClass.ServicePackage[intArrayCount]);
                
            }
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear the form except for the running total; place focus at the service
            cboService.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now;
            nudFrequency.Value = 0;
            radSmall.Checked = false;
            radMedium.Checked = false;
            radLarge.Checked = false;  
            chkTreeFelling.Checked = false;
            chkFertilisation.Checked = false;
            lblPackage.Text = ".....";
            lblStartDate.Text = ".....";
            lblFrequency.Text = ".....";
            cboService.Focus();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // go to the login/admin form
            LoginAdmin NewLoginAdmin = new LoginAdmin();
            this.Visible = false;
            NewLoginAdmin.ShowDialog();
        }
    }
}
