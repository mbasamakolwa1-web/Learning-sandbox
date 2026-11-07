namespace _2883601C_MiniProject
{
    partial class Booking
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comBoxConcert = new System.Windows.Forms.ComboBox();
            this.numberPeople = new System.Windows.Forms.NumericUpDown();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDUR = new System.Windows.Forms.RadioButton();
            this.radCPT = new System.Windows.Forms.RadioButton();
            this.radJHN = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSeated = new System.Windows.Forms.RadioButton();
            this.radGenStanding = new System.Windows.Forms.RadioButton();
            this.radGoldenCrl = new System.Windows.Forms.RadioButton();
            this.chkProgramme = new System.Windows.Forms.CheckBox();
            this.chkExtras = new System.Windows.Forms.CheckBox();
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPeople)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bookingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.BtnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(180, 22);
            this.BtnExit.Text = "Exit";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.bookingToolStripMenuItem.Text = "Booking";
            this.bookingToolStripMenuItem.Click += new System.EventHandler(this.bookingToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Concert";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "COLOSSAL CONCERTS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Number of People";
            // 
            // comBoxConcert
            // 
            this.comBoxConcert.FormattingEnabled = true;
            this.comBoxConcert.Location = new System.Drawing.Point(199, 109);
            this.comBoxConcert.Name = "comBoxConcert";
            this.comBoxConcert.Size = new System.Drawing.Size(121, 21);
            this.comBoxConcert.TabIndex = 5;
            // 
            // numberPeople
            // 
            this.numberPeople.Location = new System.Drawing.Point(200, 167);
            this.numberPeople.Name = "numberPeople";
            this.numberPeople.Size = new System.Drawing.Size(120, 20);
            this.numberPeople.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(199, 236);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDUR);
            this.groupBox1.Controls.Add(this.radCPT);
            this.groupBox1.Controls.Add(this.radJHN);
            this.groupBox1.Location = new System.Drawing.Point(420, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 118);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "City";
            // 
            // radDUR
            // 
            this.radDUR.AutoSize = true;
            this.radDUR.Location = new System.Drawing.Point(6, 78);
            this.radDUR.Name = "radDUR";
            this.radDUR.Size = new System.Drawing.Size(60, 17);
            this.radDUR.TabIndex = 9;
            this.radDUR.TabStop = true;
            this.radDUR.Text = "Durban";
            this.radDUR.UseVisualStyleBackColor = true;
            // 
            // radCPT
            // 
            this.radCPT.AutoSize = true;
            this.radCPT.Location = new System.Drawing.Point(6, 55);
            this.radCPT.Name = "radCPT";
            this.radCPT.Size = new System.Drawing.Size(80, 17);
            this.radCPT.TabIndex = 1;
            this.radCPT.TabStop = true;
            this.radCPT.Text = "Cape Town";
            this.radCPT.UseVisualStyleBackColor = true;
            // 
            // radJHN
            // 
            this.radJHN.AutoSize = true;
            this.radJHN.Location = new System.Drawing.Point(6, 22);
            this.radJHN.Name = "radJHN";
            this.radJHN.Size = new System.Drawing.Size(92, 17);
            this.radJHN.TabIndex = 0;
            this.radJHN.TabStop = true;
            this.radJHN.Text = "Johannesburg";
            this.radJHN.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSeated);
            this.groupBox2.Controls.Add(this.radGenStanding);
            this.groupBox2.Controls.Add(this.radGoldenCrl);
            this.groupBox2.Location = new System.Drawing.Point(681, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 118);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seating";
            // 
            // radSeated
            // 
            this.radSeated.AutoSize = true;
            this.radSeated.Location = new System.Drawing.Point(6, 80);
            this.radSeated.Name = "radSeated";
            this.radSeated.Size = new System.Drawing.Size(59, 17);
            this.radSeated.TabIndex = 10;
            this.radSeated.TabStop = true;
            this.radSeated.Text = "Seated";
            this.radSeated.UseVisualStyleBackColor = true;
            // 
            // radGenStanding
            // 
            this.radGenStanding.AutoSize = true;
            this.radGenStanding.Location = new System.Drawing.Point(6, 55);
            this.radGenStanding.Name = "radGenStanding";
            this.radGenStanding.Size = new System.Drawing.Size(107, 17);
            this.radGenStanding.TabIndex = 11;
            this.radGenStanding.TabStop = true;
            this.radGenStanding.Text = "General Standing";
            this.radGenStanding.UseVisualStyleBackColor = true;
            // 
            // radGoldenCrl
            // 
            this.radGoldenCrl.AutoSize = true;
            this.radGoldenCrl.Location = new System.Drawing.Point(6, 22);
            this.radGoldenCrl.Name = "radGoldenCrl";
            this.radGoldenCrl.Size = new System.Drawing.Size(88, 17);
            this.radGoldenCrl.TabIndex = 10;
            this.radGoldenCrl.TabStop = true;
            this.radGoldenCrl.Text = "Golden Circle";
            this.radGoldenCrl.UseVisualStyleBackColor = true;
            // 
            // chkProgramme
            // 
            this.chkProgramme.AutoSize = true;
            this.chkProgramme.Location = new System.Drawing.Point(420, 309);
            this.chkProgramme.Name = "chkProgramme";
            this.chkProgramme.Size = new System.Drawing.Size(88, 17);
            this.chkProgramme.TabIndex = 10;
            this.chkProgramme.Text = "Programme ?";
            this.chkProgramme.UseVisualStyleBackColor = true;
            // 
            // chkExtras
            // 
            this.chkExtras.AutoSize = true;
            this.chkExtras.Location = new System.Drawing.Point(666, 309);
            this.chkExtras.Name = "chkExtras";
            this.chkExtras.Size = new System.Drawing.Size(111, 17);
            this.chkExtras.TabIndex = 11;
            this.chkExtras.Text = "Limo and Drinks ?";
            this.chkExtras.UseVisualStyleBackColor = true;
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.AutoSize = true;
            this.lblConfirmation.Location = new System.Drawing.Point(70, 352);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(42, 13);
            this.lblConfirmation.TabIndex = 12;
            this.lblConfirmation.Text = "XXXXX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "The   total cost  will  be ";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(224, 409);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(28, 13);
            this.lblTotalCost.TabIndex = 14;
            this.lblTotalCost.Text = "0.00";
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblConfirmation);
            this.Controls.Add(this.chkExtras);
            this.Controls.Add(this.chkProgramme);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.numberPeople);
            this.Controls.Add(this.comBoxConcert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Booking";
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.Booking_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPeople)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnExit;
        private System.Windows.Forms.ToolStripMenuItem bookingToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comBoxConcert;
        private System.Windows.Forms.NumericUpDown numberPeople;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radDUR;
        private System.Windows.Forms.RadioButton radCPT;
        private System.Windows.Forms.RadioButton radJHN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radSeated;
        private System.Windows.Forms.RadioButton radGenStanding;
        private System.Windows.Forms.RadioButton radGoldenCrl;
        private System.Windows.Forms.CheckBox chkProgramme;
        private System.Windows.Forms.CheckBox chkExtras;
        private System.Windows.Forms.Label lblConfirmation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalCost;
    }
}