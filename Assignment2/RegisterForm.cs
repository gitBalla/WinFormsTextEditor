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
            string[] fields = new string[] {
                    UsernameTextBox.Text,
                    PasswordTextBox.Text,
                    UserTypeComboBox.Text.ToString(),
                    FirstNameTextBox.Text,
                    LastNameTextBox.Text,
                    BirthdateDateTimePicker.Value.ToString(),
                };

            //check if new user is valid
            if (Validator.IsUserValid(fields))
            {
                User user = new User(fields);
                MessageBox.Show($"Hello, {user.FirstName}. Press OK to continue", "Registration Successful!", MessageBoxButtons.OK);
                Program.Context.LoadTextEditForm(user);
                this.Close();
            }
            else
            {
                PasswordTextBox.Clear();
                ReEnterPasswordTextBox.Clear();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registration Cancelled.", "Registration", MessageBoxButtons.OK);
            Program.Context.LoadLoginForm();
            this.Close();
        }

        private void BirthdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
