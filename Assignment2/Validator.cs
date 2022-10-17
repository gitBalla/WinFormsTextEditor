using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsTextEditor
{
    internal static class Validator
    {
        /* INPUT VALIDATION */

        internal static void IsFieldComplete(string field, string descriptor)
        {
            if (field == "") 
                throw new IOException($"Missing '{descriptor}' field! Please enter all fields.\n\n");
        }

        //checks a file for matching user credentials listed as user|password
        internal static string[] GetValidUser(string username, string password)
        {
            try
            {
                //check if fields have been filled in
                IsFieldComplete(username, "username");
                IsFieldComplete(password, "password");

                //check file exists and is not empty
                IsFileValid(Program.loginFile);

                //find the user validate password
                int userLine = GetUserLineNumber(username);
                if (userLine >= 0)
                {
                    string[] credentials = File.ReadLines(Program.loginFile).Skip(userLine - 1).FirstOrDefault().Split(',');
                    if (credentials[1].Equals(password)) return credentials;
                }
                else
                {
                    MessageBox.Show("Username or Password invalid, try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Ensure login file is present.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ApplicationException e)
            {
                MessageBox.Show("Ensure login file has a valid user.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Enter all fields to login.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        internal static bool IsUserValid(string[] fields)
        {
            try
            {
                //check if fields have been filled in
                IsFieldComplete(fields[0], "Username");
                IsFieldComplete(fields[1], "Password");
                IsFieldComplete(fields[2], "First Name");
                IsFieldComplete(fields[3], "Last Name");
                IsFieldComplete(fields[4], "Birthdate");
                IsFieldComplete(fields[5], "User-Type");

                //check file exists and is not empty
                IsFileValid(Program.loginFile);

                //check user doesn't already exist
                int userLine = GetUserLineNumber(fields[0]);
                if (userLine < 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Username already exists.\nPlease login or try another username", "Registration Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Ensure login file is present.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ApplicationException e)
            {
                MessageBox.Show("Ensure login file has a valid user.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Enter all fields to login.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        internal static int GetUserLineNumber(string username)
        {
            //read each line of the file and get the line number of the user
            int lineNum = 0;
            foreach (string line in File.ReadLines(Program.loginFile))
            {   //split the credentials and compare each, return lineNum if validated
                string[] credentials = line.Split(',');
                if (credentials[0].Equals(username))
                {
                    return lineNum;
                }
                lineNum++;
            }
            return -1;
        }

        /* FILE VALIDATION  */

        internal static bool IsFileValid(string fileName)
        {
            //check if file exists
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File {fileName} not found!\n\n");
            }

            //check if file is not empty
            if (new FileInfo(fileName).Length == 0)
            {
                throw new ApplicationException($"File {fileName} is empty!\n\n");
            }

            return true;
        }
    }
}
