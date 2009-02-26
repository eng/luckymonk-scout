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
	public partial class MessageListControl : UserControl
	{
		public MessageListControl()
		{
			InitializeComponent();

			table.AutoSize = true;
			table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}

		public event EventHandler<MessageListEventArgs> MessageClicked;

		public BasecampAPI.Message Message;

		public void SetMessage(BasecampAPI.Message message)
		{
			StopListeningToControls();

			this.Message = message;

			table.Controls.Clear();

			List<PostComment> comments = message.Comments;

			AddMessageControl(message);
			AddSeperator();

			foreach (PostComment comment in comments)
			{

				MessageControl c = new MessageControl();
				c.Height = 100;
				c.Width = 100;
				c.Visible = true;
				c.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				table.Controls.Add(c);
				int row = table.GetCellPosition(c).Row;
				table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				c.SetComment(comment);
			}
		}

		public void SetProject(Project project)
		{
			StopListeningToControls();

			table.Controls.Clear();

            List<BasecampAPI.Message> messages = null;
            try { messages = project.Messages; }
            catch { }

            if (messages != null)
            {
                DateTime date = DateTime.MinValue;

                foreach (BasecampAPI.Message m in messages)
                {

                    if (m.PostedOn.Date != date)
                    {
                        date = m.PostedOn;
                        AddSeperator();
                        //CreateDateLine(date);
                    }

                    MessageControl c = AddMessageControl(m);
                }
            }
		}

		private MessageControl AddMessageControl(BasecampAPI.Message m)
		{
			MessageControl c = new MessageControl();
			c.Height = Width;
			c.Width = 100;
			c.AutoSize = true;
			c.Visible = true;
			c.Dock = DockStyle.Fill;
			table.Controls.Add(c);
			c.SetMessage(m);
			c.Click += new EventHandler(Message_Click);
			return c;
		}

		private void StopListeningToControls()
		{
			foreach (Control c in table.Controls)
			{
				MessageControl mc = c as MessageControl;
				if (mc != null)
				{
					c.Click -= new EventHandler(Message_Click);
				}
			}
		}

		void Message_Click(object sender, EventArgs e)
		{
			MessageControl mc = sender as MessageControl;

			if (mc != null && MessageClicked != null)
				MessageClicked(this, new MessageListEventArgs(mc.Message));
		}

		private void AddSeperator()
		{
			Label label = new Label();
			label.AutoSize = false;
			label.BackColor = Color.DarkGray;
			label.Height = 1;
			label.Width = Width;
			label.Anchor = AnchorStyles.Left | AnchorStyles.Right;

			table.Controls.Add(label);
		}

		private void CreateDateLine(DateTime date)
		{
			Label label = new Label();
			label.AutoSize = true;
			label.Text = date.ToShortDateString();
			label.Dock = DockStyle.Left;
			label.Font = new Font(Font.FontFamily, 10.0F, FontStyle.Italic | FontStyle.Underline);
			label.ForeColor = Color.DarkGray;
			
			table.Controls.Add(label);
		}
	
	}

	public class MessageListEventArgs : EventArgs
	{
		public MessageListEventArgs(BasecampAPI.Message message)
		{
			Message = message;
		}

		public readonly BasecampAPI.Message Message;
	}
}
