namespace MyThutorManagementSystem2
{
    partial class AdminForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AdminForm2
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "AdminForm2";
            this.Load += new System.EventHandler(this.AdminForm2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private Database8DataSet database8DataSet1;
        private Database8DataSetTableAdapters.TUTORTableAdapter tutorTableAdapter1;
        private Database8DataSetTableAdapters.TUTORINGREQUESTTableAdapter tutoringrequestTableAdapter1;
        private System.Windows.Forms.BindingSource tUTORBindingSource;
        private Database8DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button add;
        private Database8DataSetTableAdapters.STUDENTTableAdapter studentTableAdapter1;
        private System.Windows.Forms.TextBox tutorNoTextBox;
        private System.Windows.Forms.TextBox tutorIDTextBox;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordHashTextBox;
        private System.Windows.Forms.TextBox tutor_CourseTextBox;
        private System.Windows.Forms.TextBox tutoringModeTextBox;
        private System.Windows.Forms.DateTimePicker availableDateDateTimePicker;
        private System.Windows.Forms.ComboBox sessionTimeSlotComboBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
    }
}