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
	public partial class AddMilestoneDialog : BaseDialog
	{
		public AddMilestoneDialog() : this(null, null)
		{
		}


		public AddMilestoneDialog(Project project, string title) : this(project, title, null)
		{

		}

		public AddMilestoneDialog(Project project, string title, Milestone milestone)
		{
			InitializeComponent();

			if (title != null)
				this.title.Text = title;

			Init(project, milestone);
		}

		private void Init(Project project, Milestone milestone)
		{
			if (project != null)
			{
				comboPeople.Items.AddRange(project.GetPeople().ToArray());

				if (comboPeople.Items.Count > 0)
					comboPeople.SelectedIndex = 0;
			}

			checkBox2.Visible = checkBox3.Visible = (milestone != null);
			if (milestone != null)
			{
				title.Text = milestone.Title;
				checkBox1.Text = "Send reminder";
				ok.Text = "Update Milestone";
				for (int i = 0; i < comboPeople.Items.Count; ++i)
				{
					if ((comboPeople.Items[i] as Person).ID == milestone.PersonID)
					{
						comboPeople.SelectedIndex = i;
						break;
					}
				}
			}
		}

		public bool ShiftOthers
		{
			get { return checkBox2.Checked; }
		}

		public bool AvoidWeekends
		{
			get { return checkBox2.Checked && checkBox3.Checked; }
		}

		public bool Notify
		{
			get { return checkBox1.Checked; }
		}

		public DateTime Deadline
		{
			get { return dateTimePicker1.Value; }
		}
		public Person Responsible
		{
			get { return comboPeople.SelectedItem as Person; }
		}
	}
}