using Bhavesh.Utilities;
namespace TextMessageViewer
{
	partial class TextMessageListView
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.colHFrom = new System.Windows.Forms.ColumnHeader();
			this.colHMessage = new System.Windows.Forms.ColumnHeader();
			this.colHDate = new System.Windows.Forms.ColumnHeader();
			this.colHTime = new System.Windows.Forms.ColumnHeader();
			this.colHTo = new System.Windows.Forms.ColumnHeader();
			this.colHFileName = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
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
			// TextMessageListView
			// 
			this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHFrom,
            this.colHMessage,
            this.colHDate,
            this.colHTime,
            this.colHTo,
            this.colHFileName});
			this.FullRowSelect = true;
			this.HideSelection = false;
			this.MultiSelect = false;
			this.View = System.Windows.Forms.View.Details;
			this.ItemActivate += new System.EventHandler(this.TextMessageListView_ItemActivate);
			this.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TextMessageListView_ColumnClick);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ColumnHeader colHFrom;
		private System.Windows.Forms.ColumnHeader colHMessage;
		private System.Windows.Forms.ColumnHeader colHDate;
		private System.Windows.Forms.ColumnHeader colHTime;
		private System.Windows.Forms.ColumnHeader colHTo;
		private System.Windows.Forms.ColumnHeader colHFileName;
	}
}
