using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// Base class for all Basecamp objects.
	/// </summary>
	public class BasecampItem
	{
		/// <summary>
		/// The name of the item.
		/// </summary>
		protected string name;

		/// <summary>
		/// The id.
		/// </summary>
		protected string id;

		/// <summary>
		/// The Basecamp object.
		/// </summary>
		protected Basecamp camp;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="camp"></param>
		protected BasecampItem(Basecamp camp)
		{
			this.camp = camp;
		}

		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return name;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="action"></param>
		/// <param name="xpath"></param>
		/// <returns></returns>
		protected List<T> Slurp<T>(string action, string xpath)
			where T : BasecampItem
		{
			return Slurp<T>(camp, action, xpath);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="action"></param>
		/// <param name="xmlRequest"></param>
		/// <param name="xpath"></param>
		/// <returns></returns>
		protected List<T> Slurp<T>(string action, string xmlRequest, string xpath)
			where T : BasecampItem
		{
			return Slurp<T>(camp, action, xmlRequest, xpath);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="camp"></param>
		/// <param name="action"></param>
		/// <param name="xpath"></param>
		/// <returns></returns>
		public static List<T> Slurp<T>(Basecamp camp, string action, string xpath)
			where T : BasecampItem
		{
			return Slurp<T>(camp, action, string.Empty, xpath);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="camp"></param>
		/// <param name="action"></param>
		/// <param name="xmlRequest"></param>
		/// <param name="xpath"></param>
		/// <returns></returns>
		public static List<T> Slurp<T>(Basecamp camp, string action, string xmlRequest, string xpath)
			where T : BasecampItem
		{
			List<T> items = new List<T>();

			XmlDocument doc = camp.Call(action, xmlRequest);

			if (doc != null)
			{
				foreach (XmlNode node in doc.SelectNodes(xpath))
				{
					T item = (T)Activator.CreateInstance(typeof(T), camp, node);
					items.Add(item);
				}
			}

			return items;
		}

		
	}
}
