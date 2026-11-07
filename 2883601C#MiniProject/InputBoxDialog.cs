using System;
using System.Drawing;
using System.Windows.Forms;

namespace InputBoxSample
{
    public class InputBoxDialog : Form
    {
        #region Controls

        private Label lblPrompt;
        private TextBox txtInput;
        private Button btnOK;
        private Button btnCancel;
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructor

        public InputBoxDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Static InputBox Method

        public static string InputBox(string prompt, string title, string defaultValue)
        {
            using (InputBoxDialog ib = new InputBoxDialog())
            {
                ib.FormPrompt = prompt;
                ib.FormCaption = title;
                ib.DefaultValue = defaultValue;

                ib.ShowDialog();

                return ib.InputResponse;
            }
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region InitializeComponent

        private void InitializeComponent()
        {
            this.lblPrompt = new Label();
            this.txtInput = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblPrompt
            this.lblPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblPrompt.BackColor = SystemColors.Control;
            this.lblPrompt.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular);
            this.lblPrompt.Location = new Point(12, 9);
            this.lblPrompt.Size = new Size(302, 82);

            // txtInput
            this.txtInput.Location = new Point(8, 100);
            this.txtInput.Size = new Size(379, 20);

            // btnOK
            this.btnOK.Location = new Point(320, 10);
            this.btnOK.Size = new Size(75, 25);
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new EventHandler(this.BtnOKClick);

            // btnCancel
            this.btnCancel.Location = new Point(320, 41);
            this.btnCancel.Size = new Size(75, 25);
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Click += new EventHandler(this.BtnCancelClick);

            // Form
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(398, 128);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Load += new EventHandler(this.InputBox_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Private Variables

        private string formCaption = string.Empty;
        private string formPrompt = string.Empty;
        private string inputResponse = string.Empty;
        private string defaultValue = string.Empty;

        #endregion

        #region Public Properties

        public string FormCaption
        {
            get { return formCaption; }
            set { formCaption = value; }
        }

        public string FormPrompt
        {
            get { return formPrompt; }
            set { formPrompt = value; }
        }

        public string InputResponse
        {
            get { return inputResponse; }
            set { inputResponse = value; }
        }

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        #endregion

        #region Events

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.Text = formCaption;
            this.lblPrompt.Text = formPrompt;
            this.txtInput.Text = defaultValue;

            this.txtInput.SelectionStart = 0;
            this.txtInput.SelectionLength = this.txtInput.Text.Length;
            this.txtInput.Focus();
        }

        private void BtnOKClick(object sender, EventArgs e)
        {
            InputResponse = txtInput.Text;
            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}