using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Xml.XPath;
using System.IO;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// The "root" object of this API.
	/// </summary>
	public class Basecamp
	{
		bool ssl = false;
		string domain = string.Empty;
		string user = string.Empty;
		string password = string.Empty;
		string proxyUrl = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="companyDomain">The domain name of the basecamp site; i.e. mycompany.clientsection.com</param>
		/// <param name="user">Basecamp user name.</param>
		/// <param name="password">Basecamp password</param>
		public Basecamp(string companyDomain, string user, string password)
			: this(companyDomain, false, user, password, null)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="companyDomain">The domain name of the basecamp site; i.e. mycompany.clientsection.com</param>
		/// <param name="useSSL">Use a secure connection (https: instead of http:)</param>
		/// <param name="user">Basecamp user name.</param>
		/// <param name="password">Basecamp password</param>
		public Basecamp(string companyDomain, bool useSSL, string user, string password)
			: this(companyDomain, useSSL, user, password, null)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="companyDomain">The domain name of the basecamp site; i.e. mycompany.clientsection.com</param>
		/// <param name="useSSL">Use a secure connection (https: instead of http:)</param>
		/// <param name="user">Basecamp user name.</param>
		/// <param name="password">Basecamp password</param>
		/// <param name="proxyUrl">The url to the proxy server, including port number; will assume default credentials.</param>
		public Basecamp(string companyDomain, bool useSSL, string user, string password, string proxyUrl)
		{
			domain = companyDomain;
			ssl = useSSL;
			this.user = user;
			this.password = password;
			this.proxyUrl = proxyUrl;
		}

		/// <summary>
		/// The username of the user who logged in.
		/// </summary>
		public string User
		{
			get { return user; }
		}

		/// <summary>
		/// Raised when an API call has started.
		/// </summary>
		public event EventHandler WebCallStarted;

		/// <summary>
		/// Raised when an API call has finished.
		/// </summary>
		public event EventHandler WebCallFinished;

		Dictionary<string, Project> projects;

		/// <summary>
		/// The list of projects.  Caches the results
		/// after the initial call.  Returns a dictionary
		/// where the key is the project ID and the value
		/// is the Project.
		/// </summary>
		public Dictionary<string, Project> Projects
		{
			get
			{
				if (projects == null)
				{
					projects = new Dictionary<string, Project>();

					foreach (Project project in GetProjects())
						projects[project.ID] = project;
				}

				return projects;
			}
		}

		/// <summary>
		/// Gets the list of projects from the Basecamp website.
		/// </summary>
		/// <returns>True if successful.</returns>
		public List<Project> GetProjects()
		{
			List<Project> projects = BasecampItem.Slurp<Project>(
					this, 
					@"/project/list", 
					@"/projects/project[status='active']");

			projects.Sort();

			DetectAllCompanies(projects);

			return projects;
		}

		private void DetectAllCompanies(List<Project> projects)
		{
			CompanyIDs = new List<string>();
			foreach (Project project in projects)
				if (-1 == CompanyIDs.IndexOf(project.CompanyID))
					CompanyIDs.Add(project.CompanyID);
		}

		internal List<string> CompanyIDs;

		internal XmlDocument Call(string urlSuffix)
		{
			return Call(urlSuffix, string.Empty);
		}

		/// <summary>
		/// Calls the Basecamp API via http or https.
		/// </summary>
		/// <param name="urlSuffix"></param>
		/// <param name="xmlRequest">The request data in xml format</param>
		/// <returns></returns>
		internal XmlDocument Call(string urlSuffix, string xmlRequest)
		{
			Trace.WriteLine(string.Format("Calling API '{0}'", urlSuffix));

			if (WebCallStarted != null)
				WebCallStarted(this, EventArgs.Empty);

			XmlDocument doc = new XmlDocument();

			try
			{
				string data = CallApi(urlSuffix, xmlRequest);

				Trace.WriteLine("Response from basecamp:");
				Trace.WriteLine(data);

				doc.Load(new StringReader(data));
				return doc;
			}

			catch (Exception e)
			{
				Trace.WriteLine("Exception caught:");
				Trace.WriteLine(e.Message);
				Trace.WriteLine(e.StackTrace);
				throw;
			}
			finally
			{
				if (WebCallFinished != null)
					WebCallFinished(this, EventArgs.Empty);

			}
		}

		/// <summary>
		/// Uploads a file to be associated with a message.
		/// </summary>
		/// <param name="filename">Path to an existing file.</param>
		/// <returns>The "file id" to be used when submitting the message.</returns>
		public string UploadFileForMessage(string filename)
		{
			string url = MakeUrl(@"/upload");
			HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;

			req.Accept = "application/xml";
			req.ContentType = "application/octet-stream";
			//req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
			req.UserAgent = "LuckyMonk/Scout";
			req.Credentials = new NetworkCredential(user, password);
			req.Proxy = WebRequest.GetSystemWebProxy();
			req.AllowAutoRedirect = true;
			if (proxyUrl != null)
			{
				req.Proxy = new WebProxy(proxyUrl);
				req.Proxy.Credentials = CredentialCache.DefaultCredentials;
			}

			Stream file = new FileStream(filename, FileMode.Open);

			req.Method = "POST";
			Stream stream = req.GetRequestStream();
			byte[] bytes = new byte[file.Length];
			file.Read(bytes, 0, bytes.Length);
			stream.Write(bytes, 0, bytes.Length);

			file.Close();
			stream.Close();

			StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
			string data = reader.ReadToEnd().Trim();
			reader.Close();

			//<?xml version=\"1.0\" encoding=\"UTF-8\"?>
			//<upload><id>44720763.eve.47226</id></upload>"

			int start = data.IndexOf("<id>");
			int end = data.IndexOf("</id>");

			if (end > start)
				data = data.Substring(start + 4, end - start - 4);

			return data;
		}

		/// <summary>
		/// Make actual web service call.
		/// </summary>
		/// <param name="urlSuffix"></param>
		/// <param name="xmlRequest">The request data in yml format</param>
		/// <returns></returns>
		protected string CallApi(string urlSuffix, string xmlRequest)
		{
			string url = MakeUrl(urlSuffix);
			HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;

			PrepareRequest(req);

			if (!String.IsNullOrEmpty(xmlRequest))
			{
				req.Method = "POST";
				byte [] bytes = System.Text.Encoding.ASCII.GetBytes(xmlRequest);
				Stream stream = req.GetRequestStream();
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();
				
			}
			StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
			string data = reader.ReadToEnd().Trim();
			reader.Close();

			return data;
		}

		private void PrepareRequest(HttpWebRequest web)
		{
			Trace.WriteLine("Preparing request...");

			web.Accept = "application/xml";
			web.ContentType = "application/xml";
			//web.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
			web.UserAgent = "LuckyMonk/Scout";

			web.Credentials = new NetworkCredential(user, password);
			web.Proxy = WebRequest.GetSystemWebProxy();
			web.AllowAutoRedirect = true;

			Trace.WriteLineIf(proxyUrl == null, "   No proxy specified");

			if (!String.IsNullOrEmpty(proxyUrl))
			{
				Trace.WriteLine("   Setting proxy to " + proxyUrl);
				web.Proxy = new WebProxy(proxyUrl);
				web.Proxy.Credentials = CredentialCache.DefaultCredentials;
			}

			Trace.WriteLine("Done preparing request.");
		}

		private string MakeUrl(string p)
		{
			return string.Format(@"http{0}://{1}/{2}", ssl ? "s" : string.Empty, domain, p.TrimStart('/'));
		}
	}
}
