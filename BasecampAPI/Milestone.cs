using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace BasecampAPI
{
	/// <summary>
	/// Represents a milestone.
	/// </summary>
	public class Milestone : BasecampItem
	{
		private string title = string.Empty;
		private bool completed = false;
		private DateTime deadline;
		private string personID = string.Empty;

		/// <summary>
		/// The deadline.
		/// </summary>
		public DateTime Deadline
		{
			get { return deadline; }
		}

		/// <summary>
		/// The ID.
		/// </summary>
		public string ID
		{
			get { return id; }
		}

		/// <summary>
		/// True if this milestone has been completed.
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
				}
			}
		}

		private string XmlForUpdate(bool notify, bool shift, bool avoidWeekends)
		{
				return string.Format(
					@"<request><milestone><title>{0}</title>" + 
					@"<deadline>{1}</deadline>"+
					@"<responsible-party>{2}</responsible-party>" +
					@"<notify>{3}</notify></milestone>" +
					@"<move-upcoming-milestones>{4}</move-upcoming-milestones>" +
					@"<move-upcoming-milestones-off-weekends>{5}</move-upcoming-milestones-off-weekends>" +
					@"<request>", title, deadline.ToShortDateString(), personID, notify, shift, avoidWeekends);
		}

		private void SendUpdate()
		{
			if (String.IsNullOrEmpty(id)) return;

			//camp.Call(@"/todos/update_item/" + id, XmlForUpdate);
		}

		/// <summary>
		/// Send real-time update of this milestone with the given attributes.
		/// </summary>
		/// <param name="newTitle"></param>
		/// <param name="newDeadline"></param>
		/// <param name="newResponsible"></param>
		/// <param name="shiftOthers"></param>
		/// <param name="offWeekends"></param>
		/// <param name="notify"></param>
		public void Update(string newTitle, DateTime newDeadline, Person newResponsible,
			bool shiftOthers, bool offWeekends, bool notify)
		{
			title = newTitle;
			deadline = newDeadline;
			personID = newResponsible.ID;

			camp.Call("/milestones/update/" + id,XmlForUpdate(notify, shiftOthers, offWeekends));
		}

		private void SendCompleted()
		{
			// /milestones/complete/#{id}

			if (completed)
				camp.Call("/milestones/complete/" + id);
			else
				camp.Call("/milestones/uncomplete/" + id);
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="camp"></param>
		/// <param name="node"></param>
		public Milestone(Basecamp camp, XmlNode node)
			: base(camp)
		{
			if (node != null)
			{
				title = node["title"].InnerText.Trim();
				completed = (node["completed"].InnerText.Trim() == "true");
				string dt = node["deadline"].InnerText.Trim();
				deadline = DateTime.Parse(dt);
				id = node["id"].InnerText.Trim();
				personID = node["responsible-party-id"].InnerText.Trim();
			}
		}

		/// <summary>
		/// The ID of the person responsible for this milestone.
		/// </summary>
		public string PersonID
		{
			get { return personID; }
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title
		{
			get { return title; }
		}

		/// <summary>
		/// Returns the title.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return title;
		}
	}
}
