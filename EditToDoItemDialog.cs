using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BasecampAPI;

namespace Scout
{
	public partial class EditToDoItemDialog : Scout.BaseDialog
	{
		Project project;
		ToDoItem item;

		public EditToDoItemDialog() : this(null, null)
		{
		}

		public EditToDoItemDialog(Project project, ToDoItem item)
		{
			InitializeComponent();

			this.project = project;
			this.item = item;

			if (project != null)
			{
				comboPeople.Items.Add(Person.Nobody);
				comboPeople.Items.AddRange(new List<Person>(project.People.Values).ToArray());

				bool found = false;

				if (!String.IsNullOrEmpty(item.PersonID))
				{
					for (int i = 0; !found && i < comboPeople.Items.Count; ++i)
					{
						if ((comboPeople.Items[i] as Person).ID == item.PersonID)
						{
							comboPeople.SelectedIndex = i;
							found = true;
						}
					}
				}

				if (!found && comboPeople.Items.Count > 0)
					comboPeople.SelectedIndex = 0;
			}

			if (item != null)
				title.Text = item.Content;
		}

		private void ok_Click(object sender, EventArgs e)
		{
			if (item != null)
			{
				item.Content = title.Text.Trim();
				item.PersonID = (comboPeople.SelectedItem as Person).ID;
			}
		}
	}
}

