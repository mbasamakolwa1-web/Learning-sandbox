using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassExample2it_schai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //declare the constant
        const double SomeOrOtherRate = 0.04;
        private void button1_Click(object sender, EventArgs e)
        {
         //declare the variables
            double dblQty;
            double dblPrice;
            double dblValue;
            double dblLess;
            //Convert the input into numerics
            dblQty = Convert.ToDouble(txtQty.Text);
            dblPrice = Convert.ToDouble(txtPrice.Text);
            //Perform the calculation
            dblValue = dblQty * dblPrice;
            dblLess = dblValue * SomeOrOtherRate;
            dblValue = dblValue - dblLess;
            //convert the calculated value into the required format(currency with 2 decimal places)
            lblValue.Text = dblValue.ToString("C2");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQty.Clear();
            txtPrice.Clear();
            lblValue.Text = ("");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
