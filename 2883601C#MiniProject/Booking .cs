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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
        //Declare our constants 
        const double ProgramPrice = 150;
        const double ExtrasPrice = 1500;
        const double StandingRate = 0.8;
        const double SeatedRate = 0.75;
        private void Booking_Load(object sender, EventArgs e)
        {
            //Adding public array elements to local array/comboBox

            int intArrayCount;
            for (intArrayCount = 0; intArrayCount < BookingArrayClass1.ConcertName.Length; intArrayCount++)
            {
                comBoxConcert.Items.Add(BookingArrayClass1.ConcertName[intArrayCount]);
            }

        }
        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare local  variables 
            double TicketPrice = 0;
            double TotalPrice = 0;
            int NoPeople =Convert.ToInt32(numberPeople.Value);
            string city = "";
            bool blnValidForm = true;
            blnValidForm = ValidateFormInputs(blnValidForm,NoPeople);
            if (blnValidForm == true)
            {
                //Getting  base  price for  concert  based  on  index position 
                int selectedindex = comBoxConcert.SelectedIndex;
                double GoldenPrice = BookingArrayClass1.GoldenCirclePrice[selectedindex];

                //Calculations based  on Seating  arrangement
                TicketPrice = CalcTicketPrice(TicketPrice, GoldenPrice);

                TotalPrice = TicketPrice * NoPeople;
                //Adding  costs  for  complimentary options 
                if (chkProgramme.Checked)
                { TotalPrice += ProgramPrice; }
                if (chkExtras.Checked)
                { TotalPrice += ExtrasPrice; }
                //Date Formating
                string formattedDate = dtpDate.Value.ToString("dddd dd MMMM yyyy");
                //Getting  name   of  city  for  confirmation 
                city = GetCity(city);
                //User Interface  outputs 

                DisplayOut(NoPeople, formattedDate, city, TotalPrice);
                
            }
        }
        private bool ValidateFormInputs(bool blnValidForm,int NoPeople )
        {
            //Validation  for  all   form  inputs 
            if (comBoxConcert.SelectedIndex == -1)
            {
                blnValidForm = false;
                MessageBox.Show("Please Select Concert", "Concert Error");
                return blnValidForm;
            }
            if (NoPeople <= 0)
            {
                blnValidForm = false;
                MessageBox.Show("Plese Select Number of  People ", "NoPeople Error");
                return blnValidForm;
            }
            if (dtpDate.Value.Date < DateTime.Now.Date.AddDays(14))
            {
                blnValidForm = false;
                MessageBox.Show("Please  Select a Valid Date", "Date Error");
                return blnValidForm;
            }
            if (!radJHN.Checked && !radCPT.Checked && !radDUR.Checked)
            {
                blnValidForm = false;
                MessageBox.Show("Please Select a  City ", "City Error");
                return blnValidForm;
            }
            if (!radGoldenCrl.Checked && !radGenStanding.Checked && !radSeated.Checked)
            {
                blnValidForm = false;
                MessageBox.Show("Please Select a Seat", "Seating Error");
                return blnValidForm;
            }
            return blnValidForm;
        }
        private double CalcTicketPrice(double TicketPrice, double GoldenPrice)
        {
            //Calculations based  on Seating  arrangement
            if (radGoldenCrl.Checked)
            { TicketPrice = GoldenPrice; }
            else
                if (radGenStanding.Checked)
            { TicketPrice = GoldenPrice * StandingRate; }
            else
                if (radSeated.Checked)
            { TicketPrice = GoldenPrice * SeatedRate; }
            return TicketPrice;

        }
        private string GetCity(string city)
        {
            
            if (radJHN.Checked)
            { city = "Johannesburg"; }
            else if (radCPT.Checked)
            { city = "Cape Town"; }
            else if (radDUR.Checked)
            { city = "Durban"; }
            return city;
        }
        private void DisplayOut(int NoPeople, string formattedDate, string city, double TotalPrice)
        {   //Display for  our  confirmation message 
            lblConfirmation.Text = "You have booked " + NoPeople +
                       " tickets for " + comBoxConcert.SelectedItem.ToString() +
                       " on " + formattedDate +
                       " in " + city;
            //Form display  for the  total cost 
            lblTotalCost.Text = TotalPrice.ToString("C");


        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clearing our form inputs 
            comBoxConcert.SelectedIndex = -1;
            numberPeople.Value=0;
            lblConfirmation.Text = "XXXXX";
            lblTotalCost.Text = "0.00";
            dtpDate.Value = DateTime.Now;
            radJHN.Checked = false;
            radCPT.Checked = false;
            radDUR.Checked = false;
            radGoldenCrl.Checked = false;
            radGenStanding.Checked = false;
            radSeated.Checked = false;
            comBoxConcert.Focus();




        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //Closing the entire  program 
            Application.Exit();
        }
    }
}