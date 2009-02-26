using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scout
{
	public partial class SettingsForm : Scout.BaseDialog
	{
		public SettingsForm()
		{
			InitializeComponent();

			Load += new EventHandler(SettingsForm_Load);
		}

		void SettingsForm_Load(object sender, EventArgs e)
		{
			LoadConfiguration();
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
					proxyUrl.Text = config.ProxyUrl;
				}
			}
			catch { }
		}

		private void SaveConfiguration()
		{
			Configuration config = new Configuration();
			config.Username = username.Text;
			config.Password = password.Text;
			config.Account = account.Text;
			config.SSL = ssl.Checked;
			config.ProxyUrl = proxyUrl.Text.Trim();
			Configuration.Serialize(CONFIG, config);
		}

		private const string CONFIG = "scout.xml";

		private void ok_Click(object sender, EventArgs e)
		{
			SaveConfiguration();
			DialogResult = DialogResult.OK;
		}
	}
}

