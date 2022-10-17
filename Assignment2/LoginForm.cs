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

            //approves login if valid credentials given, otherwise sends to retry
            string[] userFields = Validator.GetValidUser(username, password);
            if (userFields != null)
            {
                User user = new User(userFields);
                MessageBox.Show($"Hello, {user.FirstName}. Press OK to continue", "Login Successful!", MessageBoxButtons.OK);
                Program.Context.LoadTextEditForm(user);
                this.Close();
            }
            else
            {
                PasswordTextBox.Clear();
            }
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
