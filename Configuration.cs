using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Scout
{
    [Serializable]
    public class Configuration
    {
        public Configuration()
        {
        }

        public static void Serialize(string file, Configuration c)
        {
			try
			{
				System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(c.GetType());
				StreamWriter writer = File.CreateText(file);
				xs.Serialize(writer, c);
				writer.Flush();
				writer.Close();
			}

			catch { }
        }

        public static Configuration Deserialize(string file)
        {
			if (!File.Exists(file))
				return null;

			try
			{
				System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(
					  typeof(Configuration));
				StreamReader reader = File.OpenText(file);
				Configuration c = (Configuration)xs.Deserialize(reader);
				reader.Close();
				return c;
			}

			catch { }
			return null;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool SSL
        {
            get { return ssl; }
            set { ssl = value; }
        }

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

		public string ProxyUrl
		{
			get { return proxyUrl; }
			set { proxyUrl = value; }
		}

        private string username;
        private string password;
        private bool ssl;
        private string account;
		private string proxyUrl;

		
    }
}
