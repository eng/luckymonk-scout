using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scout
{
    public partial class LoginForm : BaseDialog
    {
        public LoginForm()
        {
            InitializeComponent();
            LoadConfiguration();

			Version appversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			version.Text = string.Format("Version {0}.{1}", appversion.Major, appversion.Minor);
        }

        private void login_Click(object sender, EventArgs e)
        {
            using (new Hourglass())
            {
				//BasecampObject = new BasecampAPI.Basecamp(account.Text.Trim(), ssl.Checked,
				//    username.Text.Trim(), password.Text, "10.10.6.11:8080");

				Configuration config = Configuration.Deserialize(CONFIG);

				if (config == null)
				{
					ClearConfiguration();
					config = Configuration.Deserialize(CONFIG);
				}

				BasecampObject = new BasecampAPI.Basecamp(account.Text.Trim(), ssl.Checked,
					username.Text.Trim(), password.Text, config.ProxyUrl);

                try
                {
                    if (remember.Checked)
                        SaveConfiguration(config);
                    else
                        ClearConfiguration();

					object obj = BasecampObject.Projects;

                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Login failed!");
                    BasecampObject = null;
                }
            }
        }

        private void ClearConfiguration()
        {
            Configuration config = new Configuration();
            config.Username = String.Empty;
            config.Password = String.Empty;
            config.Account = String.Empty;
            config.SSL = false;
			config.ProxyUrl = string.Empty;
            Configuration.Serialize(CONFIG, config);
        }

        private void LoadConfiguration()
        {
            try
            {
                Configuration config = Configuration.Deserialize(CONFIG);
                if (config != null && config.Username.Length > 0)
                {
                    username.Text = config.Username;
                    password.Text = config.Password;
                    account.Text = config.Account;
                    ssl.Checked = config.SSL;
                    remember.Checked = true;
                }
            }
            catch { }
        }

        private void SaveConfiguration(Configuration config)
        {
            config.Username = username.Text;
            config.Password = password.Text;
            config.Account = account.Text;
            config.SSL = ssl.Checked;
            Configuration.Serialize(CONFIG, config);
        }

        public BasecampAPI.Basecamp BasecampObject;
        private const string CONFIG = "scout.xml";

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (DialogResult.OK == new SettingsForm().ShowDialog(this))
				LoadConfiguration();
		}

		private void luckymonk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(@"http://www.luckymonk.com");
		}
    }
}