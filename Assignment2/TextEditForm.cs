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

        private void TextEditForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = CurrentUser.Username;
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

        private void openToolStripButton_Click(object sender, EventArgs e)
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Context.LoadTextEditForm(CurrentUser);
            this.Close();
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
