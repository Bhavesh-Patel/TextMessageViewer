using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using Bhavesh.Utilities;

namespace TextMessageViewer
{
	/// <summary>Displays messages from an Access database.</summary>
	public class AccessDatabaseMessages : System.Windows.Forms.Form
	{
		/// <summary>Required designer variable.</summary>
		private System.ComponentModel.Container components = null;

		/// <summary>Initializes a new instance of the <see cref="AccessDatabaseMessages"/> class.</summary>
		/// <param name="filePath">The file path.</param>
		public AccessDatabaseMessages(string filePath)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			lvwColumnSorter = new ListViewColumnSorter();
			listView1.ListViewItemSorter = lvwColumnSorter;

			//create the database connection
			OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+filePath);//C:\Documents and Settings\Bhavesh Patel\Nokia\MPDB\SmsDB.mdb

			//create the command object and store the sql query
			OleDbCommand command = new OleDbCommand(
				"select FOLDERS.Name, SMS.SenderNumber, SMS.ReceiverNumber, SMS.MessageData, SMS.SCTimeStamp from FOLDERS, SMS "
				+ "WHERE FOLDERS.FolderKey = SMS.FolderKey "
				+ "ORDER BY FOLDERS.Name ASC, SMS.SCTimeStamp ASC, SMS.MessageID DESC"
				, connection);
			try 
			{
				connection.Open();

				//create the datareader object to connect to table
				OleDbDataReader reader = command.ExecuteReader();
				ListViewItem item;
				//iterate through the dataset
				while (reader.Read()) 
				{
					item = new ListViewItem(reader.GetString(0)); // Folder Location
					item.SubItems.Add(reader.GetString(1));// sender
					string message = reader.GetString(3);
					item.SubItems.Add(message);// message
					DateTime dt = DateTime.Parse(reader.GetDateTime(4).ToString());
					//concatenate linked messages - doesn't work yet, be smarter!
//					if (listView1.Items.Count>0 && DateTime.Parse(listView1.Items[listView1.Items.Count-1].SubItems[3].Text+" " +listView1.Items[listView1.Items.Count-1].SubItems[4].Text)==dt)
//					{
//						item = listView1.Items[listView1.Items.Count -1];
//						item.SubItems[2].Text = message + item.SubItems[2].Text;
//					}
//					else
//					{
						item.SubItems.Add(dt.Date.ToShortDateString());//date
						item.SubItems.Add(dt.TimeOfDay.ToString());// time
						item.SubItems.Add(reader.GetString(2));// reciever
						listView1.Items.Add(item);
//					}
				}

				//close reader
				reader.Close();

			}
			catch (OleDbException ex) 
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader5,
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader6});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.ForeColor = System.Drawing.Color.Black;
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(621, 373);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Location";
			this.columnHeader5.Width = 99;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "From";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Message";
			this.columnHeader2.Width = 307;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Date";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Time";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "To";
			// 
			// AccessDatabaseMessages
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(621, 373);
			this.Controls.Add(this.listView1);
			this.Name = "AccessDatabaseMessages";
			this.Text = "AccessDatabaseMessages";
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private ListViewColumnSorter lvwColumnSorter;

		private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			ListViewColumnSorter.SortListView(listView1, e.Column);
		}
	}
}
