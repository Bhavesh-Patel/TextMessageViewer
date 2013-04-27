#pragma warning disable 1591

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace TextMessageViewer.Obsolete
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
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
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}
		public Form1(string path):base()
		{

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
			this.treeView1 = new System.Windows.Forms.TreeView();
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
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(16, 40);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.ShowLines = false;
			this.treeView1.Size = new System.Drawing.Size(152, 424);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
			this.lblPath.Location = new System.Drawing.Point(48, 8);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(528, 23);
			this.lblPath.TabIndex = 2;
			this.lblPath.Text = "<None>";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(584, 8);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(192, 88);
			this.label1.Name = "label1";
			this.label1.TabIndex = 4;
			this.label1.Text = "To:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(192, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 5;
			this.label2.Text = "From:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(192, 128);
			this.label3.Name = "label3";
			this.label3.TabIndex = 6;
			this.label3.Text = "Date:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(424, 128);
			this.label4.Name = "label4";
			this.label4.TabIndex = 7;
			this.label4.Text = "Time:";
			// 
			// lblTo
			// 
			this.lblTo.Location = new System.Drawing.Point(312, 88);
			this.lblTo.Name = "lblTo";
			this.lblTo.TabIndex = 8;
			// 
			// lblFrom
			// 
			this.lblFrom.Location = new System.Drawing.Point(312, 48);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.TabIndex = 9;
			// 
			// lblDate
			// 
			this.lblDate.Location = new System.Drawing.Point(312, 128);
			this.lblDate.Name = "lblDate";
			this.lblDate.TabIndex = 10;
			// 
			// lblTime
			// 
			this.lblTime.Location = new System.Drawing.Point(536, 128);
			this.lblTime.Name = "lblTime";
			this.lblTime.TabIndex = 11;
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(192, 176);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(456, 288);
			this.txtMessage.TabIndex = 12;
			this.txtMessage.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 478);
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
			this.Controls.Add(this.treeView1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nokia SMS Viewer";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			string path;
			string[] files;

			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult dr = fbd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				//path = @"C:\Documents and Settings\Bhavesh Patel\My Documents\Nokia\Messages\7600\Inbox";
				path = fbd.SelectedPath;
				lblPath.Text = path;
				files = Directory.GetFiles(path,"*.vmg");
				treeView1.Nodes.Clear();
				foreach (string str in files)
				{
					treeView1.Nodes.Add(str.Substring(str.LastIndexOf("\\")+1));
				}
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string path = lblPath.Text + "\\"+ e.Node.Text;
			StreamReader sr = new StreamReader(path);

			for (int i=0;i<7;i++)
				sr.ReadLine();

			string fromNum = sr.ReadLine().Replace("\0","");
			lblFrom.Text = fromNum.Substring(4);
			
			for (int i=0;i<5;i++)
				sr.ReadLine();
			string toNum = sr.ReadLine().Replace("\0","");
			lblTo.Text = toNum.Substring(4);

			for (int i=0;i<3;i++)
				sr.ReadLine();

			//Date line = 17
			string dateTime = sr.ReadLine().Replace("\0","");
			lblDate.Text = dateTime.Substring(5,10);
			lblTime.Text = dateTime.Substring(16,8);
			
			//Message line = 18
			string message = sr.ReadLine().Replace("\0","");
			txtMessage.Text = message;
		}
	}
}
