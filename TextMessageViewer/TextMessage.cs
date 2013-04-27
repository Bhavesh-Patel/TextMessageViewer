using System;
using System.Collections.Generic;
using System.IO;

namespace TextMessageViewer
{
	/// <summary>Representation of a text message.</summary>
	public abstract class TextMessage
	{
		#region Fields
		/// <summary>Text of message.</summary>
		protected string message;

		/// <summary>Date and time of message.</summary>
		protected DateTime dateTime;

		/// <summary>Number of sender or reciever of message.</summary>
		protected string number;

		/// <summary>Message status.</summary>
		protected MessageStatus sentOrRecieved;

		/// <summary>Original Filename.</summary>
		protected string filePath;
		#endregion

		#region Public Properties
		/// <summary>Gets the text of message.</summary>
		public string Message
		{
			get { return message; }
		}

		/// <summary>Gets the date and time of message.</summary>
		public DateTime DateTime
		{
			get { return dateTime; }
		}

		/// <summary>Gets the number of sender or reciever of message.</summary>
		public string Number
		{
			get { return number; }
		}

		/// <summary>Gets the message status.</summary>
		public MessageStatus Status
		{
			get { return sentOrRecieved; }
		}

		/// <summary>Gets the name of the original file.</summary>
		public string FileName
		{
			get { return Path.GetFileName(filePath); }
		}

		/// <summary>Gets the file path.</summary>
		public string FilePath
		{
			get { return filePath; }
		}

		/// <summary>Gets the format of this message.</summary>
		public abstract MessageFormat Format
		{
			get;
		}
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="TextMessage"/> class.</summary>
		/// <param name="_message">The message.</param>
		/// <param name="_number">The number.</param>
		/// <param name="_dateTime">The date time.</param>
		/// <param name="_sentOrRecieved">The sent or recieved status.</param>
		/// <param name="_filePath">Path of the file.</param>
		public TextMessage(string _message, string _number, DateTime _dateTime, MessageStatus _sentOrRecieved, string _filePath)
		{
			message = _message;
			number = _number;
			sentOrRecieved = _sentOrRecieved;
			dateTime = _dateTime;
			filePath = _filePath;
		}
		#endregion

		#region Public Methods
		/// <summary>Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</summary>
		/// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</returns>
		public override string ToString()
		{
			return message;
		}
		#endregion

		#region Static Methods
		/// <summary>Creates the message of the correct format.</summary>
		/// <param name="_format">The format.</param>
		/// <param name="_message">The message.</param>
		/// <param name="_number">The number.</param>
		/// <param name="_dateTime">The date and time.</param>
		/// <param name="_sentOrRecieved">The sent or recieved status.</param>
		/// <param name="_filePath">The file path.</param>
		/// <returns>The newly created message.</returns>
		public static TextMessage CreateMessage(MessageFormat _format, string _message, string _number, DateTime _dateTime, MessageStatus _sentOrRecieved, string _filePath)
		{
			//TODO: think about adding a subclass attribute to specify which subclass to create for a given format
			TextMessage result;
			switch (_format) {
				case MessageFormat.Nokia:
					result = new NokiaTextMessage(_message, _number, _dateTime, _sentOrRecieved, _filePath);
					break;
				case MessageFormat.Motorola:
					result = new MotorolaTextMessage(_message, _number, _dateTime, _sentOrRecieved, _filePath);
					break;
				default:
					throw new NotImplementedException("Cannot create TextMessage as no subclass exists for it:" + _format.ToString());
			}

			return result;
		}

		/// <summary>Creates a <see cref="TextMessage"/> from a file containing data.</summary>
		/// <param name="filePath">The file path.</param>
		/// <param name="format">The format of the file to be read.</param>
		/// <returns>A TextMessage containing all relevant information from the file.</returns>
		public static TextMessage ReadTextMessage(string filePath, MessageFormat format)
		{
			TextMessage result;
			switch (format) {
				case MessageFormat.Nokia: {
						result = ReadNokiaTextMessage(filePath);
						break;
					}
				case MessageFormat.Motorola: {
						result = ReadMotorolaTextMessage(filePath);
						break;
					}
				default:
					throw new NotImplementedException("Unable to read " + format.ToString() + "...yet!");
			}
			return result;
		}

		/// <summary>Creates a <see cref="TextMessage"/> from a file containing data, in Nokia format.</summary>
		/// <param name="filePath">The file path.</param>
		/// <returns>A TextMessage containing all relevant information from the file.</returns>
		private static TextMessage ReadNokiaTextMessage(string filePath)
		{
			//read in whole file removing \0 (null) and \r, and store lines in an array
			string[] fileLines = File.ReadAllText(filePath).Replace("\0", "").Replace("\r", "").Split(new char[] { '\n' });
			List<string> items = new List<string>(fileLines);

			int index = 0, maxIndex = items.Count;

			//find first line starting with TEL:
			while (index < maxIndex && !items[index].StartsWith("TEL:"))
				index++;

			//From number line
			string fromNum = items[index].Substring(4);

			//change between version 3 and 2.1: only single number stored
			//for backward compatibility try to find 2nd number, if first was empty.
			string toNum = String.Empty;
			if (fromNum == "") {
				while (index < maxIndex && !items[++index].StartsWith("TEL:")) ;
				//index++;
				//To number line
				toNum = items[index].Substring(4);
			}

			//find line starting with Date:
			while (index < maxIndex && !items[index].StartsWith("Date:"))
				index++;

			//Date line
			DateTime dt = DateTime.Parse(items[index].Substring(5));
			string dateTime = items[index];

			//Message line
			string message = items[++index];
			string tmp = items[++index];
			while (index + 1 < maxIndex && tmp != null && !tmp.StartsWith("END"))//checking for multi line messages
			{
				message += Environment.NewLine + tmp;
				tmp = items[++index];
			}

			bool isSentMessage = String.IsNullOrEmpty(fromNum) && !String.IsNullOrEmpty(toNum);
			string textMessageNumber = isSentMessage ? toNum : fromNum;
			MessageStatus textMessageStatus = isSentMessage ? MessageStatus.Sent : MessageStatus.Recieved;
			TextMessage textMessage = new NokiaTextMessage(message, textMessageNumber, dt, textMessageStatus, filePath);

			return textMessage;
		}

		/// <summary>Creates a <see cref="TextMessage"/> from a file containing data, in Motorola format.</summary>
		/// <remarks>The text file doesn't contain infomation to indicate whether it was sent or recieved.</remarks>
		/// <param name="filePath">The file path.</param>
		/// <returns>A TextMessage containing all relevant information from the file.</returns>
		private static TextMessage ReadMotorolaTextMessage(string filePath)
		{
			//string path = lblPath.Text + "\\"+ e.Node.Text;
			StreamReader sr = new StreamReader(filePath);

			//From/To number line = 1
			string contact = sr.ReadLine().Replace("\0", "");

			//date line = 2
			string dateTime = sr.ReadLine().Replace("\0", "");
			DateTime dt = DateTime.Parse(dateTime.Substring(5));
			string[] dateItems = dateTime.Substring(6).Split(new char[] { '/' });
			try {
				DateTime.Parse(dateTime.Substring(6));
			} catch (FormatException) {
				dateTime = "Date: " + dateItems[1] + "/" + dateItems[0] + "/" + dateItems[2];
			}

			sr.ReadLine();

			//Message line = 4
			string message = "";
			while (sr.Peek() != -1) {
				message += sr.ReadLine().Replace("\0", "") + Environment.NewLine;
			}
			//remove last new line character
			message = message.Substring(0, message.Length - Environment.NewLine.Length);

			sr.Close();

			string textMessageNumber = contact.Substring(9);
			MessageStatus textMessageStatus = MessageStatus.Recieved;//can't distingish status from data in text file
			TextMessage textMessage = new MotorolaTextMessage(message, textMessageNumber, dt, textMessageStatus, filePath);

			return textMessage;
		}

		/// <summary>Writes the text message to a file.</summary>
		/// <param name="existingText">Any existing text, usually read from the file before editing.</param>
		/// <param name="message">The message.</param>
		/// <param name="format">The message format.</param>
		/// <returns>True, if sucessful, False otherwise.</returns>
		public static bool WriteTextMessage(List<string> existingText, TextMessage message, MessageFormat format)
		{
			bool result;

			switch (format) {
				case MessageFormat.Nokia: {
						result = WriteNokiaMessageFile(existingText, message);
						break;
					}
				case MessageFormat.Motorola: {
						result = WriteMotorolaMessgeFile(message);
						break;
					}
				default:
					result = false;
					break;
			};

			return result;
		}

		/// <summary>Writes the text message to a file, in Nokia format.</summary>
		/// <param name="existingText">Any existing text, usually read from the file before editing.</param>
		/// <param name="message">The message.</param>
		/// <returns>True, if sucessful, False otherwise.</returns>
		private static bool WriteNokiaMessageFile(List<string> existingText, TextMessage message)
		{
			int j = 0;
			bool inEditMode = existingText.Count > 0;
			bool success;

			StreamWriter sw = new StreamWriter(message.filePath);

			try {
				if (inEditMode) {
					for (int i = 0; i < 7; i++) {
						sw.WriteLine(existingText[j]);
						j++;
					}
				} else {
					for (int i = 0; i < 7; i++) {
						sw.WriteLine();
						j++;
					}
				}

				//From number line = 7
				string fromNumber = message.Status == MessageStatus.Recieved ? message.Number : "";
				sw.WriteLine("TEL:" + fromNumber);//from
				j++;

				if (inEditMode) {
					for (int i = 0; i < 5; i++) {
						sw.WriteLine(existingText[j]);
						j++;
					}
				} else {
					for (int i = 0; i < 5; i++) {
						sw.WriteLine();
						j++;
					}
				}
				//To number line = 13
				string toNumber = message.Status == MessageStatus.Sent ? message.Number : "";
				sw.WriteLine("TEL:" + toNumber);
				j++;

				if (inEditMode) {
					for (int i = 0; i < 3; i++) {
						sw.WriteLine(existingText[j]);
						j++;
					}
				} else {
					for (int i = 0; i < 3; i++) {
						sw.WriteLine();
						j++;
					}
				}
				//Date line = 17
				sw.WriteLine("Date:" + message.DateTime.ToShortDateString() + " " + message.DateTime.ToLongTimeString());
				j++;

				//Message line = 18
				sw.WriteLine(message.Message);
				j++;

				if (inEditMode) {
					for (int i = j; i < 24; i++) {
						sw.WriteLine(existingText[i]);
					}
				} else {
					for (int i = j; i < 24; i++) {
						sw.WriteLine();
						j++;
					}
				}
				success = true;
			} catch (IOException) {
				success = false;
			}

			sw.Close();

			return success;
		}

		/// <summary>Writes the text message to a file, in Motorola format.</summary>
		/// <param name="message">The message.</param>
		/// <returns>True, if sucessful, False otherwise.</returns>
		private static bool WriteMotorolaMessgeFile(TextMessage message)
		{
			bool success;
			StreamWriter sw = new StreamWriter(message.filePath);

			try {
				//Contact number line = 1
				sw.WriteLine("Contact: " + message.Number);

				//Date line = 2
				sw.WriteLine("Date: " + message.DateTime.ToShortDateString() + " " + message.DateTime.ToLongTimeString());

				sw.WriteLine();

				//Message line = 4
				sw.WriteLine(message.Message);

				success = true;
			} catch (IOException) {
				success = false;
			}

			sw.Close();

			return success;
		}
		
		#endregion
	}

	/// <summary>Represents status of a text message.</summary>
	public enum MessageStatus
	{
		/// <summary>Text message recieved.</summary>
		Recieved,
		/// <summary>Text message sent.</summary>
		Sent
	}
}
