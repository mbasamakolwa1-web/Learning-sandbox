using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputBoxSample;

namespace _2883601C_MiniProject
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        public static string InputBox(string prompt, string title, string defaultValue)
        {
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            return s;
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {   //Declare  count varaible  including our  two  arrays 
            int intArrayCount;
            string[] ConcertNameArray = new string[3];
            double[] GoldenCirclePriceArray = new double[3];

            //Add  elements to  our  arrays   using  a  for loop  and inputboxes 
            for (intArrayCount = 0; intArrayCount < ConcertNameArray.Length; intArrayCount++)
            {
                ConcertNameArray[intArrayCount] = InputBox("Please Enter Concert Name ", "Concert Name Input", "");

                GoldenCirclePriceArray[intArrayCount] = Convert.ToDouble(InputBox("Please Enter Price ", "Price Input ", ""));


            }
            //This stores our arrays under the properties of BookingArrayClass1
            BookingArrayClass1.ConcertName = ConcertNameArray;
            BookingArrayClass1.GoldenCirclePrice = GoldenCirclePriceArray;
            
        }
        
        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            // declares a new instance of the Login form (which, by default, is not visible)
            Login  f1 = new Login();
            // makes the current form “invisible”
            this.Visible = false;
            // shows the new instance of the Login  form
            f1.ShowDialog();
        }
    }
}
