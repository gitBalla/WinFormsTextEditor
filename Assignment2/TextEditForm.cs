using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    public partial class TextEditForm : Form
    {
        internal User CurrentUser {get;set;}
        string filename;
        object[] fontRange = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        //Constructor
        public TextEditForm()
        {
            InitializeComponent();
            filename = NextFileName();
        }

        // actions on form load-in
        private void TextEditForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = CurrentUser.Username;
            UpdateUsernameLabel("Unsaved File");
            fontSizeToolStripComboBox.Items.AddRange(fontRange);
            fontSizeToolStripComboBox.Text = "12";
        }

        // updates username label
        private void UpdateUsernameLabel(string currentFileName)
        {
            usernameLabel.Text = CurrentUser.Username + ": " + currentFileName;
        }

        // helper function to get the next file name based on what exists in the auto save folder
        private string NextFileName()
        {
            int fileNumberSeed = 1;
            while (File.Exists(@$"AutoSave\WinForm{fileNumberSeed}.rtf"))
            {
                fileNumberSeed++;
            }
            return "WinForm" + fileNumberSeed + ".rtf";
        }

        // NEW EDITOR ACTIONS/METHODS
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewTextEditor();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTextEditor();
        }

        private void NewTextEditor()
        {
            Program.Context.LoadTextEditForm(CurrentUser);
            this.Close();
        }

        // OPEN FILE ACTIONS/METHODS
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenText();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenText();
        }

        private void OpenText()
        {
            //Instantiate new dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open a Rich Text File",
                Filter = "Rich Text Files (*.rtf) | *.rtf",
                InitialDirectory = Directory.GetCurrentDirectory(),
            };

            //Show the dialog
            DialogResult dr = openFileDialog.ShowDialog();

            //Open file on user response
            if (dr == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                RichTextBox.LoadFile(file, RichTextBoxStreamType.RichText);
                filename = openFileDialog.SafeFileName;
                UpdateUsernameLabel(filename);
            }
        }

        // SAVE FILE ACTIONS/METHODS
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            //Save file based on next available file name, in the user's personal folder
            RichTextBox.SaveFile(@$"AutoSave\{filename}");
            UpdateUsernameLabel(filename);
        }

        // SAVE FILE AS ACTIONS/METHODS
        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            saveFileAs();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileAs();
        }

        private void saveFileAs()
        {
            //Instantiate new dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save a Rich Text File",
                Filter = "Rich Text Files (*.rtf) | *.rtf",
            };

            //Show the dialog
            DialogResult dr = saveFileDialog.ShowDialog();

            //Save file on user response
            if (dr == DialogResult.OK)
            {
                string file = saveFileDialog.FileName;
                //If file name is not empty
                if (saveFileDialog.FileName != "")
                {
                    //save file by filestream from OpenFile
                    FileStream fs = (FileStream)saveFileDialog.OpenFile();
                    RichTextBox.SaveFile(fs, RichTextBoxStreamType.RichText);
                    fs.Close();
                    RichTextBox.LoadFile(file, RichTextBoxStreamType.RichText);
                    filename = Path.GetFileNameWithoutExtension(file);
                    UpdateUsernameLabel(filename);
                }
            }
        }

        // FONT SIZE ACTIONS/METHODS
        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font currentFont = RichTextBox.SelectionFont;
            RichTextBox.SelectionFont = new Font(currentFont.FontFamily, int.Parse(fontSizeToolStripComboBox.Text), currentFont.Style);
        }

        // TEXT TOOLS ACTIONS/METHODS
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if text is selected, cut the text from the box and paste it to the clipboard
            if(RichTextBox.SelectionLength > 0)
            {
                RichTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if text is selected, copy the text from the box to the clipboard
            if (RichTextBox.SelectionLength > 0)
            {
                RichTextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (RichTextBox.SelectionLength > 0)
                {
                    RichTextBox.SelectionStart = RichTextBox.SelectionStart + RichTextBox.SelectionLength;
                }
                RichTextBox.Paste();
            }
        }



        private void boldToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {

        }



        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Context.UserList.SaveUsers();
            MessageBox.Show("Logout Complete.", "Logout", MessageBoxButtons.OK);
            Program.Context.LoadLoginForm();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Context.UserList.SaveUsers();
            Application.Exit();
        }

        private void TextEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Context.UserList.SaveUsers();
        }
    }
}
