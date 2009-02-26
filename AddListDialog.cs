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
	public partial class AddListDialog : BaseDialog
	{
		Project project;

		public AddListDialog()
			: this(null)
		{
		}

		public AddListDialog(Project project)
		{
			InitializeComponent();

			if (project != null)
			{
				this.project = project;
				comboBox1.Items.Add("NONE");

				List<Milestone> stones = project.GetMilestones();
				comboBox1.Items.AddRange(stones.ToArray());
				comboBox1.SelectedIndex = 0;
				ok.Click += new EventHandler(ok_Click);
			}
			else
			{
				ok.Enabled = false;
			}

			comboBox1.Enabled = comboBox1.Items.Count > 1;
		}

		public ToDoList NewList;

		void ok_Click(object sender, EventArgs e)
		{
			if (title.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter a title for the list.");
				title.Select();
				return;
			}

			NewList = project.CreateToDoList(title.Text.Trim(), string.Empty, comboBox1.SelectedItem as Milestone);
			Close();
		}
	}
}