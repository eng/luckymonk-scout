using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BasecampAPI;
using System.Diagnostics;
using System.IO;

namespace Scout
{
    public partial class Form1 : Form
    {

		public class LogListener : TextWriterTraceListener
		{
			public LogListener(System.IO.FileStream fs)
				: base(fs)
			{
			}

			public override void WriteLine(string message)
			{
				base.WriteLine(string.Format("{0}\t{1}", DateTime.Now.ToString(), message));
			}
		}
        public Form1()
        {
            InitializeComponent();

			string[] args = Environment.GetCommandLineArgs();
			if (args.Length > 1 && (args[1].ToLower() == "-l" || args[1].ToLower() == "--log"))
				StartLog();
        }

		private static void StartLog()
		{
			string filename = @"scout.log";

			if (File.Exists(filename))
			{
				try
				{
					File.Delete(filename);
				}
				catch
				{
				}
			}

			System.IO.FileStream log = new System.IO.FileStream(Path.Combine(Application.StartupPath, filename), FileMode.Append);
			TextWriterTraceListener listener = new LogListener(log);
			Trace.Listeners.Add(listener);
			Trace.AutoFlush = true;

			Trace.WriteLine("-----------------------------------------------------------------");
			Trace.WriteLine(String.Format("Scout started up at {0}", DateTime.Now.ToLongDateString()));
		}

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            LoginForm form = new LoginForm();

			Hide();

			if (form.ShowDialog(this) == DialogResult.OK)
            {
				ListenForWebEvents(false);

				Show();

				tabs.Visible = true;
				projects.Visible = true;

                Basecamp = form.BasecampObject;

				ListenForWebEvents(true);

				List<Project> p = new List<Project>(Basecamp.Projects.Values);
				projects.Items.AddRange(p.ToArray());
                if (projects.Items.Count > 0) projects.SelectedIndex = 0;

                toDoListControl1.ItemEdit += new EventHandler<ToDoListEventArgs>(toDoListControl1_ItemEdit);
            }
            else
            {
                this.Close();
            }
        }

		private void ListenForWebEvents(bool listen)
		{
			if (Basecamp == null) return;

			if (listen)
			{
				Basecamp.WebCallStarted += new EventHandler(Basecamp_WebCallStarted);
				Basecamp.WebCallFinished += new EventHandler(Basecamp_WebCallFinished);
			}
			else
			{
				Basecamp.WebCallStarted -= new EventHandler(Basecamp_WebCallStarted);
				Basecamp.WebCallFinished -= new EventHandler(Basecamp_WebCallFinished);
			}
		}

		Hourglass hourglass;

		void StartHourglass()
		{
			if (hourglass == null)
				hourglass = new Hourglass("Contacting Basecamp...");	
		}

		void Basecamp_WebCallStarted(object sender, EventArgs e)
		{
			StartHourglass();
			//new MethodInvoker(StartHourglass).BeginInvoke(null, null);
			
		}
		
		void Basecamp_WebCallFinished(object sender, EventArgs e)
		{
			if (hourglass != null)
				hourglass.Dispose();
			hourglass = null;
		}

		
		void toDoListControl1_ItemEdit(object sender, ToDoListEventArgs e)
		{
			new EditToDoItemDialog(CurrentProject, e.Item).ShowDialog(this);
			Refresh();
		}

        private void tabs_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "todoTab":
                    RefreshToDos();
                    break;
				case "messageTab":
					RefreshMessages();
					break;

                default:
					RefreshMilestones();
                    break;
            }
        }

		private void RefreshMessages()
		{
				if (CurrentProject == null) return;

				comments.Visible = false;
				messages.Visible = true;
				messages.BringToFront();
				messages.SetProject(CurrentProject);
				label3.Text = "Tap a message to read comments.";
				label.Text = "Add a message";
		}

		private void RefreshMilestones()
		{
			listMilestones.Items.Clear();
			listMilestones.ItemChecked -= new ItemCheckedEventHandler(listMilestones_ItemChecked);

			Project project = projects.SelectedItem as Project;

			if (project != null)
			{
				List<Milestone> stones = project.GetMilestones();
				foreach (Milestone stone in stones)
				{
					ListViewItem item = new ListViewItem(new string[] { stone.Title, stone.Deadline.ToShortDateString() });

					ListViewGroup group = listMilestones.Groups["groupComingUp"];

					if (stone.IsCompleted)
					{
						group = listMilestones.Groups["groupCompleted"];
						item.Checked = true;
						item.ForeColor = Color.Green;
					}
					else if (stone.Deadline < DateTime.Now)
					{
						group = listMilestones.Groups["groupPast"];
						item.ForeColor = Color.DarkRed;
					}

					item.Group = group;
					item.Tag = stone;
					listMilestones.Items.Add(item);
				}
			}

			listMilestones.Columns[0].Width = listMilestones.Width * 3 / 4;
			listMilestones.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

			listMilestones.ItemChecked += new ItemCheckedEventHandler(listMilestones_ItemChecked);
		}

        private void RefreshToDos()
        {
			toDoListControl1.SetListCombo(null);
			toDoListControl1.SetPeople(People);

			todoList.Items.Clear();
			Project project = projects.SelectedItem as Project;

			if (project != null)
			{
				todoList.Items.AddRange(CurrentProject.ToDoLists.ToArray());
				if (todoList.Items.Count > 0) todoList.SelectedIndex = 0;

				toDoListControl1.SetListCombo(todoList);
			}
        }

       

        public static Basecamp Basecamp;
        public static List<Person> People;

        private void projects_SelectedIndexChanged(object sender, EventArgs e)
        {
				RefreshPeople();

				switch (tabs.SelectedIndex)
				{
					case 0: RefreshMessages(); break;
					case 1: RefreshToDos(); break;
					case 2: RefreshMilestones(); break;
				}
        }

		private Project CurrentProject
		{
			get { return (projects.SelectedItem as Project); }
		}

        private void RefreshPeople()
        {
			People = new List<Person>(CurrentProject.People.Values);
        }

        
        private void addItem_Recognition(object sender, Microsoft.Ink.InkEditRecognitionEventArgs e)
        {
            if (todoList.SelectedIndex > -1 && todoList.SelectedItem != null)
            {
                (todoList.SelectedItem as ToDoList).Add(e.RecognitionResult.ToString());
                addItem.Text = String.Empty;
            }
            ClearInput();
        }

        private void addMilestone_Recognition(object sender, Microsoft.Ink.InkEditRecognitionEventArgs e)
        {
            string title = e.RecognitionResult.ToString();

            AddMilestoneDialog dlg = new AddMilestoneDialog(CurrentProject, title);

            if (DialogResult.OK == dlg.ShowDialog(this))
            {
                HourglassDialog dialog = new HourglassDialog();
                dialog.Message = "Creating milestone...";
                dialog.Show();
                Application.DoEvents();

                using (dialog)
                {
                    CurrentProject.CreateMilestone(title, dlg.Deadline, dlg.Responsible,
                    dlg.Notify);
                }

                RefreshMilestones();
            }

            ClearInput();
        }

		private void listMilestones_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			Milestone stone = e.Item.Tag as Milestone;

			if (stone != null)
				stone.IsCompleted = e.Item.Checked;

			RefreshMilestones();
		}

		private Milestone SelectedMilestone
		{
			get 
			{
				if (listMilestones.SelectedItems.Count == 0)
					return null;

				return listMilestones.SelectedItems[0].Tag as Milestone; 
			}
		}
		private void listMilestones_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Milestone stone = SelectedMilestone;
				if (stone != null)
				{
					menuMilestones.Show(listMilestones, e.Location);
				}
			}
		}

		private void deleteThisMilesoneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Project project = CurrentProject;

			if (project != null)
			{
				project.DeleteMilestone(SelectedMilestone);
				RefreshMilestones();
			}
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Milestone milestone = SelectedMilestone;
			Project project = CurrentProject;

			if (project != null && milestone != null)
			{
				AddMilestoneDialog dlg = new AddMilestoneDialog(project, null, milestone);
				if (DialogResult.OK == dlg.ShowDialog(this))
				{
					milestone.Update(milestone.Title, dlg.Deadline,
						dlg.Responsible, dlg.ShiftOthers, dlg.AvoidWeekends,
						dlg.Notify);
					RefreshMilestones();
				}
			}

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			AddListDialog dlg = new AddListDialog(CurrentProject);

			if (DialogResult.OK == dlg.ShowDialog(this))
			{
				if (dlg.NewList != null)
				{
					todoList.Items.Add(dlg.NewList);
					todoList.SelectedItem = dlg.NewList;
				}
			}
		}

        private void settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			new SettingsForm().ShowDialog(this);
        }

        private void logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLogin();
        }

		private void comments_MessageClicked(object sender, MessageListEventArgs e)
		{
			RefreshMessages();
		}

		private void messages_MessageClicked(object sender, MessageListEventArgs e)
		{
			ShowComments(e.Message);
		}

		private void ShowComments(BasecampAPI.Message message)
		{
			messages.Visible = false;
			comments.BringToFront();
			comments.SetMessage(message);
			comments.Visible = true;
			label3.Text = "Tap anywhere to go back to the list of messages.";
			label.Text = "Add a comment";
		}

		private void comments_MouseClick(object sender, MouseEventArgs e)
		{
			RefreshMessages();
		}

		private void messages_MouseClick(object sender, MouseEventArgs e)
		{
			
		}

        private void newMessage_Recognition(object sender, Microsoft.Ink.InkEditRecognitionEventArgs e)
        {
			if (messages.Visible)
			{
				AddMessageDialog form = new AddMessageDialog(CurrentProject, e.RecognitionResult.ToString());
				if (DialogResult.OK == form.ShowDialog(this))
				{
					CurrentProject.AddMessage(form.Title, form.Body, form.Category, form.Filename);
					RefreshMessages();
				}
			}

			else if (comments.Message != null)
			{
				AddMessageDialog form = new AddMessageDialog(comments.Message, e.RecognitionResult.ToString());
				if (DialogResult.OK == form.ShowDialog(this))
				{
					comments.Message.AddComment(form.Body);
					ShowComments(comments.Message);
				}
			}

            ClearInput();
        }

        private void ClearInput()
        {
            // This is totally ghetto.
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            newMessage.Text = String.Empty;
            addItem.Text = String.Empty;
            addMilestone.Text = String.Empty;
            timer.Tick -= new EventHandler(timer_Tick);
        }

        Timer timer;
    }

	class Hourglass : IDisposable
	{
		HourglassDialog dlg;

		public Hourglass() : this(null)
		{
		}

		public Hourglass(string message)
		{
			try
			{
				if (message != null)
				{
					dlg = new HourglassDialog(message);
					dlg.Show();
					Application.DoEvents();
				}
				else if (Form.ActiveForm != null)
					Form.ActiveForm.Cursor = Cursors.WaitCursor;

				
			}

			catch
			{
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			try
			{
				if (Form.ActiveForm != null)
					Form.ActiveForm.Cursor = Cursors.Default;

				if (dlg != null)
					dlg.BeginInvoke(new MethodInvoker(dlg.Close));
			}

			catch
			{
			}
		}

		#endregion
	}
}