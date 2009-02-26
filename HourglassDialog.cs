using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scout
{
	public partial class HourglassDialog : BaseDialog
	{
		public HourglassDialog() : this(null)
		{
		}

		public HourglassDialog(string message)
		{
			InitializeComponent();

			fadeIn = false;

			if (message != null)
				msg.Text = message;
		}

		public string Message
		{
			get { return msg.Text; }
			set
			{
				if (value != null)
					msg.Text = value;
				else
					msg.Text = string.Empty;
			}
		}
	}
}

