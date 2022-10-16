using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WinFormsTextEditor
{
    internal static class Validator
    {
        /* INPUT RESTRICTION */

        //checks key input for legitimate characters
        internal static bool IsCharInput(ConsoleKeyInfo key)
        {
            return ((((int)key.Key) >= 65 && ((int)key.Key <= 90)) ||
                (((int)key.Key) >= 106 && ((int)key.Key <= 107)) ||
                (((int)key.Key) >= 109 && ((int)key.Key <= 111)) ||
                IsNumInput(key, 0, 9) //0, 9 allows all input 0-9
                );
        }

        //checks key input for legitimate numbers
        internal static bool IsNumInput(ConsoleKeyInfo key, int start, int limit)
        {
            return ((((int)key.Key) >= (48 + start) && ((int)key.Key <= (48 + limit))) ||
                (((int)key.Key) >= (96 + start) && ((int)key.Key <= (96 + limit)))
                );
        }

        /* INPUT VALIDATION */

        internal static void IsFieldComplete(string field, string descriptor)
        {
            if (field == "") throw new IOException($"Missing '{descriptor}' field! Please enter all fields.\n\n");
        }

        //unused at the moment, planned feature email print preview
        internal static void IsEmailValid(String entry)
        {
            //basic regex (alphanumeric > 1 digit, @, alpha > 1 digit, ., alpha > 1 digit, ., alpha between 1-4 digits)
            var regex = new Regex(@"[a-zA-Z0-9-]{1,}@([a-zA-Z\.])?[a-zA-Z]{1,}\.[a-zA-Z]{1,4}");
            var match = regex.Match(entry);
            if (!match.Success)
            {
                throw new IOException("Invalid Email! Try name@domain.com or .com.au\n\n");
            }
        }

        //check entry is a valid 6-10 digit integer
        internal static void IsIntValid(string entry, string name)
        {
            bool success = (int.TryParse(entry, out _)) && entry.Length >= 6 && entry.Length <= 10;
            if (!success)
            {
                throw new IOException($"Invalid {name} Number! Must be 6 to 10 numeric digits.\n\n");
            }
        }

        //checks a file for matching user credentials listed as user|password
        internal static void ValidateCredentials(string fileName, string user, string password)
        {
            //read each line of the file
            foreach (string line in File.ReadLines(fileName))
            {
                //split the credentials and compare each, return if validated
                string[] credentials = line.Split(',');
                if (credentials[0].Equals(user))
                {
                    if (credentials[1].Equals(password)) return;
                }
            }
            //throws if no validation occurs
            throw new IOException("Invalid Credentials!\n\n");
        }

        /* FILE VALIDATION  */

        internal static bool IsFile(string fileName)
        {
            //check if file exists
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File {fileName} not found!\n\n");
            }

            return true;
        }

        internal static bool IsFileEmpty(string fileName)
        {
            //check if file is not empty
            if (new FileInfo(fileName).Length == 0)
            {
                throw new ApplicationException($"File {fileName} is empty!\n\n");
            }

            return false;
        }
    }
}
