using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/*<comment id="#{id}">
  <post_id>#{post_id}</post_id>
  <creator_name>#{creator_name}</creator_name>
  <creator_id>#{creator_id}</creator_id>
  <body>#{body}</body>
  <posted_on>#{posted_on}</posted_on>
</comment>
	 */
	/// <summary>
	/// Represents a comment to a message.
	/// </summary>
	public class PostComment : BasecampItem
	{
		string authorID;
		string body;
		DateTime postedOn;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public PostComment(Basecamp camp, XmlNode node) : base(camp)
		{
			if (node != null)
			{
				id = node["id"].InnerText.Trim();
				authorID = node["author-id"].InnerText.Trim();
				postedOn = DateTime.Parse(node["posted-on"].InnerText.Trim());
				body = node["body"].InnerText.Trim();
			}
		}

		/// <summary>
		/// The author.
		/// </summary>
		public Person Author;

		/// <summary>
		/// ID of the author.
		/// </summary>
		public string AuthorID { get { return authorID; } }

		/// <summary>
		/// The body of the comment.
		/// </summary>
		public string Body { get { return body; } }

		/// <summary>
		/// The datetime of this comment.
		/// </summary>
		public DateTime PostedOn { get { return postedOn; } }
	}
}
