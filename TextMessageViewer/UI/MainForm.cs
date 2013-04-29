using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;
using System.Configuration;
using System.Collections.Specialized;
using Bhavesh.Utilities;
using Bhavesh.WindowsControlLibrary;
using System.Collections.Generic;
using Bhavesh.WindowsControlLibrary.CollectionViewers;

namespace TextMessageViewer
{
	/// <summary></summary>
	public partial class MainForm : Form
	{
		#region Member Variables
		/// <summary>Location of folder containing subfolders representing phones.</summary>
		private static readonly string path;
		/// <summary>Cache of listviewitems representing messages, keyed by location.</summary>
		private Dictionary<string, ListViewItem[]> messageCache = new Dictionary<string, ListViewItem[]>();
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="MainForm"/> class.</summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>Retrieves the path of the initial folder.</summary>
		static MainForm()
		{
			path = ConfigurationSettings.AppSettings["InitialFolder"];
		}
		#endregion

		#region Features
		/// <summary>Creates the path for the given node.</summary>
		/// <param name="node">The node to create the path for.</param>
		/// <returns>The path for the node.</returns>
		private string CreateNodePath(TreeNode node)
		{
			string result = ((MessageFolder) node.Tag).RetrievePath();

			return result;
		}

		/// <summary>Refreshes the given node.</summary>
		/// <remarks>Clears the cache for this and sub nodes, and recreates the listviewitems for this node.</remarks>
		/// <param name="node">The node to refresh.</param>
		private void RefreshNode(TreeNode node)
		{
			string nodePath;

			statusBar.Text = "Refreshing...";
			using (new WaitCursor()) {
				nodePath = CreateNodePath(node);

				//remove cache for all sub items
				List<string> keysToRemove = new List<string>();
				foreach (string key in messageCache.Keys) {
					if (key.StartsWith(nodePath)) {
						keysToRemove.Add(key);
					}
				}
				foreach (string key in keysToRemove) {
					messageCache.Remove(key);
				}
				node.Nodes.Clear();

				//phone/subfolder node
				MessageFolder messageFolder = (MessageFolder) node.Tag;
				messageFolder.RetrieveMessages(path);
			}
		}

		/// <summary>Creates and adds ListViewItems for messages receieved and TreeNodes for folders.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MessageFolder_MessagesRetrieved(object sender, EventArgs e)
		{
			MessageFolder folder = (MessageFolder) sender;

			progressBar.Visible = true;
			progressBar.Maximum = folder.Messages.Count + folder.Folders.Count + 1;
			progressBar.Value = 0;
			// 0 = type, 1 = current, 2 = total, 3 = name
			string progressText = "Creating items...{0} [{1}/{2}]: {3}";

			tvParents.BeginUpdate();
			TreeNode currentNode = tvParents.SelectedNode;
			int currentFolder = 0;
			int totalFolders = folder.Folders.Count;
			foreach (MessageFolder subfolder in folder.Folders) {
				//create treeview node
				TreeNode node = currentNode.Nodes.Add(subfolder.Name);
				subfolder.MessagesRetrieved += new EventHandler(MessageFolder_MessagesRetrieved);
				subfolder.MessagesRetrievalProgress += new EventHandler<MessageFolder.MessagesRetrievalProgressEventArgs>(MessageFolder_MessagesRetrievalProgress);
				node.Tag = subfolder;
				progressBar.Value++;
				currentFolder++;
				statusBar.Text = String.Format(progressText, "Folder", currentFolder, totalFolders, subfolder.Name);
			}
			tvParents.EndUpdate();

			//list view items:
			lvChildren.BeginUpdate();
			lvChildren.Items.Clear();
			//messageCache.Remove(nodePath);
			int currentMessage = 0;
			int totalMessages = folder.Messages.Count;
			MessageFormat messageFolderFormat = folder.RetrieveFormat();
			foreach (TextMessage message in folder.Messages) {
				//create listview item's for each new message
				ListViewItem item = new TextMessageListViewItem(message);
				lvChildren.Items.Add(item);
				progressBar.Value++;
				currentMessage++;
				statusBar.Text = String.Format(progressText, "Text Message", currentMessage, totalMessages, message.FileName);
			}
			lvChildren.EndUpdate();

			if (!(folder is MobilePhone)) {
				ListViewItem[] cacheItems = new ListViewItem[lvChildren.Items.Count];
				lvChildren.Items.CopyTo(cacheItems, 0);
				messageCache[CreateNodePath(currentNode)] = cacheItems;
			}

			progressBar.Visible = false;
			SetNodeStatus(currentNode);
		}

		/// <summary>Shows/hides and updates progress bar and status message.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="TextMessageViewer.MessageFolder.MessagesRetrievalProgressEventArgs"/> instance containing the event data.</param>
		private void MessageFolder_MessagesRetrievalProgress(object sender, MessageFolder.MessagesRetrievalProgressEventArgs e)
		{
			if (e.CurrentMessage == 1) {
				//first message
				progressBar.Visible = true;
				progressBar.Maximum = e.TotalMessages;
			} else if (e.CurrentMessage == e.TotalMessages) {
				progressBar.Visible = false;
			}
			statusBar.Text = "Reading items...[" + e.CurrentMessage + "/" + e.TotalMessages + "]...";
			progressBar.Value = e.CurrentMessage;
		}

		/// <summary>Sets the text of the status bar wrt the given node.</summary>
		/// <param name="node">The node to set the status wrt.</param>
		private void SetNodeStatus(TreeNode node)
		{
			if (node.Tag != null) {
				statusBar.Text = "Phone: " + CreateNodePath(node);
			} else {
				statusBar.Text = node.Text;
			}
			if (lvChildren.Items.Count > 0) {
				statusBar.Text += "[" + lvChildren.Items.Count + " messages]";
			}
		}

		/// <summary>Adds the phone node.</summary>
		/// <param name="phoneName">Name of the phone.</param>
		/// <param name="path">The path of phone folder.</param>
		/// <param name="format">The format of messages within folder.</param>
		private void AddPhoneNode(string phoneName, string path, MessageFormat format)
		{
			MobilePhone phone = new MobilePhone(phoneName, format, path);
			TreeNode node = tvParents.Nodes[0].Nodes.Add(phoneName);
			node.Tag = phone;
			phone.MessagesRetrieved += new EventHandler(MessageFolder_MessagesRetrieved);
			phone.MessagesRetrievalProgress += new EventHandler<MessageFolder.MessagesRetrievalProgressEventArgs>(MessageFolder_MessagesRetrieved);
			tvParents.SelectedNode = node;//select each node to add the folders
		}
		#endregion

		#region Event Handlers
		/// <summary>Closes the application.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		///// <summary>Sorts the lvChildren list view.</summary>
		///// <param name="sender">The source of the event.</param>
		///// <param name="e">The <see cref="System.Windows.Forms.ColumnClickEventArgs"/> instance containing the event data.</param>
		//private void lvChildren_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		//{
		//    ListViewColumnSorter.SortListView(lvChildren, e.Column);
		//}

		/// <summary>Displays text message in lower controls. Also updates buttons.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void lvChildren_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//update appropriate controls wrt selected listviewitem
			if (lvChildren.SelectedItems.Count > 0) {
				//TODO: could use TextMessageListViewItem, and retrieve message and use values within
				ListViewItem items = lvChildren.SelectedItems[0];
				lblFrom.Text = items.SubItems[0].Text;
				txtMessage.Text = items.SubItems[1].Text;
				lblDate.Text = items.SubItems[2].Text;
				lblTime.Text = items.SubItems[3].Text;
				lblTo.Text = items.SubItems[4].Text;
				btnEdit.Enabled = true;
				tsBtnEdit.Enabled = true;
			} else {
				lblFrom.Text = "";
				txtMessage.Text = "";
				lblDate.Text = "";
				lblTime.Text = "";
				lblTo.Text = "";
				btnEdit.Enabled = false;
				tsBtnEdit.Enabled = true;
			}
			//disable edit for consolidated view from parent nodes (top most node and phone nodes)
			btnEdit.Enabled &= !(tvParents.SelectedNode.Tag is MobilePhone) && tvParents.SelectedNode.Parent != null;
			tsBtnEdit.Enabled &= tvParents.SelectedNode.Parent != null && !(tvParents.SelectedNode.Tag is MobilePhone);
		}

		/// <summary>Updates message cache after <see cref="TextMessageListViewItem"/>.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="TextMessageViewer.AfterTextMessageItemUpdateEventArgs"/> instance containing the event data.</param>
		private void lvChildren_AfterTextMessageItemUpdate(object sender, AfterTextMessageItemUpdateEventArgs e)
		{
			MessageFolder messageFolder = (MessageFolder) tvParents.SelectedNode.Tag;
			//update cache...
			string cacheKey = messageFolder.RetrievePath();
			List<ListViewItem> items = new List<ListViewItem>(messageCache[cacheKey]);
			//remove from cache
			items.Remove(e.OldItem);
			//add to cache
			items.Add(e.NewItem);
			messageCache[cacheKey] = items.ToArray();
		}

		/// <summary>Reads initial phone directories, specified in App.config.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MainBoard_Load(object sender, System.EventArgs e)
		{
			//IDictionary tmp = (IDictionary) ConfigurationSettings.GetConfig("InitialFolder");

			//string[] phones = Directory.GetDirectories(path), pathSplit, displayString;

			NameValueCollection phones = (NameValueCollection) ConfigurationSettings.GetConfig("Phones");

			//load initial nodes from config file
			foreach (string phoneName in phones.Keys) {
				MessageFormat format = (MessageFormat) Enum.Parse(typeof(MessageFormat), phones[phoneName]);
				AddPhoneNode(phoneName, path, format);
			}

			tvParents.SelectedNode = tvParents.Nodes[0];
		}

		/// <summary>Updates lvChildren depending on what type of node was selected.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		private void tvParents_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//set controls to display appropriately wrt selected node.
			string nodePath;

			lvChildren.BeginUpdate();
			// 0 = current folder, 1 = total folders
			string statusMessage = "Consolidating Text Message Folders...[{0}/{1}]";

			btnRefresh.Enabled = true;
			tsBtnRefresh.Enabled = true;
			if (e.Node.Parent == null) {
				//top level node - show all messages from all phones (and their subfolders)
				lvChildren.Items.Clear();
				statusMessage = String.Format(statusMessage, "{0}", messageCache.Values.Count);
				//show any messages that have been cached
				int currentFolder = 0;
				foreach (ListViewItem[] items in messageCache.Values) {
					lvChildren.Items.AddRange(items);
					currentFolder++;
					statusBar.Text = String.Format(statusMessage, currentFolder);
				}
				SetNodeStatus(e.Node);
				btnAdd.Enabled = false;
				btnEdit.Enabled = false;
				btnRefresh.Enabled = false;
				btnRename.Enabled = false;
				tsBtnAdd.Enabled = false;
				tsBtnEdit.Enabled = false;
				tsBtnRefresh.Enabled = false;
			} else if (e.Node.Tag is MessageFolder) {
				if (e.Node.Nodes.Count == 0 || !(e.Node.Tag is MobilePhone)) {
					//phone or folder node with no children 
					nodePath = CreateNodePath(e.Node);
					if (!messageCache.ContainsKey(nodePath)) {
						RefreshNode(e.Node);
					} else {
						lvChildren.Items.Clear();
						lvChildren.Items.AddRange(messageCache[nodePath]);
						SetNodeStatus(e.Node);
					}
					btnAdd.Enabled = true;
					btnRename.Enabled = true;
					tsBtnAdd.Enabled = true;
				} else if (e.Node.Tag is MobilePhone) {
					//phone node - show messages from all subfolders
					btnRename.Enabled = false;
					btnAdd.Enabled = false;
					tsBtnAdd.Enabled = false;
					lvChildren.Items.Clear();
					nodePath = CreateNodePath(e.Node);
					List<string> keys = new List<string>();
					//show any cached messages for this phone
					foreach (string key in messageCache.Keys) {
						if (key.IndexOf(nodePath) != -1) {
							keys.Add(key);
						}
					}

					statusMessage = String.Format(statusMessage, "{0}", keys.Count);
					int currentFolder = 0;
					foreach (string key in keys) {
						lvChildren.Items.AddRange(messageCache[key]);
						currentFolder++;
						statusBar.Text = String.Format(statusMessage, currentFolder);
					}
					SetNodeStatus(e.Node);
				} 
			}

			lvChildren.EndUpdate();
		}

		/// <summary>Presents form to create new text message and adds new text message to lvChildren.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			// as files are numbered from 0, lvChildren.Items.Count will give the next file number
			string fileNumber = lvChildren.Items.Count.ToString();
			MessageFolder messageFolder = (MessageFolder) tvParents.SelectedNode.Tag;
			string filePath = messageFolder.RetrievePath();
			MessageFormat format = messageFolder.RetrieveFormat();

			if (format == MessageFormat.Motorola) {
				fileNumber = fileNumber.PadLeft(4, '0');
			}
			string nextFile = MessageNameFormatAttribute.FileFormat(format).Replace("*", fileNumber);
			filePath += nextFile;
			NewEditMessage form = new NewEditMessage(filePath, format);
			if (form.ShowDialog(this) != DialogResult.Cancel) {
				//TODO: shouldn't(?) do this directly - should add to phone and trigger event to add message!
				ListViewItem lvi = new TextMessageListViewItem(form.Message);
				lvChildren.Items.Add(lvi);
				lvChildren.Sort();

				//add to cache
				string cacheKey = messageFolder.RetrievePath();
				List<ListViewItem> items = new List<ListViewItem>(messageCache[cacheKey]);
				items.Add(lvi);
				messageCache[cacheKey] = items.ToArray();
			}
		}

		/// <summary>Tells <see cref="TextMessageListView"/> to edit text message and updates text message to lvChildren.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			lvChildren.EditTextMessage();
		}

		/// <summary>After requesting start index, will copy all items currently shown in list view 
		/// to a subfolder called Renamed, renaming incrementally from the start index.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnRename_Click(object sender, System.EventArgs e)
		{
			InputForm input = new InputForm("Enter start index:", "Start Index");
			if (input.ShowDialog(this) == DialogResult.OK) {
				int n = 0;
				string startIndex = input.InputText;
				try {
					n = int.Parse(startIndex);
				} catch (FormatException) {
					MessageBox.Show("That is not a valid number.\n 0 will be used as the start index", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				string subfolder = "Renamed\\", filename, fileNumber;//path = this.Text+"\\"
				bool doIt = true;
				MessageFolder folder = (MessageFolder) tvParents.SelectedNode.Tag;
				MessageFormat format = folder.RetrieveFormat();
				System.Diagnostics.Debugger.Launch();//could probably use folder.RetrievePath()
				string path = MainForm.path + "\\" + tvParents.SelectedNode.FullPath.Substring(tvParents.Nodes[0].Text.Length + 1) + "\\";

				if (Directory.Exists(path + subfolder)) {
					doIt = false;
					DialogResult dr = MessageBox.Show("Overwrite existing directory and files", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
					if (dr == DialogResult.OK) {
						doIt = true;
						Directory.Delete(path + subfolder, true);
					} else {
						MessageBox.Show("Operation Aborted");
					}
				}
				if (doIt) {
					Directory.CreateDirectory(path + subfolder);
					foreach (ListViewItem lvi in lvChildren.Items) {
						filename = lvi.SubItems[5].Text;
						fileNumber = n.ToString();
						if (format == MessageFormat.Motorola) {
							fileNumber = fileNumber.PadLeft(4, '0');
						}
						File.Copy(path + filename, path + subfolder + MessageNameFormatAttribute.FileFormat(format).Replace("*", fileNumber));
						n++;
					}
				}
				//File.Move(txtPath.Text+txtOrigFileName.Text,txtPath.Text+txtNewFileName.Text);
				//File.Delete(txtPath.Text+txtOrigFileName.Text);
			}
		}

		/// <summary>Refreshes currently selected tree node. Will re-retrieve messages and folders.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			RefreshNode(tvParents.SelectedNode);
		}

		/// <summary>Creates a new subfolder.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuCreateNew_Click(object sender, System.EventArgs e)
		{
			//node has been set for mnuCreateNew when context menu was opening
			TreeNode node = (TreeNode) ((MenuItem) sender).Tag;
			string nodePath;
			bool isTopNode = node.Parent == null;
			if (isTopNode) {
				//top most node
				nodePath = path + "\\";
			} else {
				//phone/folder node
				nodePath = CreateNodePath(node);
			}

			InputForm input = new InputForm("Enter name for new folder:", "New Folder");
			if (input.ShowDialog(this) == DialogResult.OK) {
				string newName = input.InputText;
				Directory.CreateDirectory(nodePath + newName);
				if (isTopNode) {
					//top most node
					AddPhoneNode(newName, nodePath, MessageFormat.Nokia);
				} else {
					//phone/folder node
					RefreshNode(node);
				}
			}
		}

		/// <summary>Adds an existing phone folder.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuAddExisting_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
			folderBrowser.SelectedPath = path;
			if (folderBrowser.ShowDialog(this) == DialogResult.OK) {
				string phonePath = folderBrowser.SelectedPath;
				string phoneName = Path.GetFileName(phonePath);
				phonePath = Path.GetDirectoryName(phonePath);
				TextMessageViewer.ChooseFormat formatForm = new TextMessageViewer.ChooseFormat();
				if (formatForm.ShowDialog(this) == DialogResult.OK) {
					AddPhoneNode(phoneName, phonePath, formatForm.Format);
				}
			}
		}

		/// <summary>Disable and enable appropriate commands for tree view.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void ctxMTreeview_Popup(object sender, System.EventArgs e)
		{
			TreeNode node;

			node = tvParents.GetNodeAt(tvParents.PointToClient(MousePosition));

			//if (node.Parent == null) {
			//    mnuCreateNew.Enabled = false;
			//} else {
			//    mnuCreateNew.Enabled = true;
			//}
			mnuCreateNew.Tag = node;//don't want to select the node, but need to pass it to the menu click
		}

		/// <summary>Shows a form containing contacts.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuShowContacts_Click(object sender, System.EventArgs e)
		{
			Contacts.ShowContacts();
		}

		/// <summary>Reads and displays an Access database of messages.</summary>
		/// <remarks>This was from an earlier version of Nokia Suite.</remarks>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuReadAccessDatabase_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = "Access Database (*.mdb)|*.MDB";

			if (openDialog.ShowDialog(this) == DialogResult.OK) {
				AccessDatabaseMessages accessDBMessages = new AccessDatabaseMessages(openDialog.FileName);
				accessDBMessages.Show();
			}
		}

		/// <summary>Tryies to lauch the file(s) associated with the selected messages.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuListViewView_Click(object sender, System.EventArgs e)
		{
			foreach (TextMessageListViewItem item in lvChildren.SelectedItems) {
				TextMessage message = item.Message;
				string filePath = message.FilePath;
				//Perhaps this should allow the default application to open the file
				//System.Diagnostics.Process.Start("notepad", filePath);
				System.Diagnostics.Process.Start(filePath);
			}
		}

		/// <summary>Presents form to edit text message and updates text message to lvChildren.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuListViewEdit_Click(object sender, System.EventArgs e)
		{
			btnEdit_Click(sender, e);
		}
		#endregion

		/// <summary>Backsup all messages to the archive specified in app.config.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuBackupAllToArchive_Click(object sender, EventArgs e)
		{
			
		}

		private void mnuBackupToArchiveTV_Click(object sender, EventArgs e)
		{

		}

		private void mnuBackupToArchiveLV_Click(object sender, EventArgs e)
		{
			List<TextMessage> backupMessages = new List<TextMessage>();
			foreach (TextMessageListViewItem backupItem in lvChildren.SelectedItems) {
				backupMessages.Add(backupItem.Message);
			}
			BackupToArchive(backupMessages);
		}

		private void BackupToArchive(List<TextMessage> messagesToBackup)
		{
			List<string> messagesPaths = new List<string>();
			foreach (TextMessage message in messagesToBackup) {
				string filePath = message.FilePath;
				filePath = filePath.Replace(path +"\\", "");//remove initial path
				messagesPaths.Add(filePath);
			}

			BackupToArchive(messagesPaths);
		}

		private void BackupToArchive(List<string> messagePaths)
		{
			string archivePath = ConfigurationSettings.AppSettings["ArchivePath"];
			WinRARManager.AddToArchive(archivePath, messagePaths);
		}

		private void mnuImportMessages_Click(object sender, EventArgs e)
		{
			TreeNode folderNode = tvParents.SelectedNode;
			MessageFolder folder = (MessageFolder) folderNode.Tag;
			MessageFormat format = folder.RetrieveFormat();
			ImportMessagesForm importForm = new ImportMessagesForm(format);
			if (importForm.ShowDialog(this) == DialogResult.OK) {
				List<TextMessage> importMessages = importForm.Messages;

				InputForm input = new InputForm("Rename messages - Enter start index:", "Start Index");
				Dictionary<string, string> fileNameMap = new Dictionary<string, string>();
				bool validIndex = false;
				while (!validIndex && input.DialogResult != DialogResult.Cancel) {
					if (input.ShowDialog(this) == DialogResult.OK) {
						int n = 0;
						string startIndex = input.InputText;
						try {
							n = int.Parse(startIndex);
							validIndex = true;

							foreach (TextMessage importMessage in importMessages) {
								string fileName = importMessage.FileName;
								string fileNumber = n.ToString();
								if (format == MessageFormat.Motorola) {
									fileNumber = fileNumber.PadLeft(4, '0');
								}
								string newFileName = MessageNameFormatAttribute.FileFormat(format).Replace("*", fileNumber);
								fileNameMap.Add(fileName, newFileName);
								n++;
							}
						} catch (FormatException) {
							MessageBox.Show("That is not a valid number. Enter a valid numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}

				string targetLocation = folder.RetrievePath();
				foreach (TextMessage importMessage in importMessages) {
					string sourceLocation = importMessage.FilePath;
					string fileName = Path.GetFileName(sourceLocation);
					string newFileName;
					if (!fileNameMap.TryGetValue(fileName, out newFileName)) {
						newFileName = fileName;
					}
					//does not replace files
					File.Copy(sourceLocation, targetLocation + newFileName);
				}
				RefreshNode(folderNode);
			}
		}

		private void mnuShowStats_Click(object sender, EventArgs e)
		{
			TreeNode folderNode = tvParents.SelectedNode;
			MessageFolder folder = (MessageFolder) folderNode.Tag;

			Dictionary<int, int> yearMessageCount = new Dictionary<int, int>();
			Dictionary<int, Dictionary<int, int>> yearMonthMessageCount = new Dictionary<int, Dictionary<int, int>>();

			Dictionary<string, int> numberMessageCount = new Dictionary<string, int>();

			foreach (TextMessage message in folder.Messages) {
				int year = message.DateTime.Year;
				int month = message.DateTime.Month;
				
				if (!yearMessageCount.ContainsKey(year)) {
					yearMessageCount[year] = 0;
				}
				yearMessageCount[year]++;

				Dictionary<int, int> monthMessageCount;
				if (!yearMonthMessageCount.TryGetValue(year, out monthMessageCount)) {
					monthMessageCount= new Dictionary<int, int>();
					yearMonthMessageCount[year] = monthMessageCount;
				}
				if (!monthMessageCount.ContainsKey(month)) {
					monthMessageCount[month] = 0;
				}

				monthMessageCount[month]++;

				string number = message.Number;
				if (!numberMessageCount.ContainsKey(number)) {
					numberMessageCount[number] = 0;
				}
				numberMessageCount[number]++;
			}

			// determine a top X number of messagers
			int top = 5;
			Dictionary<string, int> topNumberMessageCounts = new Dictionary<string, int>(top);
			foreach (KeyValuePair<string, int> numberMessages in numberMessageCount) {
				List<int> counts = new List<int>(topNumberMessageCounts.Values);
				counts.Add(numberMessages.Value);
				counts.Sort();
				counts.Reverse();
				if (topNumberMessageCounts.Count < top) {
					// not found initial top X, so just add
					topNumberMessageCounts.Add(numberMessages.Key, numberMessages.Value);
				} else if (counts[top] != numberMessages.Value) {
					// the last number wasn't the current number, hence need to add
					int valueToRemove = counts[top];
					// find and remove item with last value
					foreach (KeyValuePair<string, int> values in topNumberMessageCounts) {
						if (values.Value == valueToRemove) {
							topNumberMessageCounts.Remove(values.Key);
							break;
						}
					}
					// add new item
					topNumberMessageCounts.Add(numberMessages.Key, numberMessages.Value);
				}
			}
		}
	}
}