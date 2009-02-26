namespace Scout
{
    partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.login = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.remember = new System.Windows.Forms.CheckBox();
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.account = new System.Windows.Forms.TextBox();
			this.ssl = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.version = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// login
			// 
			this.login.Location = new System.Drawing.Point(294, 229);
			this.login.Name = "login";
			this.login.Size = new System.Drawing.Size(90, 46);
			this.login.TabIndex = 8;
			this.login.Text = "Login";
			this.login.UseVisualStyleBackColor = true;
			this.login.Click += new System.EventHandler(this.login_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(390, 229);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(90, 46);
			this.cancel.TabIndex = 9;
			this.cancel.Text = "Exit";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(143, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(143, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(143, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Account:";
			// 
			// remember
			// 
			this.remember.AutoSize = true;
			this.remember.Location = new System.Drawing.Point(15, 251);
			this.remember.Name = "remember";
			this.remember.Size = new System.Drawing.Size(145, 24);
			this.remember.TabIndex = 6;
			this.remember.Text = "Remember me";
			this.remember.UseVisualStyleBackColor = true;
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(243, 12);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(237, 32);
			this.username.TabIndex = 3;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(243, 61);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(237, 32);
			this.password.TabIndex = 4;
			// 
			// account
			// 
			this.account.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.account.Location = new System.Drawing.Point(243, 110);
			this.account.Name = "account";
			this.account.Size = new System.Drawing.Size(237, 28);
			this.account.TabIndex = 5;
			// 
			// ssl
			// 
			this.ssl.AutoSize = true;
			this.ssl.Location = new System.Drawing.Point(243, 176);
			this.ssl.Name = "ssl";
			this.ssl.Size = new System.Drawing.Size(62, 24);
			this.ssl.TabIndex = 7;
			this.ssl.Text = "SSL?";
			this.ssl.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(116, 116);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel1.Location = new System.Drawing.Point(320, 182);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(160, 15);
			this.linkLabel1.TabIndex = 10;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Tap here for more settings...";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// version
			// 
			this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.version.AutoSize = true;
			this.version.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.version.ForeColor = System.Drawing.Color.RoyalBlue;
			this.version.Location = new System.Drawing.Point(12, 131);
			this.version.Name = "version";
			this.version.Size = new System.Drawing.Size(55, 15);
			this.version.TabIndex = 2;
			this.version.Text = "Version";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F);
			this.label5.ForeColor = System.Drawing.Color.DarkBlue;
			this.label5.Location = new System.Drawing.Point(240, 145);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(218, 15);
			this.label5.TabIndex = 11;
			this.label5.Text = "Example: mycompany.projectpath.com";
			// 
			// LoginForm
			// 
			this.AcceptButton = this.login;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(489, 287);
			this.ControlBox = false;
			this.Controls.Add(this.label5);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.account);
			this.Controls.Add(this.password);
			this.Controls.Add(this.username);
			this.Controls.Add(this.ssl);
			this.Controls.Add(this.remember);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.version);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.login);
			this.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Scout:  Please Login";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox remember;
        public System.Windows.Forms.TextBox username;
        public System.Windows.Forms.TextBox password;
		public System.Windows.Forms.TextBox account;
        public System.Windows.Forms.CheckBox ssl;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label version;
		private System.Windows.Forms.Label label5;
    }
}
