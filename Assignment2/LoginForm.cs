using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            Login.ValidateLogin(username, password);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            FormProvider.Login.Hide();
            Application.Exit(); //remove and uncomment below when register implemented
            //FormProvider.Register.Show();
        }

        private void LoginForm_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
