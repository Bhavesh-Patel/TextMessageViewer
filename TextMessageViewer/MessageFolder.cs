using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextMessageViewer
{
	class MessageFolder
	{
		public event EventHandler MessagesRetrieved;

		public event EventHandler<MessagesRetrievalProgressEventArgs> MessagesRetrievalProgress;

		#region Fields
		protected string name;

		protected List<TextMessage> messages = new List<TextMessage>();

		protected List<MessageFolder> folders = new List<MessageFolder>();

		protected MessageFolder parentFolder;
		#endregion

		#region Public Properties
		public string Name
		{
			get { return name; }
		}

		public List<TextMessage> Messages
		{
			get { return messages; }
			set { messages = value; }
		}

		public List<MessageFolder> Folders
		{
			get { return folders; }
			set { folders = value; }
		}

		public MessageFolder ParentFolder
		{
			get { return parentFolder; }
			set { parentFolder = value; }
		}
		#endregion

		#region Constructors
		public MessageFolder(string _name)
		{
			name = _name;
		} 
		#endregion

		#region Public Methods
		public virtual string RetrievePath()
		{
			return parentFolder.RetrievePath() + name + "\\";
		}

		public void RetrieveMessages(string path)
		{
			//subfolders
			string[] subfolders = Directory.GetDirectories(RetrievePath());
			Array.Sort<string>(subfolders);
			folders = new List<MessageFolder>(subfolders.Length);//avoid resizing of list
			foreach (string str in subfolders) {
				string[] pathSplit = str.Split(new char[] { '\\' });
				string displayString = pathSplit[pathSplit.Length - 1];
				MessageFolder folder = new MessageFolder(displayString);
				folder.parentFolder = this;
				folders.Add(folder);
			}

			messages.Clear();
			//messages
			MessageFormat format = RetrieveFormat();
			string fileFormat = MessageNameFormatAttribute.FileFormat(format);
			string[] files = Directory.GetFiles(RetrievePath(), fileFormat);
			messages = new List<TextMessage>(files.Length);//avoid resizing of list
			int numberOfMessages = files.Length, currentMessage = 0;
			foreach (string file in files) {
				messages.Add(TextMessage.ReadTextMessage(file, format));
				currentMessage++;
				OnMessagesRetrievalProgress(this, new MessagesRetrievalProgressEventArgs(currentMessage, numberOfMessages));
			}

			OnMessagesRetrieved(this, new EventArgs());
		}

		public MessageFormat RetrieveFormat()
		{
			MessageFormat result;
			if (this is MobilePhone) {
				result = ((MobilePhone) this).Format;
			} else {
				result = parentFolder.RetrieveFormat();
			}

			return result;
		}

		//public string GetNextFileName()
		//{
		//    string path = RetrievePath();
		//    char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		//    foreach (TextMessage message in messages) {
		//        string messageFileName = message.FileName;
		//        int firstDigitIndex = messageFileName.IndexOfAny(digits);
		//        int lastDigitIndex = messageFileName.LastIndexOfAny(digits);
		//    }

		//    return String.Empty;
		//}
		#endregion

		#region Non-Public Methods
		protected void OnMessagesRetrieved(object sender, EventArgs e)
		{
			if (MessagesRetrieved != null) {
				MessagesRetrieved(sender, e);
			}
		}
		protected void OnMessagesRetrievalProgress(object sender, MessagesRetrievalProgressEventArgs e)
		{
			if (MessagesRetrievalProgress != null) {
				MessagesRetrievalProgress(sender, e);
			}
		}
		#endregion

		public class MessagesRetrievalProgressEventArgs : EventArgs
		{
			private int totalMessages;

			private int currentMessage;

			public int TotalMessages
			{
				get { return totalMessages; }
			}

			public int CurrentMessage
			{
				get { return currentMessage; }
			}

			public MessagesRetrievalProgressEventArgs(int _currentMessage, int _totalMessages)
			{
				currentMessage = _currentMessage;
				totalMessages = _totalMessages;
			}
		}
	}
}
