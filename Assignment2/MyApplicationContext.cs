using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsTextEditor
{
    internal class MyApplicationContext : ApplicationContext
    {
        private int formCount;
        private static LoginForm login;
        private static TextEditForm textEdit;
        private static RegisterForm register;

        internal MyApplicationContext()
        {
            formCount = 0;

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            login = new LoginForm();
            login.Closed += new EventHandler(OnFormClosed);
            formCount++;
            login.Show();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //do data saving here
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
            textEdit = new TextEditForm();
            textEdit.CurrentUser = user;
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
