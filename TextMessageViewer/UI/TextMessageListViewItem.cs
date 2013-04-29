using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TextMessageViewer
{
	/// <summary>Class to dispaly details associated with a <see cref="TextMessage"/>.</summary>
	class TextMessageListViewItem : ListViewItem
	{
		#region Fields
		/// <summary>The TextMessage whose details are displayed.</summary>
		private TextMessage message;

		/// <summary>The format of the message.</summary>
		private MessageFormat format; 
		#endregion

		#region Public Properties
		/// <summary>Gets the TextMessage whose details are displayed.</summary>
		public TextMessage Message
		{
			get { return message; }
		}

		/// <summary>Gets the format of the message.</summary>
		public MessageFormat Format
		{
			get { return format; }
		} 
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="TextMessageListViewItem"/> class.</summary>
		/// <param name="_message">The TextMessage whose details are to be displayed.</param>
		public TextMessageListViewItem(TextMessage _message)
			: base()
		{
			message = _message;
			format = message.Format;

			string toNamesAndNumbers = NamesAndNumbers(message.To);
			string fromNamesAndNumbers = NamesAndNumbers(message.From);
			string fromNumber = fromNamesAndNumbers;
			string toNumber = toNamesAndNumbers;

			//TODO: use Reflector to see the internals of new ListViewItem(string[]) - in regards to SubItems and the default item
/*
public ListViewItem(string[] items, int imageIndex) : this()
{
    this.ImageIndexer.Index = imageIndex;
    if ((items != null) && (items.Length > 0))
    {
        this.subItems = new ListViewSubItem[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            this.subItems[i] = new ListViewSubItem(this, items[i]);
        }
        this.SubItemCount = items.Length;
    }
}
*/

			ListViewSubItem fromNumberItem = new ListViewSubItem(this, fromNumber);
			fromNumberItem.Name = "FromNumber";
			SubItems.Add(fromNumberItem);
			ListViewSubItem messageItem = new ListViewSubItem(this, message.MessageText);
			messageItem.Name = "Message";
			SubItems.Add(messageItem);
			string dateString = message.DateTime.Date.ToShortDateString();
			ListViewSubItem dateItem = new ListViewSubItem(this, dateString);
			dateItem.Name = "Date";
			SubItems.Add(dateItem);
			string timeString = message.DateTime.TimeOfDay.ToString();
			ListViewSubItem timeItem = new ListViewSubItem(this, timeString);
			timeItem.Name = "Time";
			SubItems.Add(timeItem);
			ListViewSubItem toNumberItem = new ListViewSubItem(this, toNumber);
			toNumberItem.Name = "ToNumber";
			SubItems.Add(toNumberItem);
			ListViewSubItem fileNameItem = new ListViewSubItem(this, message.FileName);
			fileNameItem.Name = "FileName";
			SubItems.Add(fileNameItem);
			SubItems.RemoveAt(0);//remove initial default entry
		}

		private string NamesAndNumbers(string _number)
		{
			string namesAndNumbers = "";
			if (_number != null) {
				string[] numbers = _number.Split(' ');
				foreach (string number in numbers) {
					//for each number
					string nameAndNumber = number;

					string contactName = Contacts.RetrieveName(number);
					if (!String.IsNullOrEmpty(contactName)) {
						//found contact name - add to string
						nameAndNumber = contactName + "(" + number + ")";
					}
					namesAndNumbers += nameAndNumber + " ";
				}
				//trim trailing space
				namesAndNumbers = namesAndNumbers.TrimEnd();
			}
			return namesAndNumbers;
		}

		#endregion
	}
}
