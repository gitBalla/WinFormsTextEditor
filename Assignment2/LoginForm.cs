using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        internal void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Validate that user input is not blank, and doesn't violate any restrictions
            if (Validator.ValidateUserInput(username, password))
            {
                //authenticate the user
                User user = Program.Context.UserList.GetUser(username, password);

                // Close Login form and open editor if successful
                if (user != null) {
                    MessageBox.Show($"Hello, {user.FirstName}. Press OK to continue", "Login Successful!", MessageBoxButtons.OK);
                    Program.Context.LoadTextEditForm(user);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Username or Password invalid, try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Otherwise clear password
            PasswordTextBox.Clear();
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            Program.Context.LoadRegisterForm();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
