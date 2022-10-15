using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsTextEditor
{
    internal class FormProvider
    {
        /// <summary>
        ///  Singleton pattern for managing form windows
        /// </summary>
        public static LoginForm Login
        {
            get
            {   //if login doesn't exist, make one, then return
                login ??= new LoginForm();
                return login;
            }
        }
        private static LoginForm login;

        public static TextEditForm TextEdit
        {
            get
            {   //if text editor doesn't exist, make one, then return
                textEdit ??= new TextEditForm();
                return textEdit;
            }
        }
        private static TextEditForm textEdit;
    }
}
