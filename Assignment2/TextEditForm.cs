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
        string fileExt;
        object[] fontRange = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        //Constructor
        public TextEditForm()
        {
            InitializeComponent();
            filename = NextFileName();
            fileExt = ".rtf";
        }

        // actions on form load-in
        private void TextEditForm_Load(object sender, EventArgs e)
        {
            // disable rtb if user is only allowed to view
            RichTextBox.Enabled = IsAuthorized(CurrentUser.UserType);
            // update label at start
            usernameLabel.Text = CurrentUser.Username;
            UpdateUsernameLabel("Unsaved File");
            // set initial font choices and font on load
            fontSizeToolStripComboBox.Items.AddRange(fontRange);
            fontSizeToolStripComboBox.Text = "12";
            RichTextBox.SelectionFont = new Font(RichTextBox.Font.FontFamily, 12);
        }

        // checks if user is authorized based on usertype, true for edit, false for view
        bool IsAuthorized(UserType userType) => userType == UserType.View ? false : true;

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
            return "WinForm" + fileNumberSeed;
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
                Title = "Open a Text File",
                Filter = "Rich Text Files (*.rtf) | *.rtf|Text Files (*.txt)|*.txt",
                InitialDirectory = Directory.GetCurrentDirectory(),
            };

            //Show the dialog
            DialogResult dr = openFileDialog.ShowDialog();
            int filterResult = openFileDialog.FilterIndex;

            //Open file on user response
            if (dr == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                if(filterResult == 1)
                {
                    RichTextBox.LoadFile(file, RichTextBoxStreamType.RichText);
                } 
                else if (filterResult == 2)
                {
                    RichTextBox.LoadFile(file, RichTextBoxStreamType.PlainText);
                }

                filename = Path.GetFileNameWithoutExtension(openFileDialog.SafeFileName);
                UpdateUsernameLabel(filename);
                fileExt = Path.GetExtension(openFileDialog.SafeFileName);
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
            RichTextBox.SaveFile(@$"AutoSave\{filename}{fileExt}");
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
                Title = "Open a Text File",
                Filter = "Rich Text Files (*.rtf) | *.rtf|Text Files (*.txt)|*.txt",
            };

            //Show the dialog
            DialogResult dr = saveFileDialog.ShowDialog();
            int filterResult = saveFileDialog.FilterIndex;

            //Save file on user response
            if (dr == DialogResult.OK)
            {
                string file = saveFileDialog.FileName;
                //If file name is not empty
                if (saveFileDialog.FileName != "")
                {
                    //save file by filestream from OpenFile
                    FileStream fs = (FileStream)saveFileDialog.OpenFile();
                    if (filterResult == 1)
                    {
                        RichTextBox.SaveFile(fs, RichTextBoxStreamType.RichText);
                        fs.Close();
                        RichTextBox.LoadFile(file, RichTextBoxStreamType.RichText);
                    }
                    else if (filterResult == 2)
                    {
                        RichTextBox.SaveFile(fs, RichTextBoxStreamType.PlainText);
                        fs.Close();
                        RichTextBox.LoadFile(file, RichTextBoxStreamType.PlainText);
                    }
                    filename = Path.GetFileNameWithoutExtension(file);
                    UpdateUsernameLabel(filename);
                }
            }
        }

        // FONT SIZE ACTIONS/METHODS
        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the current font/size/style
            Font currentFont = RichTextBox.SelectionFont;

            // if text is selected, change the text size
            if (RichTextBox.SelectionLength > 0)
            {
                RichTextBox.SelectionFont = new Font(currentFont.FontFamily, int.Parse(fontSizeToolStripComboBox.Text), currentFont.Style);
            }
        }

        // TEXT TOOLS ACTIONS/METHODS
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void Cut()
        {
            // if text is selected, cut the text from the box and paste it to the clipboard
            if (RichTextBox.SelectionLength > 0)
            {
                RichTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void Copy()
        {
            // if text is selected, copy the text from the box to the clipboard
            if (RichTextBox.SelectionLength > 0)
            {
                RichTextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Paste()
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (RichTextBox.SelectionLength > 0)
                {
                    RichTextBox.SelectionStart += RichTextBox.SelectionLength;
                }
                RichTextBox.Paste();
            }
        }

        // TEXT STYLE ACTIONS/METHODS
        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }
        
        private void ToggleFontStyle(FontStyle style)
        {
            Font currentFont = RichTextBox.SelectionFont;
            FontStyle currentFontStyle = currentFont.Style ^ style;
            RichTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, currentFontStyle);
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

        // ABOUT WINDOW ACTIONS/METHODS
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutWindow();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            ShowAboutWindow();
        }

        private void ShowAboutWindow()
        {
            Form prompt = new Form
            {
                Width = 400,
                Height = 200,
                Text = "About"
            };
            Label textLabel = new Label()
            {
                Left = 25,
                Width = 350,
                Height = 150,
                Top = 20,
                Text = $"{Program.name} version {Program.version}.\n" +
                $"Last updated on {Program.repository} on {Program.versionDate}.\n" +
                $"Author: {Program.author}"
            };
            Button confirmation = new Button()
            { 
                Text = "Ok",
                Left = 150,
                Width = 100,
                Top = 100
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
        }
    }
}
