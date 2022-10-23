using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTextEditor
{
    public partial class TextEditForm : Form
    {
        internal User CurrentUser {get;set;}

        public TextEditForm()
        {
            InitializeComponent();
        }
        
        // actions on form load-in
        private void TextEditForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = CurrentUser.Username;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open a Text File";

            //Filter file types
            openFileDialog.Filter = "Text Files (*.txt) | *.txt | Rich Text Files (*.rtf) | *.rtf";

            //Show the dialog
            DialogResult dr = openFileDialog.ShowDialog();

            //Open file on user response
            if (dr == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                RichTextBox.LoadFile(filename, RichTextBoxStreamType.RichText);
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

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void TextEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Context.UserList.SaveUsers();
        }
    }
}
