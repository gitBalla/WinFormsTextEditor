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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            ValidateLogin(username, password);
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

        internal void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void ValidateLogin(string username, string password)
        {
            //member variables
            string fileName = "login.txt";

            //validate input

            //validate the credentials
            try
            {
                //check file exists and is not empty
                Validator.IsFile(fileName);
                Validator.IsFileEmpty(fileName);
                Validator.ValidateCredentials(fileName, username, password);
                MessageBox.Show("Press OK to continue", "Login Successful!", MessageBoxButtons.OKCancel);
                Program.Context.LoadTextEditForm();
                this.Close();
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Ensure login file is present before relaunching.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ApplicationException e)
            {
                MessageBox.Show("Ensure login file has a valid user before relaunching.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Username or Password invalid, try again.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
