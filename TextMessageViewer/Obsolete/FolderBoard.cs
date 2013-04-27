#pragma warning disable 1591

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Bhavesh.Utilities;

namespace TextMessageViewer.Obsolete
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FolderBoard : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblInbox;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader colHFrom;
		private System.Windows.Forms.ColumnHeader colHMessage;
		private System.Windows.Forms.ColumnHeader colHDate;
		private System.Windows.Forms.ColumnHeader colHTime;
		private System.Windows.Forms.ColumnHeader colHTo;
		private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
		private System.Windows.Forms.ColumnHeader colHFileName;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;

		private MessageFormat format;
		private Hashtable formatFileType;
		private Hashtable formatFilePrefix;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnRename;
		private string filePath;

		public ListView listView
		{
			get{return listView1;}
		}


		public MessageFormat Format
		{
			set{format = value;}
		}

		public FolderBoard()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			/*
			 * These lines are written into the InitializeComponent method, but somehow are removed
				// Create an instance of a ListView column sorter and assign it
				// to the ListView control.
				lvwColumnSorter = new ListViewColumnSorter();
				this.listView1.ListViewItemSorter = lvwColumnSorter;
			*/
			this.listView1.ListViewItemSorter = lvwColumnSorter;
			formatFileType = new Hashtable();
			formatFileType[MessageFormat.Motorola] = "txt";
			formatFileType[MessageFormat.Nokia] = "vmg";
			formatFilePrefix = new Hashtable();
			formatFilePrefix[MessageFormat.Motorola] = "recu";
			formatFilePrefix[MessageFormat.Nokia] = "";
		}
		public FolderBoard(string path):this()
		{
			filePath = path;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.lblInbox = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblTo = new System.Windows.Forms.Label();
			this.lblFrom = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.colHFrom = new System.Windows.Forms.ColumnHeader();
			this.colHMessage = new System.Windows.Forms.ColumnHeader();
			this.colHDate = new System.Windows.Forms.ColumnHeader();
			this.colHTime = new System.Windows.Forms.ColumnHeader();
			this.colHTo = new System.Windows.Forms.ColumnHeader();
			this.colHFileName = new System.Windows.Forms.ColumnHeader();
			this.btnRename = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblInbox
			// 
			this.lblInbox.Location = new System.Drawing.Point(8, 8);
			this.lblInbox.Name = "lblInbox";
			this.lblInbox.Size = new System.Drawing.Size(40, 16);
			this.lblInbox.TabIndex = 1;
			this.lblInbox.Text = "Inbox:";
			// 
			// lblPath
			// 
			this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblPath.Location = new System.Drawing.Point(48, 8);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(528, 23);
			this.lblPath.TabIndex = 2;
			this.lblPath.Text = "<None>";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(584, 8);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(376, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "To:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(376, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "From:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(376, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Date:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(376, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Time:";
			// 
			// lblTo
			// 
			this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTo.Location = new System.Drawing.Point(424, 88);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(152, 23);
			this.lblTo.TabIndex = 8;
			// 
			// lblFrom
			// 
			this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFrom.Location = new System.Drawing.Point(424, 48);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(152, 23);
			this.lblFrom.TabIndex = 9;
			// 
			// lblDate
			// 
			this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDate.Location = new System.Drawing.Point(424, 128);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(152, 23);
			this.lblDate.TabIndex = 10;
			// 
			// lblTime
			// 
			this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTime.Location = new System.Drawing.Point(424, 168);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(152, 23);
			this.lblTime.TabIndex = 11;
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(368, 200);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ReadOnly = true;
			this.txtMessage.Size = new System.Drawing.Size(280, 264);
			this.txtMessage.TabIndex = 12;
			this.txtMessage.Text = "";
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colHFrom,
																						this.colHMessage,
																						this.colHDate,
																						this.colHTime,
																						this.colHTo,
																						this.colHFileName});
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(8, 32);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(344, 432);
			this.listView1.TabIndex = 13;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
			// btnRename
			// 
			this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRename.Location = new System.Drawing.Point(584, 40);
			this.btnRename.Name = "btnRename";
			this.btnRename.TabIndex = 14;
			this.btnRename.Text = "Rename";
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(584, 72);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 15;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(584, 104);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.TabIndex = 16;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(584, 136);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.TabIndex = 17;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// FolderBoard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 478);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnRename);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.lblTime);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblFrom);
			this.Controls.Add(this.lblTo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.lblInbox);
			this.Name = "FolderBoard";
			this.Text = "Nokia SMS Viewer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FolderBoard_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			string path;

			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (lblPath.Text != "")
				fbd.SelectedPath = lblPath.Text;
			DialogResult dr = fbd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				//path = @"C:\Documents and Settings\Bhavesh Patel\My Documents\Nokia\Messages\7600\Inbox";
				path = fbd.SelectedPath;
				addListViewItems(path);
			}
		}

		private void addListViewItems(string path)
		{
			string[] files;

			lblPath.Text = path;
			files = Directory.GetFiles(path,"*."+formatFileType[format]);
			listView1.Items.Clear();
			foreach (string str in files)
			{
				listView1.Items.Add(createListViewItem(str, format));
			}
			lblPath.Text += "("+files.Length+" messages)";
		}

		private ListViewItem createListViewItem(string filePath, MessageFormat format)
		{
			ListViewItem result;
			switch (format)
			{
				case MessageFormat.Nokia:
				{
					result= createNokiaListViewItem(filePath);
					break;
				}
				case MessageFormat.Motorola:
				{
					result= createMotorolaListViewItem(filePath);
					break;
				}
				default:
					result= new ListViewItem();
					break;
			}
			return result;
		}

		private ListViewItem createNokiaListViewItem(string filePath)
		{
			ListViewItem lvi;
			string[] items;// = new string[5];
			//string path = lblPath.Text + "\\"+ e.Node.Text;
			StreamReader sr = new StreamReader(filePath);

			for (int i=0;i<7;i++)
				sr.ReadLine();

			//From number line = 7
			string fromNum = sr.ReadLine().Replace("\0","");
			//lblFrom.Text = fromNum.Substring(4);
			
			for (int i=0;i<5;i++)
				sr.ReadLine();

			//To number line = 13
			string toNum = sr.ReadLine().Replace("\0","");
			//lblTo.Text = toNum.Substring(4);

			for (int i=0;i<3;i++)
				sr.ReadLine();

			//Date line = 17
			string dateTime = sr.ReadLine().Replace("\0","");
			//lblDate.Text = dateTime.Substring(5,10);
			//lblTime.Text = dateTime.Substring(16,8);
			
			//Message line = 18
			string message= sr.ReadLine().Replace("\0", "");
			string tmp = sr.ReadLine().Replace("\0", "");
			while (tmp != null && ! tmp.StartsWith("END"))//checking for multi line messages
			{
				message += "\r\n"+tmp.Replace("\0", "");
				tmp = sr.ReadLine();
			}
			//txtMessage.Text = message

			sr.Close();

			items = new string[6]{fromNum.Substring(4),message,dateTime.Substring(5,10),dateTime.Substring(16,8),toNum.Substring(4),filePath.Substring(filePath.LastIndexOf("\\")+1)};

			lvi = new ListViewItem(items);
			return lvi;
		}


		private ListViewItem createMotorolaListViewItem(string filePath)
		{
			ListViewItem lvi;
			string[] items;// = new string[5];
			//string path = lblPath.Text + "\\"+ e.Node.Text;
			StreamReader sr = new StreamReader(filePath);

			//From/To number line = 1
			string contact = sr.ReadLine().Replace("\0","");
			//lblFrom.Text = fromNum.Substring(4);
			
			//date line = 2
			string dateTime = sr.ReadLine().Replace("\0","");
			string[] dateItems = dateTime.Substring(6).Split(new char[]{'/'});
			try 
			{
				DateTime.Parse(dateTime.Substring(6));
			}
			catch(FormatException)
			{
				dateTime = "Date: " + dateItems[1] + "/" + dateItems[0] + "/" + dateItems[2];
			}
			//lblDate.Text = dateTime.Substring(5,11);
			//lblTime.Text = dateTime.Substring(16,6);
			
			sr.ReadLine();

			//Message line = 4
			string message= sr.ReadLine().Replace("\0", "");

			sr.Close();

			items = new string[6]{contact.Substring(9),message,dateTime.Substring(5,11),dateTime.Substring(16,6),"",filePath.Substring(filePath.LastIndexOf("\\")+1)};
			lvi = new ListViewItem(items);
			return lvi;
		}//sonal_makhani


		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count >0)
			{
				ListViewItem items = listView1.SelectedItems[0];
				lblFrom.Text = items.SubItems[0].Text;
				txtMessage.Text = items.SubItems[1].Text;
				lblDate.Text = items.SubItems[2].Text;
				lblTime.Text = items.SubItems[3].Text;
				lblTo.Text = items.SubItems[4].Text;
				btnEdit.Enabled = true;
			}
			else
			{
				btnEdit.Enabled = false;
			}
		}

		private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvwColumnSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			this.listView1.Sort();

		}

		private void btnRename_Click(object sender, System.EventArgs e)
		{
			int n = 0;
			string subfolder = "Renamed\\",filename,path = this.Text+"\\", fileNumber;
			bool doIt = true;

			if (Directory.Exists(path+subfolder))
			{
				doIt = false;
				DialogResult dr = MessageBox.Show("Overwrite existing directory and files","Warning",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
				if (dr == DialogResult.OK)
				{
					doIt = true;
					Directory.Delete(path+subfolder,true);
				}
				else
				{
					MessageBox.Show("Operation Aborted");
				}
			}
			if (doIt)
			{
				Directory.CreateDirectory(path+subfolder);
				foreach (ListViewItem lvi in listView1.Items)
				{
					filename = lvi.SubItems[5].Text;
					fileNumber = n.ToString();
					if (format == MessageFormat.Motorola)
					{
						fileNumber = fileNumber.PadLeft(4,'0');
					}
					File.Copy(path+filename,path+subfolder+formatFilePrefix[format]+fileNumber+"." + formatFileType[format]);
					n++;
				}
			}
			//File.Move(txtPath.Text+txtOrigFileName.Text,txtPath.Text+txtNewFileName.Text);
			//File.Delete(txtPath.Text+txtOrigFileName.Text);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string fileNumber = listView1.Items.Count.ToString();
			if (format == MessageFormat.Motorola)
			{
				fileNumber = fileNumber.PadLeft(4, '0');
			}
			string nextFile = formatFilePrefix[format] + fileNumber +"." + formatFileType[format];
			fileNumber += "\\" + nextFile;
			NewEditMessage f3 = new NewEditMessage(filePath, format);
			if (f3.ShowDialog(this) != DialogResult.Cancel)
			{
				ListViewItem lvi = createListViewItem(filePath+"\\"+nextFile, format);
				listView1.Items.Add(lvi);
				listView.Sort();
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			ListViewItem lvi = listView1.SelectedItems[0];
			TextMessage message = (TextMessage) lvi.Tag;
			NewEditMessage f3 = new NewEditMessage(message);
			if (f3.ShowDialog(this) != DialogResult.Cancel)
			{
				ListViewItem lvi2 = createListViewItem(filePath+"\\"+lvi.SubItems[5].Text, format);
				listView1.Items.Insert(lvi.Index, lvi2);
				lvi.Remove();
				listView.Sort();
			}
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			btnRefresh.Text = "Refreshing...";
			btnRefresh.Enabled = false;

			listView1.BeginUpdate();
			listView1.Items.Clear();
			addListViewItems(filePath);
			listView1.EndUpdate();

			btnRefresh.Text = "Refresh";
			btnRefresh.Enabled = true;
		}

		private void FolderBoard_Load(object sender, System.EventArgs e)
		{
			addListViewItems(filePath);
			ListViewColumnSorter.SortListView(listView1, 2);
			this.Text = filePath;
			btnBrowse.Visible = false;
			lblPath.Visible = false;
			lblInbox.Visible = false;
		}
	}
}
