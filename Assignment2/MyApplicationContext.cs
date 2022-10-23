using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsTextEditor
{
    internal class MyApplicationContext : ApplicationContext
    {
        // Member Variables
        private static int formCount;
        private static LoginForm login;
        private static TextEditForm textEdit;
        private static RegisterForm register;
        internal static UserList userList;

        // Constructor
        internal MyApplicationContext()
        {
            // Keep track of forms so application doesn't close until all forms are closed
            formCount = 0;

            // delegate to manage saving user data at application exit
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            //Ensure login file is in bin directory
            Validator.ValidateFileExists(Program.loginFile);

            // Load users at start
            userList = new UserList();
            userList.LoadUsers();

            // Start login form
            login = new LoginForm();
            login.Closed += new EventHandler(OnFormClosed);
            formCount++;
            login.Show();
        }

        public UserList UserList {
            get { return userList; }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            
        }

        internal void OnFormClosed(object sender, EventArgs e)
        {
            formCount--;
            if (formCount == 0) ExitThread();
        }

        internal void LoadLoginForm()
        {
            formCount++;
            login = new LoginForm();
            login.Closed += new EventHandler(OnFormClosed);
            login.Show();
        }

        internal void LoadTextEditForm(User user)
        {
            formCount++;
            textEdit = new TextEditForm
            {
                CurrentUser = user
            };
            textEdit.Closed += new EventHandler(OnFormClosed);
            textEdit.Show();
        }

        internal void LoadRegisterForm()
        {
            formCount++;
            register = new RegisterForm();
            register.Closed += new EventHandler(OnFormClosed);
            register.Show();
        }
    }
}
