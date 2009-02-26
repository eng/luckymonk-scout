using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// A To-Do item.
	/// </summary>
	public class ToDoItem : BasecampItem, IComparable<ToDoItem>
	{
		private string content;
		private int position = 0;
		private bool completed;
		private string personID;
		private ToDoList list;

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public ToDoItem(Basecamp camp, XmlNode node) : base(camp)
		{
			if (node != null)
			{
				id = node["id"].InnerText.Trim();
				content = node["content"].InnerText.Trim();
				position = int.Parse(node["position"].InnerText.Trim());
				completed = bool.Parse(node["completed"].InnerText.Trim());

				if (node.InnerXml.Contains("/responsible-party-id"))
					personID = node["responsible-party-id"].InnerText.Trim();
			}
		}

		/// <summary>
		/// Reference to the list that owns this item.
		/// </summary>
		public ToDoList List
		{
			get { return list; }
			internal set { list = value; }
		}

		/// <summary>
		/// Moves this item to another list.  This call invalidates the position
		/// values for elements in each list, so you should re-get the items for each list
		/// after this call.
		/// </summary>
		/// <param name="list"></param>
		public void MoveTo(ToDoList list)
		{
			ToDoList.MoveItem(this, list);
		}

		/// <summary>
		/// The ID of this item.
		/// </summary>
		public string ID
		{
			get { return id; }
			set 
			{ 
				id = value;
				SendUpdate();
			}
		}

		internal static string MakeXmlForCreate(string title)
		{
			return string.Format(
					@"<request><content>{0}</content>" +
					@"<responsible-party></responsible-party>" +
					@"<notify>false</notify>" +
					@"<request>", title);
		}

		private string XmlForUpdate
		{
			get
			{
				return string.Format(
					@"<request><item><content>{0}</content></item>" +
					(!String.IsNullOrEmpty(personID) ? @"<responsible-party>{1}</responsible-party>" : string.Empty) +
					@"<notify>false</notify>" +
					@"<request>", content, personID);
			}
		}
		private void SendUpdate()
		{
			if (String.IsNullOrEmpty(id)) return;

			camp.Call(@"/todos/update_item/" + id, XmlForUpdate);
		}

		/// <summary>
		/// The person responsible for this item.
		/// </summary>
		public string PersonID
		{
			get { return personID; }
			set 
			{
				if (personID != value)
				{
					personID = value;
					SendUpdate();
					if (PersonChanged != null)
						PersonChanged(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// True if this item has been completed.
		/// </summary>
		public bool IsCompleted
		{
			get { return completed; }
			set 
			{
				if (completed != value)
				{
					completed = value;
					SendCompleted();
					if (CompletedChanged != null)
						CompletedChanged(this, EventArgs.Empty);
				}
			}
		}

		private void SendCompleted()
		{
			if (String.IsNullOrEmpty(id)) return;

			if (completed)
				camp.Call("/todos/complete_item/" + id);
			else
				camp.Call("/todos/uncomplete_item/" + id);
		}

		/// <summary>
		/// Raised when the position is changed.
		/// </summary>
		public event EventHandler PositionChanged;

		/// <summary>
		/// Raised when the position is changed.
		/// </summary>
		public event EventHandler CompletedChanged;

		/// <summary>
		/// Raised when the assigned PersonID is changed.
		/// </summary>
		public event EventHandler PersonChanged;

		/// <summary>
		/// Gets or sets the position of this item in the list, starting at 1.
		/// You should re-get the entire list if you change the position of an item.
		/// </summary>
		public int Position
		{
			get { return position; }
			set 
			{
				if (position != value)
				{
					position = value;
					SendMove();
					if (PositionChanged != null)
						PositionChanged(this, EventArgs.Empty);
				}

			}
		}

		private void SendMove()
		{
			string xml = string.Format(@"<request><to>{0}</to></request>", position);
			camp.Call(@"/todos/move_item/" + id, xml);
		}

		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			get { return content; }
			set { content = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return content;
		}

		#region IComparable<ToDoItem> Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(ToDoItem other)
		{
			if (!IsCompleted && other.IsCompleted)
				return -1;

			if (IsCompleted && !other.IsCompleted)
				return +1;

			return position.CompareTo(other.position);
		}

		#endregion
	}
}
