using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/*
	 * <post>
  <id type="integer">#{id}</id>
  <title>#{title}</title>
  <posted-on type="datetime">#{posted_on}</posted-on>
  <attachments-count type="integer">#{attachments_count}</attachments-count>
  <category>
    <id type="integer">#{id}</id>
    <name>#{name}</name>
  </category>
</post>
	 * 
	 * <post>
  <id type="integer">#{id}</id>
  <title>#{title}</title>
  <body>#{body}</body>
  <posted-on type="datetime">#{posted_on}</posted-on>
  <project-id type="integer">#{project_id}</project-id>
  <category-id type="integer">#{category_id}</category-id>
  <author-id type="integer">#{author_id}</author-id>
  <milestone-id type="integer">#{milestone_id}</milestone-id>
  <comments-count type="integer">#{comments_count}</comments-count>
  <attachments-count type="integer">#{attachments_count}</attachments-count>
  <use-textile type="boolean">#{use_textile}</use-textile>
  <extended-body>#{extended_body}</extended-body>
  <display-body>#{display_body}</display-body>
  <display-extended-body>#{display_extended_body}</display-extended-body>

  <!-- if user can see private posts -->
  <private type="boolean">#{private}</private>
</post>
	 */

	/// <summary>
	/// Represents an abbreviated message.
	/// </summary>
	public class PostSummary : BasecampItem
	{
		string title;
		DateTime postedOn;
		List<PostComment> comments = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public PostSummary(Basecamp camp, XmlNode node)
			: base(camp)
		{
			if (node != null)
			{
				name = title = node["title"].InnerText;
				id = node["id"].InnerText.Trim();
				postedOn = DateTime.Parse(node["posted-on"].InnerText);

				//comments = Slurp<PostComment>(@"/msg/comments/" + id, "//comment");
			}
		}

		/// <summary>
		/// The comments for this summary.
		/// </summary>
		public List<PostComment> Comments { get { return comments; } }

		/// <summary>
		/// The title.
		/// </summary>
		public string Title
		{
			get { return title; }
		}

		/// <summary>
		/// The datetime
		/// </summary>
		public DateTime PostedOn
		{
			get { return postedOn; }
		}

		/// <summary>
		/// The ID.
		/// </summary>
		public string ID { get { return id; } }
	}
}
