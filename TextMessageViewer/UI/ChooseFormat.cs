#pragma warning disable 1591

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Bhavesh.Utilities;

namespace TextMessageViewer
{
	/// <summary>
	/// Summary description for ChooseFormat.
	/// </summary>
	public class ChooseFormat : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ComboBox cbxFormat;

		public MessageFormat Format
		{
			get { return (MessageFormat) ((ComboBoxEnumItem) cbxFormat.SelectedItem).Enumerator; }
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ChooseFormat()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			cbxFormat.DataSource = ComboBoxEnumItem.GetAllItems<MessageFormat>();
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.cbxFormat = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(173, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(88, 48);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// cbxFormat
			// 
			this.cbxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFormat.Location = new System.Drawing.Point(16, 16);
			this.cbxFormat.Name = "cbxFormat";
			this.cbxFormat.Size = new System.Drawing.Size(232, 21);
			this.cbxFormat.Sorted = true;
			this.cbxFormat.TabIndex = 0;
			// 
			// ChooseFormat
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(266, 80);
			this.Controls.Add(this.cbxFormat);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChooseFormat";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose Format";
			this.Load += new System.EventHandler(this.ChooseFormat_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ChooseFormat_Load(object sender, System.EventArgs e)
		{
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult .OK;
		}
	}
}
