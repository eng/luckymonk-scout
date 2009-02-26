using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// A person.
	/// </summary>
	public class Person : BasecampItem, IComparable
	{
		string username = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public Person() : base(null)
		{
			id = username = string.Empty;
			name = "Anyone";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="camp"></param>
		public Person(Basecamp camp) : this(camp, null) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public Person(Basecamp camp, XmlNode node) : base(camp)
		{
			if (node != null)
			{
				name = string.Format("{0}, {1}", node["last-name"].InnerText.Trim(), node["first-name"].InnerText);
				id = node["id"].InnerText.Trim();

				if (node.InnerXml.Contains("user-name"))
					username = node["user-name"].InnerText.Trim();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public static Person Nobody = new Person();

		/// <summary>
		/// The ID.
		/// </summary>
		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// The name of the person.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// The username
		/// </summary>
		public string Username
		{
			get { return username; }
		}


		#region IComparable Members

		/// <summary>
		/// Compares.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			Person rhs = obj as Person;
			if (rhs == null) return 1;

			return (Name.CompareTo(rhs.Name));
		}

		#endregion
	}
}
