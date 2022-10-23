using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    internal static class Validator
    {
        /* INPUT VALIDATION */

        // Check all given fields in a list for blank input
        internal static void ValidateFieldsCompleted<T>(List<(T, string)> fields)
        {
            foreach (var field in fields)
            {
                if (field.Item1.ToString() == "")
                    throw new IOException($"Missing '{field.Item2}' field! Please enter all fields.");
            }
        }

        // Check all given fields in a list for restricted input
        internal static void ValidateRestrictedInput<T>(List<(T, string)> fields)
        {
            var restrictedInput = new string[] { "," };

            foreach (var field in fields)
            {
                if (restrictedInput.Any(res => field.Item1.ToString().Contains(res)))
                    throw new IOException("Cannot use ',' in input");
            }
        }

        internal static void ValidateFieldsMatch<T>(T field1, string field1Descriptor, T field2, string field2Descriptor)
        {
            if (!field1.Equals(field2))
                throw new IOException($"'{field1Descriptor}' must match '{field2Descriptor}'.");
        }

        // Checks a file for matching user credentials listed during login
        internal static bool ValidateUserInput(string username, string password)
        {
            try
            {
                var fieldsList = new List<(string, string)>() {
                    ( username, "username" ),
                    ( password, "password" )
                };

                //check if fields have been filled in
                ValidateFieldsCompleted(fieldsList);

                //check that no restricted input was given
                ValidateRestrictedInput(fieldsList);

                return true;
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Validates new user input
        internal static bool ValidateNewUserInput(string[] fields, string passwordValidator)
        {
            try
            {
                var fieldsList = new List<(string, string)>() {
                    ( fields[0], "username" ),
                    ( fields[1], "password" ),
                    ( fields[2], "First Name" ),
                    ( fields[3], "Last Name" ),
                    ( fields[4], "Birthdate" ),
                    ( fields[5], "User-Type" ),
                };

                //check if fields have been filled in
                ValidateFieldsCompleted(fieldsList);

                //check that no restricted input was given
                ValidateRestrictedInput(fieldsList);

                ValidateFieldsMatch(fields[1], "Password", passwordValidator, "Re-enter Password");

                return true;
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /* FILE VALIDATION  */

        internal static void ValidateFileExists(string fileName)
        {
            try
            {
                //check if file exists
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException($"File {fileName} not found!\n\n");
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Ensure login file is present.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
