namespace Scout
{
	partial class SettingsForm
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
			this.account = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.username = new System.Windows.Forms.TextBox();
			this.ssl = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.proxyUrl = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// account
			// 
			this.account.Location = new System.Drawing.Point(153, 127);
			this.account.Name = "account";
			this.account.Size = new System.Drawing.Size(383, 38);
			this.account.TabIndex = 13;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(153, 78);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(383, 38);
			this.password.TabIndex = 12;
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(153, 29);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(383, 38);
			this.username.TabIndex = 11;
			// 
			// ssl
			// 
			this.ssl.Location = new System.Drawing.Point(29, 189);
			this.ssl.Name = "ssl";
			this.ssl.Size = new System.Drawing.Size(507, 59);
			this.ssl.TabIndex = 14;
			this.ssl.Text = "Check this box if your Basecamp account requires SSL";
			this.ssl.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Account:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Username:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(25, 273);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(511, 52);
			this.label4.TabIndex = 10;
			this.label4.Text = "You can enter a proxy address if you don\'t want to use IE\'s proxy settings:";
			// 
			// proxyUrl
			// 
			this.proxyUrl.Location = new System.Drawing.Point(29, 328);
			this.proxyUrl.Name = "proxyUrl";
			this.proxyUrl.Size = new System.Drawing.Size(507, 38);
			this.proxyUrl.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
			this.label5.ForeColor = System.Drawing.Color.DarkBlue;
			this.label5.Location = new System.Drawing.Point(25, 369);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(511, 33);
			this.label5.TabIndex = 10;
			this.label5.Text = "Example: myproxy:8088";
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(152, 438);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(152, 40);
			this.ok.TabIndex = 15;
			this.ok.Text = "Save Settings";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(310, 438);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(104, 40);
			this.cancel.TabIndex = 15;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(567, 490);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.proxyUrl);
			this.Controls.Add(this.account);
			this.Controls.Add(this.password);
			this.Controls.Add(this.username);
			this.Controls.Add(this.ssl);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox account;
		public System.Windows.Forms.TextBox password;
		public System.Windows.Forms.TextBox username;
		public System.Windows.Forms.CheckBox ssl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox proxyUrl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
	}
}
