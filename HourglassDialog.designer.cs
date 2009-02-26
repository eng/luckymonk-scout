namespace Scout
{
	partial class HourglassDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.BackColor = System.Drawing.Color.Transparent;
            this.msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msg.Font = new System.Drawing.Font("Arial", 16F);
            this.msg.ForeColor = System.Drawing.Color.White;
            this.msg.Location = new System.Drawing.Point(0, 0);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(416, 84);
            this.msg.TabIndex = 0;
            this.msg.Text = "Please Wait...";
            this.msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HourglassDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(416, 84);
            this.Controls.Add(this.msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HourglassDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label msg;
	}
}
