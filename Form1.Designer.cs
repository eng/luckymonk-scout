namespace Scout
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Coming Up", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Past Due", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Completed", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tabs = new System.Windows.Forms.TabControl();
			this.messageTab = new System.Windows.Forms.TabPage();
			this.label = new System.Windows.Forms.Label();
			this.newMessage = new Microsoft.Ink.InkEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.messages = new Scout.MessageListControl();
			this.comments = new Scout.MessageListControl();
			this.todoTab = new System.Windows.Forms.TabPage();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.addItem = new Microsoft.Ink.InkEdit();
			this.toDoListControl1 = new Scout.ToDoListControl();
			this.todoList = new System.Windows.Forms.ComboBox();
			this.milestoneTab = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.addMilestone = new Microsoft.Ink.InkEdit();
			this.listMilestones = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.Due = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.logout = new System.Windows.Forms.LinkLabel();
			this.settings = new System.Windows.Forms.LinkLabel();
			this.projects = new System.Windows.Forms.ComboBox();
			this.menuMilestones = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteThisMilesoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label5 = new System.Windows.Forms.Label();
			this.tabs.SuspendLayout();
			this.messageTab.SuspendLayout();
			this.todoTab.SuspendLayout();
			this.milestoneTab.SuspendLayout();
			this.panel1.SuspendLayout();
			this.menuMilestones.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.messageTab);
			this.tabs.Controls.Add(this.todoTab);
			this.tabs.Controls.Add(this.milestoneTab);
			this.tabs.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabs.ItemSize = new System.Drawing.Size(120, 40);
			this.tabs.Location = new System.Drawing.Point(0, 77);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(651, 499);
			this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabs.TabIndex = 0;
			this.tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabs_Selected);
			// 
			// messageTab
			// 
			this.messageTab.BackColor = System.Drawing.Color.White;
			this.messageTab.Controls.Add(this.label);
			this.messageTab.Controls.Add(this.newMessage);
			this.messageTab.Controls.Add(this.label3);
			this.messageTab.Controls.Add(this.messages);
			this.messageTab.Controls.Add(this.comments);
			this.messageTab.Location = new System.Drawing.Point(4, 44);
			this.messageTab.Name = "messageTab";
			this.messageTab.Padding = new System.Windows.Forms.Padding(3);
			this.messageTab.Size = new System.Drawing.Size(643, 451);
			this.messageTab.TabIndex = 0;
			this.messageTab.Text = "Messages";
			// 
			// label
			// 
			this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(9, 393);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(129, 20);
			this.label.TabIndex = 4;
			this.label.Text = "Add a message";
			// 
			// newMessage
			// 
			this.newMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.newMessage.Location = new System.Drawing.Point(144, 374);
			this.newMessage.Name = "newMessage";
			this.newMessage.Size = new System.Drawing.Size(489, 67);
			this.newMessage.TabIndex = 3;
			this.newMessage.Text = "";
			this.newMessage.UseMouseForInput = true;
			this.newMessage.Recognition += new Microsoft.Ink.InkEditRecognitionEventHandler(this.newMessage_Recognition);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(8, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(281, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tap a message to view comments.";
			// 
			// messages
			// 
			this.messages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.messages.AutoScroll = true;
			this.messages.BackColor = System.Drawing.Color.Transparent;
			this.messages.Location = new System.Drawing.Point(10, 42);
			this.messages.Margin = new System.Windows.Forms.Padding(5);
			this.messages.Name = "messages";
			this.messages.Size = new System.Drawing.Size(623, 325);
			this.messages.TabIndex = 0;
			this.messages.MessageClicked += new System.EventHandler<Scout.MessageListEventArgs>(this.messages_MessageClicked);
			this.messages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.messages_MouseClick);
			// 
			// comments
			// 
			this.comments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comments.AutoScroll = true;
			this.comments.BackColor = System.Drawing.Color.Transparent;
			this.comments.Location = new System.Drawing.Point(10, 42);
			this.comments.Margin = new System.Windows.Forms.Padding(8);
			this.comments.Name = "comments";
			this.comments.Size = new System.Drawing.Size(623, 322);
			this.comments.TabIndex = 1;
			this.comments.Visible = false;
			this.comments.MessageClicked += new System.EventHandler<Scout.MessageListEventArgs>(this.comments_MessageClicked);
			this.comments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comments_MouseClick);
			// 
			// todoTab
			// 
			this.todoTab.BackColor = System.Drawing.Color.White;
			this.todoTab.Controls.Add(this.label5);
			this.todoTab.Controls.Add(this.linkLabel1);
			this.todoTab.Controls.Add(this.label1);
			this.todoTab.Controls.Add(this.addItem);
			this.todoTab.Controls.Add(this.toDoListControl1);
			this.todoTab.Controls.Add(this.todoList);
			this.todoTab.Location = new System.Drawing.Point(4, 44);
			this.todoTab.Name = "todoTab";
			this.todoTab.Padding = new System.Windows.Forms.Padding(3);
			this.todoTab.Size = new System.Drawing.Size(643, 451);
			this.todoTab.TabIndex = 1;
			this.todoTab.Text = "To-Do";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(526, 24);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(106, 20);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Create list...";
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 397);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Add an item";
			// 
			// addItem
			// 
			this.addItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.addItem.Location = new System.Drawing.Point(119, 376);
			this.addItem.Name = "addItem";
			this.addItem.Size = new System.Drawing.Size(513, 67);
			this.addItem.TabIndex = 2;
			this.addItem.Text = "";
			this.addItem.UseMouseForInput = true;
			this.addItem.Recognition += new Microsoft.Ink.InkEditRecognitionEventHandler(this.addItem_Recognition);
			// 
			// toDoListControl1
			// 
			this.toDoListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.toDoListControl1.AutoScroll = true;
			this.toDoListControl1.BackColor = System.Drawing.Color.White;
			this.toDoListControl1.Location = new System.Drawing.Point(8, 90);
			this.toDoListControl1.Margin = new System.Windows.Forms.Padding(0);
			this.toDoListControl1.Name = "toDoListControl1";
			this.toDoListControl1.Size = new System.Drawing.Size(624, 269);
			this.toDoListControl1.TabIndex = 3;
			// 
			// todoList
			// 
			this.todoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.todoList.FormattingEnabled = true;
			this.todoList.Location = new System.Drawing.Point(8, 16);
			this.todoList.Name = "todoList";
			this.todoList.Size = new System.Drawing.Size(471, 28);
			this.todoList.TabIndex = 0;
			// 
			// milestoneTab
			// 
			this.milestoneTab.BackColor = System.Drawing.Color.White;
			this.milestoneTab.Controls.Add(this.label2);
			this.milestoneTab.Controls.Add(this.addMilestone);
			this.milestoneTab.Controls.Add(this.listMilestones);
			this.milestoneTab.Location = new System.Drawing.Point(4, 44);
			this.milestoneTab.Name = "milestoneTab";
			this.milestoneTab.Padding = new System.Windows.Forms.Padding(3);
			this.milestoneTab.Size = new System.Drawing.Size(643, 451);
			this.milestoneTab.TabIndex = 2;
			this.milestoneTab.Text = "Milestones";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(8, 365);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 54);
			this.label2.TabIndex = 6;
			this.label2.Text = "Add a new milestone";
			// 
			// addMilestone
			// 
			this.addMilestone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.addMilestone.Location = new System.Drawing.Point(108, 350);
			this.addMilestone.Name = "addMilestone";
			this.addMilestone.Size = new System.Drawing.Size(513, 79);
			this.addMilestone.TabIndex = 5;
			this.addMilestone.Text = "";
			this.addMilestone.UseMouseForInput = true;
			this.addMilestone.Recognition += new Microsoft.Ink.InkEditRecognitionEventHandler(this.addMilestone_Recognition);
			// 
			// listMilestones
			// 
			this.listMilestones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listMilestones.CheckBoxes = true;
			this.listMilestones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.Due});
			this.listMilestones.FullRowSelect = true;
			listViewGroup1.Header = "Coming Up";
			listViewGroup1.Name = "groupComingUp";
			listViewGroup2.Header = "Past Due";
			listViewGroup2.Name = "groupPast";
			listViewGroup3.Header = "Completed";
			listViewGroup3.Name = "groupCompleted";
			this.listMilestones.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.listMilestones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listMilestones.Location = new System.Drawing.Point(8, 28);
			this.listMilestones.Name = "listMilestones";
			this.listMilestones.Size = new System.Drawing.Size(613, 304);
			this.listMilestones.TabIndex = 0;
			this.listMilestones.UseCompatibleStateImageBehavior = false;
			this.listMilestones.View = System.Windows.Forms.View.Details;
			this.listMilestones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listMilestones_MouseClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Milestone";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.logout);
			this.panel1.Controls.Add(this.settings);
			this.panel1.Controls.Add(this.projects);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(651, 77);
			this.panel1.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(13, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Project:";
			// 
			// logout
			// 
			this.logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.logout.AutoSize = true;
			this.logout.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logout.LinkColor = System.Drawing.Color.WhiteSmoke;
			this.logout.Location = new System.Drawing.Point(564, 28);
			this.logout.Name = "logout";
			this.logout.Size = new System.Drawing.Size(60, 16);
			this.logout.TabIndex = 1;
			this.logout.TabStop = true;
			this.logout.Text = "Log-out";
			this.logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_LinkClicked);
			// 
			// settings
			// 
			this.settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.settings.AutoSize = true;
			this.settings.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settings.LinkColor = System.Drawing.Color.WhiteSmoke;
			this.settings.Location = new System.Drawing.Point(489, 28);
			this.settings.Name = "settings";
			this.settings.Size = new System.Drawing.Size(59, 16);
			this.settings.TabIndex = 1;
			this.settings.TabStop = true;
			this.settings.Text = "Settings";
			this.settings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.settings_LinkClicked);
			// 
			// projects
			// 
			this.projects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.projects.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.projects.FormattingEnabled = true;
			this.projects.Location = new System.Drawing.Point(86, 21);
			this.projects.Name = "projects";
			this.projects.Size = new System.Drawing.Size(372, 28);
			this.projects.TabIndex = 0;
			this.projects.SelectedIndexChanged += new System.EventHandler(this.projects_SelectedIndexChanged);
			// 
			// menuMilestones
			// 
			this.menuMilestones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteThisMilesoneToolStripMenuItem});
			this.menuMilestones.Name = "menuMilestones";
			this.menuMilestones.Size = new System.Drawing.Size(181, 48);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.editToolStripMenuItem.Text = "Edit this milesone...";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// deleteThisMilesoneToolStripMenuItem
			// 
			this.deleteThisMilesoneToolStripMenuItem.Name = "deleteThisMilesoneToolStripMenuItem";
			this.deleteThisMilesoneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.deleteThisMilesoneToolStripMenuItem.Text = "&Delete this milesone";
			this.deleteThisMilesoneToolStripMenuItem.Click += new System.EventHandler(this.deleteThisMilesoneToolStripMenuItem_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.DimGray;
			this.label5.Location = new System.Drawing.Point(8, 61);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(421, 20);
			this.label5.TabIndex = 5;
			this.label5.Text = "Tap-and-hold an item to change who\'s responsible.";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(651, 576);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Scout";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabs.ResumeLayout(false);
			this.messageTab.ResumeLayout(false);
			this.messageTab.PerformLayout();
			this.todoTab.ResumeLayout(false);
			this.todoTab.PerformLayout();
			this.milestoneTab.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.menuMilestones.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage messageTab;
        private System.Windows.Forms.TabPage todoTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox projects;
        private System.Windows.Forms.TabPage milestoneTab;
		private System.Windows.Forms.ComboBox todoList;
        private System.Windows.Forms.Label label1;
		private Microsoft.Ink.InkEdit addItem;
		private ToDoListControl toDoListControl1;
		private System.Windows.Forms.ListView listMilestones;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader Due;
		private System.Windows.Forms.Label label2;
		private Microsoft.Ink.InkEdit addMilestone;
		private System.Windows.Forms.ContextMenuStrip menuMilestones;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteThisMilesoneToolStripMenuItem;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private MessageListControl messages;
		private MessageListControl comments;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel settings;
        private System.Windows.Forms.LinkLabel logout;
        private System.Windows.Forms.Label label;
        private Microsoft.Ink.InkEdit newMessage;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
    }
}

