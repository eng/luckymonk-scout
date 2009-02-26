namespace Scout
{
	partial class MessageControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.title = new System.Windows.Forms.Label();
			this.info = new System.Windows.Forms.Label();
			this.body = new Scout.VerticalLabel();
			this.SuspendLayout();
			// 
			// title
			// 
			this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.title.AutoEllipsis = true;
			this.title.BackColor = System.Drawing.Color.Transparent;
			this.title.Font = new System.Drawing.Font("Arial", 16F);
			this.title.Location = new System.Drawing.Point(-4, 0);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(154, 27);
			this.title.TabIndex = 0;
			this.title.Text = "title";
			this.title.Click += new System.EventHandler(this.title_Click);
			// 
			// info
			// 
			this.info.AutoSize = true;
			this.info.BackColor = System.Drawing.Color.Transparent;
			this.info.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.info.ForeColor = System.Drawing.Color.Gray;
			this.info.Location = new System.Drawing.Point(20, 96);
			this.info.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(50, 17);
			this.info.TabIndex = 0;
			this.info.Text = "label1";
			this.info.Click += new System.EventHandler(this.title_Click);
			// 
			// body
			// 
			this.body.AutoSize = true;
			this.body.Location = new System.Drawing.Point(20, 38);
			this.body.Name = "body";
			this.body.Size = new System.Drawing.Size(120, 20);
			this.body.TabIndex = 1;
			this.body.Text = "verticalLabel1";
			this.body.Click += new System.EventHandler(this.title_Click);
			// 
			// MessageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.body);
			this.Controls.Add(this.info);
			this.Controls.Add(this.title);
			this.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "MessageControl";
			this.Size = new System.Drawing.Size(150, 116);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label title;
		private System.Windows.Forms.Label info;
		private VerticalLabel body;

	}
}
