namespace WinFormsTextEditor
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginGroupBox = new System.Windows.Forms.GroupBox();
            this.UserTypeComboBox = new System.Windows.Forms.ComboBox();
            this.BirthdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.UserTypeLabel = new System.Windows.Forms.Label();
            this.BirthdateLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.ReEnterPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ReEnterPasswordLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.LoginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginGroupBox
            // 
            this.LoginGroupBox.Controls.Add(this.UserTypeComboBox);
            this.LoginGroupBox.Controls.Add(this.BirthdateDateTimePicker);
            this.LoginGroupBox.Controls.Add(this.UserTypeLabel);
            this.LoginGroupBox.Controls.Add(this.BirthdateLabel);
            this.LoginGroupBox.Controls.Add(this.LastNameTextBox);
            this.LoginGroupBox.Controls.Add(this.LastNameLabel);
            this.LoginGroupBox.Controls.Add(this.ReEnterPasswordTextBox);
            this.LoginGroupBox.Controls.Add(this.ReEnterPasswordLabel);
            this.LoginGroupBox.Controls.Add(this.FirstNameTextBox);
            this.LoginGroupBox.Controls.Add(this.FirstNameLabel);
            this.LoginGroupBox.Controls.Add(this.PasswordTextBox);
            this.LoginGroupBox.Controls.Add(this.UsernameTextBox);
            this.LoginGroupBox.Controls.Add(this.PasswordLabel);
            this.LoginGroupBox.Controls.Add(this.UsernameLabel);
            this.LoginGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginGroupBox.Location = new System.Drawing.Point(0, 0);
            this.LoginGroupBox.Name = "LoginGroupBox";
            this.LoginGroupBox.Size = new System.Drawing.Size(284, 244);
            this.LoginGroupBox.TabIndex = 1;
            this.LoginGroupBox.TabStop = false;
            this.LoginGroupBox.Text = "Login Details";
            // 
            // UserTypeComboBox
            // 
            this.UserTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserTypeComboBox.FormattingEnabled = true;
            this.UserTypeComboBox.Location = new System.Drawing.Point(79, 202);
            this.UserTypeComboBox.Name = "UserTypeComboBox";
            this.UserTypeComboBox.Size = new System.Drawing.Size(171, 23);
            this.UserTypeComboBox.TabIndex = 7;
            // 
            // BirthdateDateTimePicker
            // 
            this.BirthdateDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.BirthdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BirthdateDateTimePicker.Location = new System.Drawing.Point(79, 173);
            this.BirthdateDateTimePicker.MaxDate = new System.DateTime(2022, 10, 18, 0, 0, 0, 0);
            this.BirthdateDateTimePicker.Name = "BirthdateDateTimePicker";
            this.BirthdateDateTimePicker.Size = new System.Drawing.Size(171, 23);
            this.BirthdateDateTimePicker.TabIndex = 6;
            this.BirthdateDateTimePicker.Value = new System.DateTime(2022, 10, 17, 0, 0, 0, 0);
            this.BirthdateDateTimePicker.ValueChanged += new System.EventHandler(this.BirthdateDateTimePicker_ValueChanged);
            // 
            // UserTypeLabel
            // 
            this.UserTypeLabel.AutoSize = true;
            this.UserTypeLabel.Location = new System.Drawing.Point(13, 205);
            this.UserTypeLabel.Name = "UserTypeLabel";
            this.UserTypeLabel.Size = new System.Drawing.Size(62, 15);
            this.UserTypeLabel.TabIndex = 14;
            this.UserTypeLabel.Text = "User-Type:";
            // 
            // BirthdateLabel
            // 
            this.BirthdateLabel.AutoSize = true;
            this.BirthdateLabel.Location = new System.Drawing.Point(13, 176);
            this.BirthdateLabel.Name = "BirthdateLabel";
            this.BirthdateLabel.Size = new System.Drawing.Size(58, 15);
            this.BirthdateLabel.TabIndex = 12;
            this.BirthdateLabel.Text = "Birthdate:";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(79, 144);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(171, 23);
            this.LastNameTextBox.TabIndex = 5;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(13, 147);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(66, 15);
            this.LastNameLabel.TabIndex = 10;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // ReEnterPasswordTextBox
            // 
            this.ReEnterPasswordTextBox.Location = new System.Drawing.Point(79, 86);
            this.ReEnterPasswordTextBox.Name = "ReEnterPasswordTextBox";
            this.ReEnterPasswordTextBox.PasswordChar = '*';
            this.ReEnterPasswordTextBox.Size = new System.Drawing.Size(171, 23);
            this.ReEnterPasswordTextBox.TabIndex = 3;
            this.ReEnterPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ReEnterPasswordLabel
            // 
            this.ReEnterPasswordLabel.AutoSize = true;
            this.ReEnterPasswordLabel.Location = new System.Drawing.Point(13, 89);
            this.ReEnterPasswordLabel.Name = "ReEnterPasswordLabel";
            this.ReEnterPasswordLabel.Size = new System.Drawing.Size(55, 15);
            this.ReEnterPasswordLabel.TabIndex = 8;
            this.ReEnterPasswordLabel.Text = "Re-enter:";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(79, 115);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(171, 23);
            this.FirstNameTextBox.TabIndex = 4;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(13, 118);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(67, 15);
            this.FirstNameLabel.TabIndex = 6;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(79, 57);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(171, 23);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(79, 25);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(171, 23);
            this.UsernameTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(13, 60);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(13, 28);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(63, 15);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(175, 260);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(94, 260);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.SubmitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.LoginGroupBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.LoginGroupBox.ResumeLayout(false);
            this.LoginGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LoginGroupBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ComboBox UserTypeComboBox;
        private System.Windows.Forms.DateTimePicker BirthdateDateTimePicker;
        private System.Windows.Forms.Label UserTypeLabel;
        private System.Windows.Forms.Label BirthdateLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox ReEnterPasswordTextBox;
        private System.Windows.Forms.Label ReEnterPasswordLabel;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label FirstNameLabel;
    }
}