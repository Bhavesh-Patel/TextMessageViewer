using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextMessageViewer
{
	/// <summary>Allows importing of text messages.</summary>
	public partial class ImportMessagesForm : Form
	{
		/// <summary>The message format to import.</summary>
		private MessageFormat format;

		/// <summary>A dummy phone used to update listview items.</summary>
		private MobilePhone phone;

		/// <summary>Messages to import.</summary>
		private List<TextMessage> importMessages = new List<TextMessage>();

		/// <summary>Gets the message format to impor.</summary>
		public MessageFormat Format
		{
			get { return format; }
		}

		/// <summary>Gets the messages to import.</summary>
		public List<TextMessage> Messages
		{
			get { return importMessages; }
		}

		/// <summary>Initializes a new instance of the <see cref="ImportMessagesForm"/> class.</summary>
		/// <param name="_format">The message format to import.</param>
		public ImportMessagesForm(MessageFormat _format)
		{
			InitializeComponent();

			format = _format;
			lblMessageFormat.Text = format.ToString();
		}

		/// <summary>Re-populates initialises the phone using the selected directory.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void folderSelector_SelectionChanged(object sender, EventArgs e)
		{
			string fullPath = folderSelector.SelectionName;
			string phoneName = System.IO.Path.GetFileName(fullPath);
			string folderPath = System.IO.Path.GetDirectoryName(fullPath);
			phone = new MobilePhone(phoneName, format, folderPath);
			phone.MessagesRetrieved += new EventHandler(phone_MessagesRetrieved);
			phone.RetrieveMessages(".");
			
		}

		/// <summary>Populates the list view with messages.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void phone_MessagesRetrieved(object sender, EventArgs e)
		{
			textMessageListView.Items.Clear();
			MobilePhone phone = (MobilePhone) sender;
			List<TextMessage> messages = phone.Messages;
			foreach (TextMessage message in messages) {
				//create listview item's for each new message
				ListViewItem item = new TextMessageListViewItem(message);
				item.Checked = true;
				textMessageListView.Items.Add(item);
			}
		}

		/// <summary>Adds messages to be imported to importMessages, and closes form.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnImport_Click(object sender, EventArgs e)
		{
			foreach (TextMessageListViewItem item in textMessageListView.CheckedItems) {
				importMessages.Add(item.Message);
			}
			Close();
		}

		/// <summary>Allows drop only if dragged file names are of the correct format.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
		private void lvChildren_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop);

				string nameFormat = MessageNameFormatAttribute.FileFormat(format);
				nameFormat = nameFormat.Replace("*", "");
				List<string> newFileNames = new List<string>();
				foreach (string fileName in fileNames) {
					if (fileName.EndsWith(nameFormat)) {
						newFileNames.Add(fileName);
					}
				}
				if (newFileNames.Count > 0) {
					e.Data.SetData("FileName", newFileNames.ToArray());
					e.Effect = DragDropEffects.All;
				} else {
					//drop not valid
					e.Effect = DragDropEffects.None;
				}
			}
		}

		/// <summary>Adds relevant textmessages to the list view.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
		private void lvChildren_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop);
			Dictionary<string, ListViewItem> messagesInListView = new Dictionary<string, ListViewItem>();
			foreach (ListViewItem item in textMessageListView.Items) {
				messagesInListView.Add(((TextMessage) item.Tag).FilePath, item);
			}
			foreach (string fileName in fileNames) {
				if (messagesInListView.ContainsKey(fileName)) {
					messagesInListView[fileName].Remove();
				}
				TextMessage message = TextMessage.ReadTextMessage(fileName, format);
				ListViewItem item = new TextMessageListViewItem(message);
				item.Checked = true;
				textMessageListView.Items.Add(item);
			}
		}

		/// <summary>Removes all text messges from the list view.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnClear_Click(object sender, EventArgs e)
		{
			textMessageListView.Items.Clear();
		}

		/// <summary>Shows form to edit activated text message item.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void lvChildren_ItemActivate(object sender, EventArgs e)
		{
			ListViewItem lvi = textMessageListView.SelectedItems[0];
			TextMessage message = (TextMessage) lvi.Tag;
			string filePath = message.FilePath;
			NewEditMessage form = new NewEditMessage(message);

			if (form.ShowDialog(this) != DialogResult.Cancel) {
				ListViewItem lvi2 = new TextMessageListViewItem(form.Message);
				textMessageListView.Items.Insert(lvi.Index, lvi2);
				lvi.Remove();
				textMessageListView.Sort();
			}
		}
	}
}