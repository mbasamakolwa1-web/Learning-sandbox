using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyThutorManagementSystem2
{
    public partial class StudentForm2 : Form
    {
        private readonly string studentID;

        public StudentForm2(string userID)
        {
            InitializeComponent();

            studentID = userID;
        }
        public StudentForm2()
        {
            InitializeComponent();
        }

        private void StudentForm2_Load(object sender, EventArgs e)
        {

        }
    }
}
