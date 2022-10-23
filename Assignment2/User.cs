using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsTextEditor
{
    // Enums
    internal enum UserType { Edit, View }

    internal class User
    {
        // Member Variables
        string username, password, firstName, lastName;
        DateTime birthdate;
        UserType userType;

        //User constructor for loading all users
        internal User()
        {
            this.username = "";
            this.password = "";
            this.userType = UserType.Edit;
            this.firstName = "";
            this.lastName = "";
            this.birthdate = DateTime.MinValue;
        }

        //User constructor for login
        internal User(string[] fields)
        {
            this.username = fields[0];
            this.password = fields[1];
            Enum.TryParse<UserType>(fields[2], out this.userType);
            this.firstName = fields[3];
            this.lastName = fields[4];
            this.birthdate = Convert.ToDateTime(fields[5]);
        }

        internal string Username {
            get { return username; }
        }
        internal string FirstName {
            get { return firstName; }
        }

        // Method to append user data to a line of login.txt
        private void WriteUserLine()
        {
            File.AppendAllText(Program.loginFile, $"\n{username},{password},{userType},{firstName},{lastName},{birthdate}");
        }

        // Overide the ToString() method to display user details
        public override string ToString()
        {
            return (this.username + "," + this.password + "," + this.userType.ToString() + "," + this.firstName + "," + this.lastName + "," + this.birthdate.ToString("dd'-'MM'-'yyyy"));
        }

        // Method to convert a line from the login.txt to user data
        public void LoadUser(string fileLine)
        {
            // Split the comma seperated string into fields 
            string[] fields = fileLine.Split(',');

            // Assign fields to respective properties
            this.username = fields[0];
            this.password = fields[1];
            Enum.TryParse<UserType>(fields[2], out this.userType);
            this.firstName = fields[3];
            this.lastName = fields[4];
            this.birthdate = Convert.ToDateTime(fields[5]);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return (this.username == username && this.password == password);
        }
    }
}
