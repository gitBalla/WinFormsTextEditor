using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsTextEditor
{
    internal class UserList
    {
        // Member Variables
        private static List<User> users;

        // Constructor
        public UserList()
        {
            users = new List<User>();
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Method to read each user from login.txt
        public void LoadUsers()
        {
            // Create temp user for each user to be loaded in
            User tempUser;

            // Read the file content using the StreamReader
            StreamReader fileContent = new StreamReader(Program.loginFile);

            // Read the file till the last line with a streamreader
            while (!fileContent.EndOfStream)
            {
                string line = fileContent.ReadLine();
                // Use the line to create a user 
                tempUser = new User();
                tempUser.LoadUser(line);
                // Add the temp user to the list of users
                users.Add(tempUser);
            }
            // Close the file streamreader
            fileContent.Close();
        }

        public void SaveUsers()
        {
            var userData = new StringBuilder();

            foreach (User tempUser in users)
            {
                userData.AppendLine(tempUser.ToString());
            }
            File.WriteAllText(Program.loginFile, userData.ToString());
        }

        public User GetUser(string username, string password)
        {
            // Authenticate user login against each user until found
            foreach (User user in users)
            {
                if (user.AuthenticateUser(username, password))
                {
                    return user;
                }
            }
            return null;
        }

        public bool IsUser(string username)
        {
            // Check each user in userlist
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
