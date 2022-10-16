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
        ///  Uses '??=' null coalescing operator to instantiate if null
        /// </summary>

        private static LoginForm login;
        private static TextEditForm textEdit;
        private static RegisterForm register;

        public static LoginForm Login
        { //return login after making one if it doesn't exist
            get { return login ??= new LoginForm(); }
        }

        public static TextEditForm TextEdit
        { //return text editor after making one if it doesn't exist
            get { return textEdit ??= new TextEditForm(); }
        }

        public static RegisterForm Register
        {
            //return register form after making one if it doesn't exist
            get { return register ??= new RegisterForm(); }
        }
    }
}
