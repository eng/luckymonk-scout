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
	public partial class MessageControl : UserControl
	{
		BasecampAPI.Message message;

		public MessageControl() 
		{
			InitializeComponent();
			body.Initializing = false;
		}

		public BasecampAPI.Message Message { get { return message; } }

		public void SetMessage(BasecampAPI.Message message)
		{
			this.message = message;

			if (message != null)
			{
				this.title.Text = message.Title;
				this.body.Text = message.Body;

				int n = message.CommentsCount;
				string commentDisplay = string.Format("{0} comment{1}.", n, n != 1 ? "s" : string.Empty);
				string person = (message.Author != null ? message.Author.ToString() : "Unknown");

				info.Text = string.Format("Posted on {0} by {1}.  {2}", message.PostedOn.ToShortDateString(),  person, commentDisplay);
				info.Top = body.Bottom + 5;
			}
		}

		internal void SetComment(PostComment c)
		{
			this.message = null;

			if (c != null)
			{
				this.title.Text = string.Empty;
				this.body.Text = c.Body;

				string person = (c.Author != null ? c.Author.ToString() : "Unknown");

				info.Text = string.Format("Posted on {0} at {1} by {2}", c.PostedOn.ToShortDateString(), c.PostedOn.ToLongTimeString(), person);
				info.Top = body.Bottom + 5;
			}
		}

		private void title_Click(object sender, EventArgs e)
		{
			OnClick(e);
		}
	}
}
