using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextMessageViewer
{
	/// <summary>Allows editing of existing or creating of new TextMessage.</summary>
	public partial class NewEditMessage : Form
	{
		#region Fields
		/// <summary>The Format of the message being edited or created.</summary>
		private MessageFormat format;

		/// <summary>The message being editted - if any!</summary>
		private TextMessage message;

		/// <summary>The location of file representing this message.</summary>
		private string filePath;
		#endregion

		#region Public Properties
		/// <summary>Gets the message.</summary>
		public TextMessage Message
		{
			get { return message; }
		}
		#endregion

		#region Constructors
		/// <summary>Create and initialise form to edit existing message or to create new message.</summary>
		/// <param name="path">The location of file representing the message.</param>
		/// <param name="_format">Format of the message.</param>
		public NewEditMessage(string path, MessageFormat _format)
		{
			InitializeComponent();
			filePath = path;
			format = _format;

			List<string> contacts = Contacts.RetrieveContacts();
			contacts.Sort();
			cbxFromContacts.DataSource = new List<string>(contacts);
			cbxToContacts.DataSource = new List<string>(contacts);
		}

		/// <summary>Create and initialise form to edit existing message.</summary>
		/// <param name="_message">The text message to edit.</param>
		public NewEditMessage(TextMessage _message)
			: this(_message.FilePath, _message.Format)
		{
			message = _message;
			MessageStatus status = message.Status;
			//initialise controls with values, taking into account numbers with names in them
			string from = message.From;
			txtFrom.Text = from;
			if (!String.IsNullOrEmpty(from)) {
				string fromName = Contacts.RetrieveName(from);
				lblFromName.Text = fromName;
			}

			txtMessage.Text = message.MessageText;
			string to = message.To;
			txtTo.Text = to;
			if (!String.IsNullOrEmpty(to)) {
				string toName = Contacts.RetrieveName(to);
				lblToName.Text = toName;
			}

			DateTime dt = message.DateTime;
			dtpDate.Value = dt;
			dtpTime.Value = dt;
		}

		#endregion

		#region Event Handlers
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			string from = txtFrom.Text;
			string to = txtTo.Text;
			DateTime date = dtpDate.Value.Date;
			TimeSpan time = dtpTime.Value.TimeOfDay;
			date = date.Add(time);

			string messageText = txtMessage.Text;
			MessageStatus status = MessageStatus.Recieved;
			string number = String.Empty;
			if (!String.IsNullOrEmpty(from)) {
				number = from;
				status = MessageStatus.Recieved;
			} else if (!String.IsNullOrEmpty(to)) {
				number = to;
				status = MessageStatus.Sent;
			}
			bool isEditMode = message != null;
			message = TextMessage.CreateMessage(format, messageText, from, to, date, status, filePath);

			List<string> existingText = new List<string>();
			string[] newInfo = { from, to, date.ToShortDateString(), time.ToString(), messageText };

			//Get current info from exisiting file
			if (isEditMode) {
				StreamReader sr = new StreamReader(filePath);
				while (sr.Peek() != -1) {
					existingText.Add(sr.ReadLine());
				}

				sr.Close();
			}

			//Write details to file.
			if (!TextMessage.WriteTextMessage(existingText, message, format)) {
				MessageBox.Show("There was an error in saving the file");
				DialogResult = DialogResult.Cancel;
			} else {
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//only allow 0-9, <delete> and '+'
			if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || (int) e.KeyChar == 8 || (int) e.KeyChar == (int) '+')) {
				e.Handled = true;
			}
		}

		private void NewEditMessage_Load(object sender, System.EventArgs e)
		{
			//hide unneccessary controls for Motorola format.
			if (format == MessageFormat.Motorola) {
				label1.Hide();
				txtTo.Hide();

				label2.Text = "Contact";
				cbxToContacts.Hide();
				lblToName.Hide();
			}
		}

		private void cbxFromContacts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string contact = (string) cbxFromContacts.SelectedItem;
			int start = contact.IndexOf('(') + 1, length = contact.IndexOf(')') - start;
			string number = contact.Substring(start, length);

			if (number.StartsWith("0")) {
				number = "+44" + number.Substring(1);
			}
			txtFrom.Text = number;
			lblFromName.Text = contact.Substring(0, start - 1);
		}

		private void cbxToContacts_SelectedIndexChanged(object sender, EventArgs e)
		{
			string contact = (string) cbxToContacts.SelectedItem;
			int start = contact.IndexOf('(') + 1, length = contact.IndexOf(')') - start;
			string number = contact.Substring(start, length);

			if (number.StartsWith("0")) {
				number = "+44" + number.Substring(1);
			}
			txtTo.Text = number;
			lblToName.Text = contact.Substring(0, start - 1);
		}
		#endregion
	}
}