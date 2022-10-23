using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    static class Program
    {
        //Class member variables
        internal const string loginFile = "login.txt";

        //start from context to keep app open between forms, loads user list
        internal static MyApplicationContext Context = new MyApplicationContext();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Windows forms settings
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Start application
            Application.Run(Context);
        }
    }
}
