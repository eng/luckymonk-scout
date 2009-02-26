namespace Scout
{
    partial class AddMessageDialog
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
			this.label = new System.Windows.Forms.Label();
			this.title = new Microsoft.Ink.InkEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.category = new System.Windows.Forms.ComboBox();
			this.message = new Microsoft.Ink.InkEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.draw = new System.Windows.Forms.LinkLabel();
			this.cancel = new System.Windows.Forms.Button();
			this.ok = new System.Windows.Forms.Button();
			this.inkPicture1 = new Microsoft.Ink.InkPicture();
			((System.ComponentModel.ISupportInitialize)(this.inkPicture1)).BeginInit();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(8, 9);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(45, 20);
			this.label.TabIndex = 6;
			this.label.Text = "Title";
			// 
			// title
			// 
			this.title.Location = new System.Drawing.Point(12, 42);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(537, 67);
			this.title.TabIndex = 5;
			this.title.Text = "";
			this.title.UseMouseForInput = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Category";
			// 
			// category
			// 
			this.category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.category.FormattingEnabled = true;
			this.category.Location = new System.Drawing.Point(12, 162);
			this.category.Name = "category";
			this.category.Size = new System.Drawing.Size(441, 28);
			this.category.TabIndex = 7;
			// 
			// message
			// 
			this.message.Location = new System.Drawing.Point(12, 237);
			this.message.Name = "message";
			this.message.Size = new System.Drawing.Size(537, 67);
			this.message.TabIndex = 5;
			this.message.Text = "";
			this.message.UseMouseForInput = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 204);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Message";
			// 
			// draw
			// 
			this.draw.AutoSize = true;
			this.draw.ForeColor = System.Drawing.Color.Firebrick;
			this.draw.LinkColor = System.Drawing.Color.Red;
			this.draw.Location = new System.Drawing.Point(12, 316);
			this.draw.Name = "draw";
			this.draw.Size = new System.Drawing.Size(50, 20);
			this.draw.TabIndex = 8;
			this.draw.TabStop = true;
			this.draw.Text = "Draw";
			this.draw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.draw_LinkClicked);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(459, 350);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(90, 46);
			this.cancel.TabIndex = 12;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// ok
			// 
			this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Location = new System.Drawing.Point(363, 350);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(90, 46);
			this.ok.TabIndex = 11;
			this.ok.Text = "Post";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// inkPicture1
			// 
			this.inkPicture1.BackColor = System.Drawing.Color.White;
			this.inkPicture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.inkPicture1.Location = new System.Drawing.Point(12, 42);
			this.inkPicture1.MarginX = -2147483648;
			this.inkPicture1.MarginY = -2147483648;
			this.inkPicture1.Name = "inkPicture1";
			this.inkPicture1.Size = new System.Drawing.Size(537, 262);
			this.inkPicture1.TabIndex = 13;
			this.inkPicture1.Visible = false;
			// 
			// AddMessageDialog
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(561, 408);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.draw);
			this.Controls.Add(this.category);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.message);
			this.Controls.Add(this.label);
			this.Controls.Add(this.title);
			this.Controls.Add(this.inkPicture1);
			this.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddMessageDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Message";
			((System.ComponentModel.ISupportInitialize)(this.inkPicture1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private Microsoft.Ink.InkEdit title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox category;
        private Microsoft.Ink.InkEdit message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel draw;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
		private Microsoft.Ink.InkPicture inkPicture1;
    }
}
