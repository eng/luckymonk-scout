using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// Represents an active project in Basecamp.
	/// </summary>
	public class Project : BasecampItem, IComparable<Project>
	{
		private string companyID;
		private Person me;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="camp"></param>
		public Project(Basecamp camp) : this(camp, null) { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public Project(Basecamp camp, XmlNode node)
			: base(camp)
		{
			if (node != null)
			{
				name = node["name"].InnerText.Trim();
				id = node["id"].InnerText.Trim();
				companyID = node["company"]["id"].InnerText.Trim();
			}
		}

		/// <summary>
		/// The company ID of this project.
		/// </summary>
		public string CompanyID
		{
			get { return companyID; }
			set { companyID = value; }
		}
	
		/// <summary>
		/// The ID of this project.
		/// </summary>
		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// The name of the project.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		Dictionary<string, Person> people;

		/// <summary>
		/// Gets the cached list of people for this project.
		/// Makes the actual API if this is the first request.
		/// </summary>
		public Dictionary<string, Person> People
		{
			get
			{
				if (people == null)
				{
					people = new Dictionary<string, Person>();

					foreach (Person person in GetPeople())
						people[person.ID] = person;
				}

				return people;
			}
		}


		/// <summary>
		/// Gets the list of people on this project.
		/// </summary>
		/// <returns></returns>
		public List<Person> GetPeople()
		{
			List<Person> people = new List<Person>();
			me = null;

			foreach (string compid in camp.CompanyIDs)
			{
				List<Person> somePeople = Slurp<Person>(
					string.Format("/projects/{0}/contacts/people/{1}", id, compid),
					@"//person");

				foreach (Person person in somePeople)
				{
					if (person.Username == camp.User)
					{
						me = person;
						break;
					}
				}

				people.AddRange(somePeople);
			}

			return people;
		}

		/// <summary>
		/// Get message categories.
		/// </summary>
		/// <returns></returns>
		public List<MessageCategory> GetMessageCategories()
		{
			return Slurp<MessageCategory>(
				string.Format("/projects/{0}/post_categories", id),
				@"//post-category");
		}

		/// <summary>
		/// Adds a message to this project.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="body"></param>
		/// <param name="filename"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		public Message AddMessage(string title, string body, MessageCategory category, string filename)
		{
			if (category == null)
				throw new ArgumentNullException("category");

			string url = string.Format(@"/projects/{0}/msg/create", id);

			string filekey = (String.IsNullOrEmpty(filename) ? null : camp.UploadFileForMessage(filename));

			string xml = Message.XmlForCreate(title, body, category.ID, filename, filekey);

			return new Message(camp, camp.Call(url, xml).SelectSingleNode("/post"));
		}

		List<Message> messages;
		List<MessageCategory> messageCategories;

		/// <summary>
		/// Gets the list of message categories; caches results for subsequent access.
		/// </summary>
		public List<MessageCategory> MessageCategories
		{
			get
			{
				if (messageCategories == null)
					messageCategories = GetMessageCategories();

				return messageCategories;
			}
		}

		/// <summary>
		/// Gets the list of messages; caches results for subsequent access.
		/// </summary>
		public List<Message> Messages
		{
			get
			{
				if (messages == null)
					messages = GetMessages();

				return messages;
			}
		}

		/// <summary>
		/// Gets the list of messages from Basecamp.
		/// </summary>
		/// <returns></returns>
		public List<Message> GetMessages()
		{
			List<PostSummary> summaries = GetMessageSummaries();

			if (summaries.Count > 25)
				summaries = summaries.GetRange(0, 25);

			List<string> ids = new List<string>();
			
			foreach (PostSummary post in summaries)
				ids.Add(post.ID);


			List<Message> messages = Slurp<Message>(@"/msg/get/" + string.Join(@",", ids.ToArray()), @"//post");
			messages.Sort();
			return messages;
		}

		/// <summary>
		/// Gets a list of abbreviated messages.
		/// </summary>
		/// <returns></returns>
		public List<PostSummary> GetMessageSummaries()
		{
			return Slurp<PostSummary>(
				string.Format("/projects/{0}/msg/archive", id),
				@"//post");

		}

		List<ToDoList> toDoLists;

		/// <summary>
		/// Get the list of to-do lists.  Pulled from cache
		/// </summary>
		public List<ToDoList> ToDoLists
		{
			get
			{
				if (toDoLists == null)
					toDoLists = GetToDoLists();

				return toDoLists;
			}
		}

		/// <summary>
		/// Gets the to-do lists for this project.
		/// </summary>
		/// <returns></returns>
		public List<ToDoList> GetToDoLists()
		{
			return Slurp<ToDoList>(
				string.Format("/projects/{0}/todos/lists", id),
				@"//todo-list");
		}

		/// <summary>
		/// Represents the Person who is currently logged in.
		/// </summary>
		public Person Me
		{
			get { return me; }
		}

		/// <summary>
		/// Creates a new To-Do list.
		/// </summary>
		/// <param name="title">The title of the list.</param>
		/// <param name="description"></param>
		/// <param name="milestone"></param>
		/// <returns></returns>
		public ToDoList CreateToDoList(string title, string description, Milestone milestone)
		{
			return CreateToDoList(title, string.Empty, milestone == null ? string.Empty : milestone.ID
				);
		}

		/// <summary>
		/// Creates a new To-Do list.
		/// </summary>
		/// <param name="title">The title of the list.</param>
		/// <returns></returns>
		public ToDoList CreateToDoList(string title)
		{
			return CreateToDoList(title, string.Empty, string.Empty);
		}

		/// <summary>
		/// Creates a new To-Do list.
		/// </summary>
		/// <param name="title">The title of the list.</param>
		/// <param name="description">A short description for this list.</param>
		/// <returns></returns>
		public ToDoList CreateToDoList(string title, string description)
		{
			return CreateToDoList(title, description, string.Empty);
		}

		private ToDoList CreateToDoList(string title, string description, string milestoneID)
		{
			string url = string.Format(@"/projects/{0}/todos/create_list", id);

			string xml = string.Format(@"<request><milestone-id>{2}</milestone-id>
											<private>false</private>
											<tracked>false</tracked>
											<name>{0}</name>
											<description>{1}</description></request>",
										 title,
										 description,
										 milestoneID);
			return new ToDoList(camp, camp.Call(url, xml).SelectSingleNode("/todo-list"));
		}
		/// <summary>
		/// Gets the milestones for this project.
		/// </summary>
		/// <returns></returns>
		public List<Milestone> GetMilestones()
		{
			return Slurp<Milestone>(
				string.Format("/projects/{0}/milestones/list", id),
				@"//milestone");
		}

		/// <summary>
		/// Deletes a milestone.
		/// </summary>
		/// <param name="milestone"></param>
		public void DeleteMilestone(Milestone milestone)
		{
			if (milestone == null) return;

			camp.Call("/milestones/delete/" + milestone.ID);
		}

		/// <summary>
		/// Create a milesone.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="deadline"></param>
		/// <param name="responsible"></param>
		/// <param name="notify"></param>
		/// <returns></returns>
		public Milestone CreateMilestone(string title, DateTime deadline, Person responsible, bool notify)
		{
			if (responsible == null)
				throw new ArgumentException("A person must be responsible for a milestone");

			string url = string.Format(@"/projects/{0}/milestones/create", id);

			string req = string.Format(@"<request><milestone><title>{0}</title>
									<deadline type=""date"">{1}</deadline>
									<responsible-party>{2}</responsible-party>
									<notify>{3}</notify></milestone></request>",
								   title,
								   deadline.ToShortDateString(),
								   responsible.ID,
								   notify);

			return new Milestone(camp, camp.Call(url, req).SelectSingleNode("//milestone"));
		}

		#region IComparable<Project> Members

		/// <summary>
		/// Comparison.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(Project other)
		{
			return Name.CompareTo(other.Name);
		}

		#endregion
	}
}
