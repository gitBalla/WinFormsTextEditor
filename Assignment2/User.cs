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
    internal enum UserType { Edit, View }

    internal class User
    {
        string username, password, firstName, lastName;
        DateTime birthdate;
        UserType userType;

        //User constructor for register
        internal User(string username, string password, UserType userType, string firstName, string lastName, DateTime birthdate)
        {
            this.username = username;
            this.password = password;
            this.userType = userType;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthdate = birthdate;
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


        private void WriteUserLine(string fileName)
        {
            File.AppendAllText(fileName, $"\n{username},{password},{userType.ToString()},{firstName},{lastName},{birthdate}");
        }
    }
}
