using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BasecampAPI;

namespace Scout
{
	public partial class ToDoListControl : Panel
	{
		public ToDoListControl()
		{
			InitializeComponent();

			AutoScroll = true;
			BackColor = Color.White;
			ControlRemoved += new ControlEventHandler(ToDoListControl_ControlRemoved);
			Margin = new Padding(0);
		}

		public event EventHandler<ToDoListEventArgs> ItemEdit;

		void ToDoListControl_ControlRemoved(object sender, ControlEventArgs e)
		{
			ToDoItemControl todo = sender as ToDoItemControl;
			if (todo != null && !todo.IsDisposed && todo.ToDoItem != null)
			{
				ListenToItem(todo.ToDoItem, false);
			}
		}

		ToDoList list;
		ComboBox comboList;
		List<Person> people;

		public void SetPeople(List<Person> people)
		{
			this.people = people;
		}

		string personToFindID;

		bool FindPerson(Person p)
		{
			return p.ID == personToFindID;
		}

		Dictionary<ToDoItem, ToDoItemControl> controlsByItem = new Dictionary<ToDoItem, ToDoItemControl>();
		
		public void SetList(ToDoList list)
		{
			ListenToList(false);

			this.list = list;

			ListenToList(true);

			Fill();
		}


		public void SetListCombo(ComboBox comboList)
		{
			ListenToCombo(false);
			this.comboList = comboList;
			ListenToCombo(true);

			if (comboList != null)
			{
				ToDoList list = comboList.SelectedItem as ToDoList;
				SetList(list);
			}
		}

		private void ListenToCombo(bool listen)
		{
			if (comboList == null) return;

			if (listen)
				comboList.SelectedIndexChanged += new EventHandler(comboList_SelectedIndexChanged);
			else
				comboList.SelectedIndexChanged -= new EventHandler(comboList_SelectedIndexChanged);
		}

		void comboList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ToDoList list = comboList.SelectedItem as ToDoList;
			SetList(list);
		}

		private void Add(ToDoItem item)
		{
			ToDoItemControl c = new ToDoItemControl();
			c.Size = new Size(1, 30);
			c.ToDoItem = item;
			c.Font = Font;
			c.Location = new Point(0, Controls.Count * 30);
			c.Width = (int)((double)ClientSize.Width * 0.9);
			c.Margin = new Padding(0);
			c.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

			if (people != null)
			{
				personToFindID = item.PersonID;
				c.Person = people.Find(FindPerson);
			}

			c.Editing += new EventHandler(c_Editing);
			ListenToItem(item, true);
			Controls.Add(c);

			controlsByItem[item] = c;
		}

		void c_Editing(object sender, EventArgs e)
		{
			if (ItemEdit != null)
				ItemEdit(this, new ToDoListEventArgs((sender as ToDoItemControl).ToDoItem));
		}

		private void Fill()
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				DisposeInternals();

				Controls.Clear();

				controlsByItem.Clear();

				if (list != null)
					list.GetItems().ForEach(Add);
			}

			finally
			{
				Cursor = Cursors.Default;
                Refresh();
			}
		}

		private void DisposeInternals()
		{
			foreach (Control c in Controls)
			{
				ToDoItemControl todo = c as ToDoItemControl;
				if (todo != null)
				{
					todo.Editing -= new EventHandler(c_Editing);
					ListenToItem(todo.ToDoItem, false);
				}
				//c.Dispose();
			}
		}

		private void ListenToList(bool listen)
		{
			if (list == null) return;

			if (listen)
				list.Changed += new EventHandler(list_Changed);
			else
				list.Changed -= new EventHandler(list_Changed);
		}

		void list_Changed(object sender, EventArgs e)
		{
			Fill();
		}

		private void ListenToItem(ToDoItem item, bool listen)
		{
			if (item == null) return;

			if (listen)
			{
				item.PositionChanged += new EventHandler(item_PositionChanged);
				item.PersonChanged += new EventHandler(item_PersonChanged);
                item.CompletedChanged += new EventHandler(item_CompletedChanged);
			}
			else
			{
				item.PositionChanged -= new EventHandler(item_PositionChanged);
				item.PersonChanged += new EventHandler(item_PositionChanged);
                item.CompletedChanged -= new EventHandler(item_CompletedChanged);
            }
		}

        void item_CompletedChanged(object sender, EventArgs e)
        {
            Fill();
        }

		void item_PersonChanged(object sender, EventArgs e)
		{
			if (people != null)
			{
				ToDoItem item = sender as ToDoItem;
				personToFindID = item.PersonID;
				if (controlsByItem.ContainsKey(item))
					controlsByItem[item].Person= people.Find(FindPerson);
			}
		}

		void item_PositionChanged(object sender, EventArgs e)
		{
			Fill();
		}
	}

	public class ToDoListEventArgs : EventArgs
	{
		public ToDoListEventArgs(ToDoItem item)
		{
			Item = item;
		}

		public readonly ToDoItem Item;
	}

	
}
