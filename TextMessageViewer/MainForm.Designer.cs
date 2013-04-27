namespace TextMessageViewer
{
	partial class MainForm
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
			if (disposing && (components != null)) {
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Phones");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuShowContacts = new System.Windows.Forms.MenuItem();
			this.mnuReadAccessDatabase = new System.Windows.Forms.MenuItem();
			this.mnuBackupAllToArchive = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.tvParents = new System.Windows.Forms.TreeView();
			this.ctxMTreeview = new System.Windows.Forms.ContextMenu();
			this.mnuCreateNew = new System.Windows.Forms.MenuItem();
			this.mnuAddExisting = new System.Windows.Forms.MenuItem();
			this.mnuBackupToArchiveTV = new System.Windows.Forms.MenuItem();
			this.mnuImportMessages = new System.Windows.Forms.MenuItem();
			this.ctxMListView = new System.Windows.Forms.ContextMenu();
			this.mnuListViewView = new System.Windows.Forms.MenuItem();
			this.mnuListViewEdit = new System.Windows.Forms.MenuItem();
			this.mnuBackupToArchiveLV = new System.Windows.Forms.MenuItem();
			this.colHFrom = new System.Windows.Forms.ColumnHeader();
			this.colHMessage = new System.Windows.Forms.ColumnHeader();
			this.colHDate = new System.Windows.Forms.ColumnHeader();
			this.colHTime = new System.Windows.Forms.ColumnHeader();
			this.colHTo = new System.Windows.Forms.ColumnHeader();
			this.colHFileName = new System.Windows.Forms.ColumnHeader();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRename = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.lblTime = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblFrom = new System.Windows.Forms.Label();
			this.lblTo = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
			this.tsBtnRename = new System.Windows.Forms.ToolStripButton();
			this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.lvChildren = new TextMessageViewer.TextMessageListView(this.components);
			this.mnuShowStats = new System.Windows.Forms.MenuItem();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuShowContacts,
            this.mnuReadAccessDatabase,
            this.mnuBackupAllToArchive,
            this.mnuExit});
			this.mnuFile.Text = "File";
			// 
			// mnuShowContacts
			// 
			this.mnuShowContacts.Index = 0;
			this.mnuShowContacts.Text = "Show Contacts";
			this.mnuShowContacts.Click += new System.EventHandler(this.mnuShowContacts_Click);
			// 
			// mnuReadAccessDatabase
			// 
			this.mnuReadAccessDatabase.Index = 1;
			this.mnuReadAccessDatabase.Text = "Read Access Database";
			this.mnuReadAccessDatabase.Click += new System.EventHandler(this.mnuReadAccessDatabase_Click);
			// 
			// mnuBackupAllToArchive
			// 
			this.mnuBackupAllToArchive.Index = 2;
			this.mnuBackupAllToArchive.Text = "&Backup All to Archive";
			this.mnuBackupAllToArchive.Click += new System.EventHandler(this.mnuBackupAllToArchive_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 3;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// tvParents
			// 
			this.tvParents.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.tvParents.ContextMenu = this.ctxMTreeview;
			this.tvParents.HideSelection = false;
			this.tvParents.Location = new System.Drawing.Point(8, 8);
			this.tvParents.Name = "tvParents";
			treeNode1.Name = "";
			treeNode1.Text = "Phones";
			this.tvParents.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
			this.tvParents.Size = new System.Drawing.Size(136, 408);
			this.tvParents.TabIndex = 0;
			this.tvParents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvParents_AfterSelect);
			// 
			// ctxMTreeview
			// 
			this.ctxMTreeview.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCreateNew,
            this.mnuAddExisting,
            this.mnuBackupToArchiveTV,
            this.mnuImportMessages,
            this.mnuShowStats});
			this.ctxMTreeview.Popup += new System.EventHandler(this.ctxMTreeview_Popup);
			// 
			// mnuCreateNew
			// 
			this.mnuCreateNew.Index = 0;
			this.mnuCreateNew.Text = "Create New";
			this.mnuCreateNew.Click += new System.EventHandler(this.mnuCreateNew_Click);
			// 
			// mnuAddExisting
			// 
			this.mnuAddExisting.Index = 1;
			this.mnuAddExisting.Text = "&Add Existing";
			this.mnuAddExisting.Click += new System.EventHandler(this.mnuAddExisting_Click);
			// 
			// mnuBackupToArchiveTV
			// 
			this.mnuBackupToArchiveTV.Index = 2;
			this.mnuBackupToArchiveTV.Text = "&Backup to Archive";
			this.mnuBackupToArchiveTV.Click += new System.EventHandler(this.mnuBackupToArchiveTV_Click);
			// 
			// mnuImportMessages
			// 
			this.mnuImportMessages.Index = 3;
			this.mnuImportMessages.Text = "&Import Messages...";
			this.mnuImportMessages.Click += new System.EventHandler(this.mnuImportMessages_Click);
			// 
			// ctxMListView
			// 
			this.ctxMListView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuListViewView,
            this.mnuListViewEdit,
            this.mnuBackupToArchiveLV});
			// 
			// mnuListViewView
			// 
			this.mnuListViewView.Index = 0;
			this.mnuListViewView.Text = "&View";
			this.mnuListViewView.Click += new System.EventHandler(this.mnuListViewView_Click);
			// 
			// mnuListViewEdit
			// 
			this.mnuListViewEdit.Index = 1;
			this.mnuListViewEdit.Text = "&Edit";
			this.mnuListViewEdit.Click += new System.EventHandler(this.mnuListViewEdit_Click);
			// 
			// mnuBackupToArchiveLV
			// 
			this.mnuBackupToArchiveLV.Index = 2;
			this.mnuBackupToArchiveLV.Text = "&Backup to Archive";
			this.mnuBackupToArchiveLV.Click += new System.EventHandler(this.mnuBackupToArchiveLV_Click);
			// 
			// colHFrom
			// 
			this.colHFrom.Text = "From";
			this.colHFrom.Width = 100;
			// 
			// colHMessage
			// 
			this.colHMessage.Text = "Message";
			this.colHMessage.Width = 250;
			// 
			// colHDate
			// 
			this.colHDate.Text = "Date";
			this.colHDate.Width = 75;
			// 
			// colHTime
			// 
			this.colHTime.Text = "Time";
			// 
			// colHTo
			// 
			this.colHTo.Text = "To";
			this.colHTo.Width = 100;
			// 
			// colHFileName
			// 
			this.colHFileName.Text = "FileName";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(552, 392);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 30;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(552, 360);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 29;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Enabled = false;
			this.btnAdd.Location = new System.Drawing.Point(552, 328);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 28;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRename
			// 
			this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRename.Location = new System.Drawing.Point(552, 296);
			this.btnRename.Name = "btnRename";
			this.btnRename.Size = new System.Drawing.Size(75, 23);
			this.btnRename.TabIndex = 27;
			this.btnRename.Text = "Rename...";
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(360, 296);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ReadOnly = true;
			this.txtMessage.Size = new System.Drawing.Size(184, 120);
			this.txtMessage.TabIndex = 26;
			// 
			// lblTime
			// 
			this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTime.Location = new System.Drawing.Point(200, 392);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(152, 23);
			this.lblTime.TabIndex = 25;
			// 
			// lblDate
			// 
			this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDate.Location = new System.Drawing.Point(200, 360);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(152, 23);
			this.lblDate.TabIndex = 24;
			// 
			// lblFrom
			// 
			this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblFrom.Location = new System.Drawing.Point(200, 296);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(152, 23);
			this.lblFrom.TabIndex = 23;
			// 
			// lblTo
			// 
			this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTo.Location = new System.Drawing.Point(200, 328);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(152, 23);
			this.lblTo.TabIndex = 22;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.Location = new System.Drawing.Point(152, 392);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 21;
			this.label4.Text = "Time:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Location = new System.Drawing.Point(152, 360);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 20;
			this.label3.Text = "Date:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(152, 296);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 19;
			this.label2.Text = "From:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(152, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 18;
			this.label1.Text = "To:";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 424);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(632, 22);
			this.statusBar.TabIndex = 31;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(184, 212);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(264, 23);
			this.progressBar.TabIndex = 32;
			this.progressBar.Visible = false;
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnEdit,
            this.tsBtnRename,
            this.tsBtnRefresh});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(632, 25);
			this.toolStrip.TabIndex = 33;
			this.toolStrip.Visible = false;
			// 
			// tsBtnAdd
			// 
			this.tsBtnAdd.Image = ((System.Drawing.Image) (resources.GetObject("tsBtnAdd.Image")));
			this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnAdd.Name = "tsBtnAdd";
			this.tsBtnAdd.Size = new System.Drawing.Size(46, 22);
			this.tsBtnAdd.Text = "Add";
			this.tsBtnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// tsBtnEdit
			// 
			this.tsBtnEdit.Image = ((System.Drawing.Image) (resources.GetObject("tsBtnEdit.Image")));
			this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnEdit.Name = "tsBtnEdit";
			this.tsBtnEdit.Size = new System.Drawing.Size(45, 22);
			this.tsBtnEdit.Text = "Edit";
			this.tsBtnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// tsBtnRename
			// 
			this.tsBtnRename.Image = ((System.Drawing.Image) (resources.GetObject("tsBtnRename.Image")));
			this.tsBtnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnRename.Name = "tsBtnRename";
			this.tsBtnRename.Size = new System.Drawing.Size(78, 22);
			this.tsBtnRename.Text = "Rename...";
			this.tsBtnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// tsBtnRefresh
			// 
			this.tsBtnRefresh.Image = ((System.Drawing.Image) (resources.GetObject("tsBtnRefresh.Image")));
			this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnRefresh.Name = "tsBtnRefresh";
			this.tsBtnRefresh.Size = new System.Drawing.Size(65, 22);
			this.tsBtnRefresh.Text = "Refresh";
			this.tsBtnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// lvChildren
			// 
			this.lvChildren.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvChildren.ContextMenu = this.ctxMListView;
			this.lvChildren.FullRowSelect = true;
			this.lvChildren.HideSelection = false;
			this.lvChildren.Location = new System.Drawing.Point(152, 8);
			this.lvChildren.MultiSelect = false;
			this.lvChildren.Name = "lvChildren";
			this.lvChildren.Size = new System.Drawing.Size(480, 280);
			this.lvChildren.TabIndex = 14;
			this.lvChildren.UseCompatibleStateImageBehavior = false;
			this.lvChildren.View = System.Windows.Forms.View.Details;
			this.lvChildren.AfterTextMessageItemUpdate += new System.EventHandler<TextMessageViewer.AfterTextMessageItemUpdateEventArgs>(this.lvChildren_AfterTextMessageItemUpdate);
			this.lvChildren.SelectedIndexChanged += new System.EventHandler(this.lvChildren_SelectedIndexChanged);
			// 
			// mnuShowStats
			// 
			this.mnuShowStats.Index = 4;
			this.mnuShowStats.Text = "Show Stats";
			this.mnuShowStats.Click += new System.EventHandler(this.mnuShowStats_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnRename);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.lblTime);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblFrom);
			this.Controls.Add(this.lblTo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lvChildren);
			this.Controls.Add(this.tvParents);
			this.Menu = this.mainMenu;
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MainBoard";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainBoard_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.TreeView tvParents;
		private TextMessageListView lvChildren;
		private System.Windows.Forms.ColumnHeader colHFrom;
		private System.Windows.Forms.ColumnHeader colHMessage;
		private System.Windows.Forms.ColumnHeader colHDate;
		private System.Windows.Forms.ColumnHeader colHTime;
		private System.Windows.Forms.ColumnHeader colHTo;
		private System.Windows.Forms.ColumnHeader colHFileName;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRename;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.ContextMenu ctxMTreeview;
		private System.Windows.Forms.MenuItem mnuShowContacts;
		private System.Windows.Forms.MenuItem mnuReadAccessDatabase;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ContextMenu ctxMListView;
		private System.Windows.Forms.MenuItem mnuListViewView;
		private System.Windows.Forms.MenuItem mnuListViewEdit;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton tsBtnAdd;
		private System.Windows.Forms.ToolStripButton tsBtnEdit;
		private System.Windows.Forms.ToolStripButton tsBtnRename;
		private System.Windows.Forms.ToolStripButton tsBtnRefresh;
		private System.Windows.Forms.MenuItem mnuBackupAllToArchive;
		private System.Windows.Forms.MenuItem mnuBackupToArchiveTV;
		private System.Windows.Forms.MenuItem mnuBackupToArchiveLV;
		private System.Windows.Forms.MenuItem mnuCreateNew;
		private System.Windows.Forms.MenuItem mnuAddExisting;
		private System.Windows.Forms.MenuItem mnuImportMessages;
		private System.Windows.Forms.MenuItem mnuShowStats;
	}
}