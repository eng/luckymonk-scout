using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// Represents a message.
	/// </summary>
	public class Message : BasecampItem, IComparable<Message>
	{
		/*<post>
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
</post>*/

		List<PostComment> comments;
		Project project;
		int commentCount = 0;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public Message(Basecamp camp, XmlNode node)
			: base(camp)
		{
			if (node != null)
			{
				id = node["id"].InnerText.Trim();
				name = Title = node["title"].InnerText.Trim();
				Body = node["body"].InnerText.Trim();
				PostedOn = DateTime.Parse(node["posted-on"].InnerText.Trim());
				commentCount = int.Parse(node["comments-count"].InnerText.Trim());

				try
				{
					project = camp.Projects[node["project-id"].InnerText.Trim()];
					if (project != null)
					{
						Author = project.People[node["author-id"].InnerText.Trim()];
					}
				}
				catch { }
			}
		}

		/// <summary>
		/// The title.
		/// </summary>
		public readonly string Title;

		/// <summary>
		/// The body.
		/// </summary>
		public readonly string Body;

		/// <summary>
		/// The datetime.
		/// </summary>
		public readonly DateTime PostedOn;

		/// <summary>
		/// The author.
		/// </summary>
		public readonly Person Author;

		/// <summary>
		/// The number of comments attached to this message.
		/// </summary>
		public int CommentsCount
		{
			get
			{
				if (comments == null)
					return commentCount;

				return comments.Count;
			}
		}
		/// <summary>
		/// The list of comments associated with this message.
		/// </summary>
		public List<PostComment> Comments
		{
			get
			{
				if (comments == null)
				{
					comments = Slurp<PostComment>(@"/msg/comments/" + id, "//comment");

					if (project != null)
					{
						Trace.WriteLine("project != null");
						foreach (PostComment comment in comments)
						{
							Trace.WriteLine("Looking up person #" + comment.AuthorID);
							try
							{
								if (project.People.ContainsKey(comment.AuthorID))
								{
									comment.Author = project.People[comment.AuthorID];
									Trace.WriteLine(comment.Author.Name);
								}
							}
							catch
							{
							}
						}
					}
					Trace.WriteLineIf(project == null, "No project!");

				}
				
				return comments;
			}
		}

//        <request>
//  <comment>
//    <post-id>#{post_id}</post-id>
//    <body>#{body}</body>
//  </comment>
//</request>
		/// <summary>
		/// Post a comment to this message.
		/// </summary>
		/// <param name="body">Your comment.</param>
		/// <returns>The new PostComment object.</returns>
		public PostComment AddComment(string body)
		{
			if (String.IsNullOrEmpty(body))
				throw new ArgumentNullException("body");

			string url = string.Format(@"/msg/create_comment");

			string xml = string.Format(@"<request><comment><post-id>{0}</post-id>" +
				@"<body>{1}</body></comment></request>",
				this.id,
				body);

			PostComment comment = new PostComment(camp, camp.Call(url, xml).SelectSingleNode("/comment"));

			if (comments != null)
			{
				comments.Add(comment);

				if (project != null)
					comment.Author = project.People[comment.AuthorID];
			}

			return comment;
		}

		/*
		 * <request>
  <post>
    <category-id>#{category_id}</category-id>
    <title>#{title}</title>
    <body>#{body}</body>
    <extended-body>#{extended_body}</extended-body>
  </post>
  <attachments>
    <name>#{name}</name> <!-- optional -->
    <file>
      <file>#{temp_id}</file> <!-- the id of the previously uploaded file -->
      <content-type>#{content_type}</content-type>
      <original_filename>#{original_filename}</original-filename>
    </file>
  </attachments>
  <attachments>...</attachments>
  ...
</request>
		 */
		internal static string XmlForCreate(string title, string body, string categoryID, string filename, string filekey)
		{
			return string.Format(@"<request><post><category-id>{2}</category-id>" +
											@"<title>{0}</title>" +
											@"<body>{1}</body>" +
											@"<extended-body></extended-body>" +
											@"</post>" +
											GetXmlForAttachments(filename, filekey) + 
											@"</request>",
										 title,
										 body,
										 categoryID);
		}

		private static string GetXmlForAttachments(string filename, string filekey)
		{
			if (String.IsNullOrEmpty(filename) || String.IsNullOrEmpty(filekey)) 
				return "<attachments></attachments>";

			return string.Format(@"<attachments><name>{0}</name><file><file>{1}</file>" +
						@"<content-type>image/jpg</content-type>" +
						@"<original-filename>{0}</original-filename></file></attachments>",
						filename,
						filekey);
		}

		#region IComparable<Message> Members

		/// <summary>
		/// Compares.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(Message other)
		{
			if (other == null) return 1;

			return PostedOn.CompareTo(other.PostedOn);
		}

		#endregion
	}
}
