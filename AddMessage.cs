using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BasecampAPI;
using System.IO;

namespace Scout
{
    public partial class AddMessageDialog : Scout.BaseDialog
    {
		string filename = null;

        public AddMessageDialog() 
        {
			InitializeComponent();

        }

		public AddMessageDialog(BasecampAPI.Message messageObj, string comment)
		{
			InitializeComponent();

			label.Visible = title.Visible = label1.Visible = category.Visible = false;

			int bottom = message.Bottom;
			message.Top = title.Top;
			message.Height = bottom - message.Top;
			label2.Location = label.Location;
			label2.Text = "Comment";
			message.Text = comment.Trim();
		}

        public AddMessageDialog(Project project, string title)
        {
            InitializeComponent();

			if (title != null)
				this.title.Text = title;

			if (project != null)
			{
				category.Items.AddRange(project.MessageCategories.ToArray());
				if (category.Items.Count > 0)
					category.SelectedIndex = 0;
			}
        }

		public BasecampAPI.MessageCategory Category { get { return category.SelectedItem as MessageCategory; } }
		public string Title { get { return title.Text.Trim(); } }
		public string Body { get { return message.Text.Trim(); }  }
		public string Filename
		{
			get { return filename; }
		}

		private void draw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			inkPicture1.Visible = !inkPicture1.Visible;
		}

		private void ok_Click(object sender, EventArgs e)
		{
            HourglassDialog dialog = new HourglassDialog();
            dialog.Message = "Posting message...";
            dialog.Show();
            Application.DoEvents();

            using (dialog)
            {
                if (inkPicture1.Visible)
                {
                    byte[] gif = inkPicture1.Ink.Save(Microsoft.Ink.PersistenceFormat.Gif);
                    filename = "picture.jpg";
                    Image bitmap = Image.FromStream(new MemoryStream(gif));
                    bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    inkPicture1.Dispose();
                }
            }

			DialogResult = DialogResult.OK;
		}
		
    }
}

