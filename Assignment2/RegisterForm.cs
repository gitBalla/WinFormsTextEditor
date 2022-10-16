using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    public partial class RegisterForm : Form
    {
        enum UserType { Edit, View }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            UserTypeComboBox.DataSource = Enum.GetValues(typeof(UserType));
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registration Cancelled.", "Registration", MessageBoxButtons.OK);
            Program.Context.LoadLoginForm();
            this.Close();
        }
    }
}
