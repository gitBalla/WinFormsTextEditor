using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    internal class Login
    {
        internal static void ValidateLogin(string username, string password)
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
                FormProvider.Login.Hide();
                FormProvider.TextEdit.Show();
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
