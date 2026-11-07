namespace _2883601ClassExample1Thefirstone
{
    partial class Form1
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
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTableNo = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessage1
            // 
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Location = new System.Drawing.Point(155, 51);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(44, 16);
            this.lblMessage1.TabIndex = 0;
            this.lblMessage1.Text = "Name";
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Location = new System.Drawing.Point(155, 126);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(94, 16);
            this.lblMessage2.TabIndex = 1;
            this.lblMessage2.Text = "Table Number";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(424, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtTableNo
            // 
            this.txtTableNo.Location = new System.Drawing.Point(424, 123);
            this.txtTableNo.Name = "txtTableNo";
            this.txtTableNo.Size = new System.Drawing.Size(100, 22);
            this.txtTableNo.TabIndex = 3;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(424, 308);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(174, 308);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(656, 308);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtTableNo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblMessage2);
            this.Controls.Add(this.lblMessage1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTableNo;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
    }
}

