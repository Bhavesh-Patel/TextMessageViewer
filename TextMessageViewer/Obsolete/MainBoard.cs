#pragma warning disable 1591

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace TextMessageViewer.Obsolete
{
	/// <summary>
	/// Summary description for MainBoard.
	/// </summary>
	public class MainBoard : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuBrowse;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.MenuItem mnuCloseAll;
		private System.Windows.Forms.MenuItem mnuClose;
		private System.Windows.Forms.MenuItem mnuNo2Names;

		private Hashtable contacts;
		private string contactDir;
		private System.Windows.Forms.MenuItem menuItem2;
		private MessageFormat currentFormat;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainBoard()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.lblPath = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuNo2Names = new System.Windows.Forms.MenuItem();
			this.mnuBrowse = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuClose = new System.Windows.Forms.MenuItem();
			this.mnuCloseAll = new System.Windows.Forms.MenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPath
			// 
			this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblPath.Location = new System.Drawing.Point(8, 8);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(456, 23);
			this.lblPath.TabIndex = 0;
			this.lblPath.Text = "Select a directory...";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(472, 8);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(16, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(520, 40);
			this.panel1.TabIndex = 2;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem1});
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuNo2Names,
																					  this.mnuBrowse,
																					  this.mnuExit});
			this.menuItem3.Text = "File";
			// 
			// mnuNo2Names
			// 
			this.mnuNo2Names.Index = 0;
			this.mnuNo2Names.Text = "Numbers -> Names";
			this.mnuNo2Names.Click += new System.EventHandler(this.mnuNo2Names_Click);
			// 
			// mnuBrowse
			// 
			this.mnuBrowse.Index = 1;
			this.mnuBrowse.Text = "&Browse";
			this.mnuBrowse.Click += new System.EventHandler(this.mnuBrowse_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MdiList = true;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.mnuClose,
																					  this.mnuCloseAll});
			this.menuItem1.Text = "Windows";
			// 
			// mnuClose
			// 
			this.mnuClose.Index = 1;
			this.mnuClose.Text = "Close";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// mnuCloseAll
			// 
			this.mnuCloseAll.Index = 2;
			this.mnuCloseAll.Text = "Close All Windows";
			this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lblPath);
			this.panel3.Controls.Add(this.btnBrowse);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(552, 88);
			this.panel3.TabIndex = 5;
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "-";
			// 
			// MainBoard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 393);
			this.Controls.Add(this.panel3);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainBoard";
			this.Text = "MainBoard";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainBoard_Load);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Features

		/// <summary>
		/// Offers the user a select foder dialog, and after the selection creates and adds a single button for each folder to the main panel.
		/// </summary>
		private void browse()
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (lblPath.Text != "")
				fbd.SelectedPath = lblPath.Text;
			DialogResult dr = fbd.ShowDialog();
			if (dr == DialogResult.OK && fbd.SelectedPath!=lblPath.Text)
			{
				ChangePhone(fbd.SelectedPath);	
			}
		}

		/// <summary>
		/// Closes all the windows within the multi document interface (MDI)
		/// </summary>
		private void closeAll()
		{
			foreach (Form frm in this.MdiChildren)
			{
				frm.Close();
			}
		}


		private void ChangePhone(string path)
		{
			string fileName;
			string[] folders;
			Button but;
			int x = 0;

			closeAll();

			ChooseFormat cf = new ChooseFormat();

			if (cf.ShowDialog(this) != DialogResult.Cancel)
			{
				currentFormat = cf.Format;
				lblPath.Text = path;
				folders = Directory.GetDirectories(path);
				Array.Sort(folders);
				panel1.Controls.Clear();
				foreach (string str in folders)
				{
					fileName = str.Substring(str.LastIndexOf("\\")+1);
					but = new Button();
					but.Text = fileName;
					but.Name = "btn"+fileName;
					but.Location = new Point(x,but.Location.Y);
					but.Tag = str;
					but.Click += new EventHandler(btn_Click);
					x+=75;
					panel1.Controls.Add(but);
				}
			}
		}

		#endregion

		#region Events

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			browse();
		}

		private void btn_Click(object sender, System.EventArgs e)
		{
			bool alreadyExists = false;
			string path = ((Button)sender).Tag.ToString();
			FolderBoard f=new FolderBoard();
			
			foreach (Form frm in this.MdiChildren)
			{
				if (frm.Text == path)
				{
					alreadyExists = true;
					f = (FolderBoard)frm;
				}
			}
			if (!alreadyExists)
			{
				f = new FolderBoard(path);
				f.Format = currentFormat;
				
			}
			f.MdiParent=this;
			f.Show();
			f.Focus();
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void mnuBrowse_Click(object sender, System.EventArgs e)
		{
			browse();
		}
		
		private void mnuCloseAll_Click(object sender, System.EventArgs e)
		{
			closeAll();
		}

		#endregion

		private void mnuClose_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild != null)
				this.ActiveMdiChild.Close();
		}

		private void mnuNo2Names_Click(object sender, System.EventArgs e)
		{
			string[] files;
			string name, nameFrom, nameTo,number, numberFrom, numberTo;
			FolderBoard frm;
			DialogResult dr = DialogResult.None;

			if (this.ActiveMdiChild != null)
			{
				frm = (FolderBoard)this.ActiveMdiChild;
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				if (/*contacts != null && */contactDir != null && contactDir != "")
				{
					fbd.SelectedPath = contactDir;
					if (MessageBox.Show("Use previous contact list?","Question",MessageBoxButtons.YesNo) ==	DialogResult.No)
					{
						dr = fbd.ShowDialog();
					}
				}
				else
				{
					dr = fbd.ShowDialog();
				}
				if (dr != DialogResult.Cancel)//dr == DialogResult.OK || dr == DialogResult.No)
				{
					contacts = new Hashtable();
					contactDir = fbd.SelectedPath;
					files = Directory.GetFiles(contactDir,"*.vcf");
					foreach (string str in files)
					{
						StreamReader sr = new StreamReader(str);
						sr.ReadLine();sr.ReadLine();
						name = sr.ReadLine().Substring(2);
						sr.ReadLine();
						do
						{
							number = sr.ReadLine();
							if (number.IndexOf(":0")!=-1)
								number = number.Substring(number.IndexOf(":0")+1);
							else if (number.IndexOf(":+")!=-1)
							{
								number = number.Substring(number.IndexOf(":+")+1);
								number = "0"+number.Substring(number.Length -10);
							}
							contacts[number] = name;
						}
						while (sr.Peek() == 'T');
					}
					ListView lstView = frm.listView;
					//Add names of contacts in a different column
					foreach (ListViewItem lvi in lstView.Items)
					{
						numberFrom = lvi.SubItems[0].Text;
						numberTo = lvi.SubItems[4].Text;
						if (!contacts.ContainsKey(numberFrom) && numberFrom.StartsWith("+"))
							numberFrom = "0"+numberFrom.Substring(numberFrom.Length - 10);
						if (!contacts.ContainsKey(numberTo) &&numberTo.StartsWith("+"))
							numberTo = "0"+numberTo.Substring(numberTo.Length -10);
						nameFrom = (string)contacts[numberFrom];
						nameTo = (string)contacts[numberTo];
						if (nameFrom!= null && nameFrom!="")
						{
							lvi.SubItems[0].Text = nameFrom+"("+numberFrom+")";
						}
						if (nameTo!= null && nameTo!="")
						{
							lvi.SubItems[4].Text = nameTo+"("+numberTo+")";
						}
					}
				}
//				else
//				{
//					MessageBox.Show("Operation Cancelled","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
//				}
			}
		}

		private void MainBoard_Load(object sender, System.EventArgs e)
		{
			string myDirectory = @"C:\Documents and Settings\Bhavesh Patel\My Documents\Nokia\Messages";
			contactDir =myDirectory+"\\Contacts";
			string[] phones = Directory.GetDirectories(myDirectory);
			foreach	(string str in phones)
			{
				if (!str.EndsWith("Contacts"))
				{
					menuItem1.MenuItems.Add(0,new MenuItem(str, new EventHandler(mnuChangePhone)));
				}
			}
		}

		private void mnuChangePhone(object sender, System.EventArgs e)
		{
			ChangePhone(((MenuItem)sender).Text);
		}
	}
}
