using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scout
{
	public partial class BaseDialog : Form
	{
		protected bool fadeIn = true;
		static System.Windows.Forms.Timer timer = new Timer();

		public BaseDialog()
		{
			InitializeComponent();

			Load += new EventHandler(BaseDialog_Load);
			Shown += new EventHandler(BaseDialog_Shown);
			FormClosing += new FormClosingEventHandler(BaseDialog_FormClosing);
		}

		void BaseDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (timer != null)
				timer.Stop();
		}

		void BaseDialog_Load(object sender, EventArgs e)
		{
			if (fadeIn)
				Opacity = 0.0F;
		}

		static BaseDialog()
		{
			timer.Interval = 50;
			timer.Enabled = false;
		}

		void BaseDialog_Shown(object sender, EventArgs e)
		{
			if (fadeIn)
			{
				timer.Tick += new EventHandler(timer_Tick);
				timer.Enabled = true;
			}
		}

		void timer_Tick(object sender, EventArgs e)
		{
			if (IsDisposed) return;

			Opacity += 0.2F;

			if (Opacity > 0.9F)
			{
				timer.Enabled = false;
				timer.Tick -= new EventHandler(timer_Tick);
			}
		}

	}
}