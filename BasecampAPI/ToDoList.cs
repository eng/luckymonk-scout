using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// A To Do list
	/// </summary>
	public class ToDoList : BasecampItem
	{
		private string description;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public ToDoList(Basecamp camp, XmlNode node) : base(camp)
		{
			if (node != null)
			{
				name = node["name"].InnerText.Trim();
				id = node["id"].InnerText.Trim();

				if (node.InnerXml.Contains("<description>"))
				{
					description = node["description"].InnerText.Trim();
					description = description.Replace("\n", Environment.NewLine);
				}
			}
		}

		/// <summary>
		/// Raised when something about this item has changed.
		/// </summary>
		public event EventHandler Changed;

		/// <summary>
		/// Optional description for this list.
		/// </summary>
		public string Description
		{
			get { return String.IsNullOrEmpty(description) ? string.Empty : description; }
			set { description = value; }
		}

		
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// The name of the list.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Move an item to a different list.
		/// </summary>
		/// <param name="item">The item to move.</param>
		/// <param name="list">The list that should receive the item.</param>
		public static void MoveItem(ToDoItem item, ToDoList list)
		{
			if (item.List == null)
				throw new ArgumentException("The item is not part of any list.");

			ToDoItem newItem = list.Add(item.Content);
			newItem.PersonID = item.PersonID;

			item.List.Delete(item);
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<ToDoItem> GetItems()
		{
			List<ToDoItem> items = Slurp<ToDoItem>(
				string.Format("/todos/list/{0}", id),
				@"//todo-item");

			items.ForEach(delegate(ToDoItem item) { item.List = this; });

			items.Sort();

			return items;
		}

		/// <summary>
		/// Add a new item to the list.
		/// </summary>
		/// <param name="text"></param>
		public ToDoItem Add(string text)
		{
			try
			{
				XmlDocument doc = camp.Call(@"/todos/create_item/" + id, ToDoItem.MakeXmlForCreate(text));

				return new ToDoItem(camp, doc.SelectSingleNode("/todo-item"));
			}

			finally
			{
				if (Changed != null) Changed(this, EventArgs.Empty);

			}
		}

		/// <summary>
		/// Deletes an item from the list.
		/// </summary>
		/// <param name="item"></param>
		public void Delete(ToDoItem item)
		{
			camp.Call(@"/todos/delete_item/" + item.ID);

			if (Changed != null) Changed(this, EventArgs.Empty);
		}
	}
}
