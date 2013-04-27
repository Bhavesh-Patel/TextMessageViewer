namespace TextMessageViewer
{
	partial class ImportMessagesForm
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
			System.Windows.Forms.Label lblFormat;
			this.folderSelector = new Bhavesh.WindowsControlLibrary.FolderSelector();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblMessageFormat = new System.Windows.Forms.Label();
			this.btnClear = new System.Windows.Forms.Button();
			this.textMessageListView = new TextMessageViewer.TextMessageListView(this.components);
			lblFormat = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblFormat
			// 
			lblFormat.AutoSize = true;
			lblFormat.Location = new System.Drawing.Point(12, 16);
			lblFormat.Name = "lblFormat";
			lblFormat.Size = new System.Drawing.Size(88, 13);
			lblFormat.TabIndex = 0;
			lblFormat.Text = "Message Format:";
			// 
			// folderSelector
			// 
			this.folderSelector.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.folderSelector.LabelText = "Folder Path:";
			this.folderSelector.Location = new System.Drawing.Point(243, 11);
			this.folderSelector.Name = "folderSelector";
			this.folderSelector.SelectionName = "";
			this.folderSelector.Size = new System.Drawing.Size(454, 24);
			this.folderSelector.TabIndex = 2;
			this.folderSelector.SelectionChanged += new System.EventHandler<System.EventArgs>(this.folderSelector_SelectionChanged);
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnImport.Location = new System.Drawing.Point(541, 242);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "&Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(622, 242);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// lblMessageFormat
			// 
			this.lblMessageFormat.AutoSize = true;
			this.lblMessageFormat.Location = new System.Drawing.Point(106, 16);
			this.lblMessageFormat.Name = "lblMessageFormat";
			this.lblMessageFormat.Size = new System.Drawing.Size(94, 13);
			this.lblMessageFormat.TabIndex = 1;
			this.lblMessageFormat.Text = "<MessageFormat>";
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.Location = new System.Drawing.Point(12, 242);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "&Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// textMessageListView
			// 
			this.textMessageListView.AllowDrop = true;
			this.textMessageListView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textMessageListView.CheckBoxes = true;
			this.textMessageListView.FullRowSelect = true;
			this.textMessageListView.HideSelection = false;
			this.textMessageListView.Location = new System.Drawing.Point(12, 41);
			this.textMessageListView.MultiSelect = true;
			this.textMessageListView.Name = "textMessageListView";
			this.textMessageListView.Size = new System.Drawing.Size(685, 195);
			this.textMessageListView.TabIndex = 3;
			this.textMessageListView.UseCompatibleStateImageBehavior = false;
			this.textMessageListView.View = System.Windows.Forms.View.Details;
			this.textMessageListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvChildren_DragDrop);
			this.textMessageListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvChildren_DragEnter);
			// 
			// ImportMessagesForm
			// 
			this.AcceptButton = this.btnImport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(709, 277);
			this.Controls.Add(this.textMessageListView);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblMessageFormat);
			this.Controls.Add(lblFormat);
			this.Controls.Add(this.folderSelector);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnImport);
			this.Name = "ImportMessagesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ImportMessagesForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Bhavesh.WindowsControlLibrary.FolderSelector folderSelector;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblMessageFormat;
		private System.Windows.Forms.Button btnClear;
		private TextMessageListView textMessageListView;
	}
}