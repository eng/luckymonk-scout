using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/*
	 * <post-category>
  <id type="integer">#{id}</id>
  <name>#{name}</name>
  <project-id type="integer">#{project_id}</project-id>
  <elements-count type="integer">#{elements_count}</elements-count>
</post-category>
	 */

	/// <summary>
	/// Represents a message category.
	/// </summary>
	public class MessageCategory : BasecampItem
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public MessageCategory(Basecamp camp, XmlNode node)
			: base(camp)
		{
			if (node != null)
			{
				id = node["id"].InnerText.Trim();
				name = node["name"].InnerText.Trim();

			}
		}

		/// <summary>
		/// The ID.
		/// </summary>
		public string ID { get { return id; } }

		/// <summary>
		/// The name.
		/// </summary>
		public string Name { get { return name; } }
	}
}
