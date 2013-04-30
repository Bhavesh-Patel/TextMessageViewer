using System;
using System.Collections.Generic;
using System.IO;

namespace MessageClassLibrary.TextMessages
{
	/// <summary>Representation of a text message.</summary>
	public class TextMessage : Message
	{
		#region Fields
		/// <summary>Message status.</summary>
		protected MessageStatus sentOrRecieved;

		/// <summary>Original Filename.</summary>
		protected string filePath;
		#endregion

		#region Public Properties

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
		public MessageFormat Format { get; private set; }
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="TextMessage"/> class.</summary>
		/// <param name="_message">The message.</param>
		/// <param name="fromNumber">The number.</param>
		/// <param name="toNumber"></param>
		/// <param name="_dateTime">The date time.</param>
		/// <param name="_sentOrRecieved">The sent or recieved status.</param>
		/// <param name="_filePath">Path of the file.</param>
		public TextMessage(MessageFormat format, string _message, string fromNumber, string toNumber, DateTime _dateTime, MessageStatus _sentOrRecieved, string _filePath)
			: base(_message, fromNumber, toNumber, _dateTime)
		{
			Format = format;
			sentOrRecieved = _sentOrRecieved;
			filePath = _filePath;
		}
		#endregion

		#region Public Methods
		/// <summary>Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</summary>
		/// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</returns>
		public override string ToString()
		{
			return MessageText;
		}
		#endregion

		#region Static Methods
		/// <summary>Creates the message of the correct format.</summary>
		/// <param name="_format">The format.</param>
		/// <param name="_message">The message.</param>
		/// <param name="fromNumber">The from number.</param>
		/// <param name="toNumber">The to number.</param>
		/// <param name="_dateTime">The date and time.</param>
		/// <param name="_sentOrRecieved">The sent or recieved status.</param>
		/// <param name="_filePath">The file path.</param>
		/// <returns>The newly created message.</returns>
		public static TextMessage CreateMessage(MessageFormat _format, string _message, string fromNumber, string toNumber, DateTime _dateTime, MessageStatus _sentOrRecieved, string _filePath)
		{
			TextMessage result = new TextMessage(_format, _message, fromNumber, toNumber, _dateTime, _sentOrRecieved, _filePath);

			return result;
		}

		/// <summary>Creates a <see cref="TextMessage"/> from a file containing data.</summary>
		/// <param name="filePath">The file path.</param>
		/// <param name="format">The format of the file to be read.</param>
		/// <returns>A TextMessage containing all relevant information from the file.</returns>
		public static TextMessage ReadTextMessage(string filePath, MessageFormat format)
		{
			TextMessage result;
			TextMessageReader textMessageReader= new TextMessageReader();
			switch (format) {
				case MessageFormat.Nokia: {
					textMessageReader.MessageParser = new NokiaTextMessageParser();
					break;
				}
				case MessageFormat.Motorola: {
					textMessageReader.MessageParser = new MotorolaTextMessageParser();
					break;
				}
				default:
					throw new NotImplementedException("No parser defined for " + format.ToString() + "...yet!");
			}

			IMessage readTextMessage = textMessageReader.ReadTextMessage(filePath);
			result = CreateTextMessage(format, readTextMessage, filePath);

			return result;
		}

		/// <summary>Creates a <see cref="TextMessage"/> from a file containing data.</summary>
		/// <param name="format">The message format.</param>
		/// <param name="message">The message to wrap up.</param>
		/// <param name="filePath">The file path.</param>
		/// <returns>A TextMessage containing all relevant information from the file.</returns>
		private static TextMessage CreateTextMessage(MessageFormat format, IMessage message, string filePath)
		{
			MessageStatus textMessageStatus;
			switch (format) {
				case MessageFormat.Nokia: {
					bool isSentMessage = String.IsNullOrEmpty(message.From) && !String.IsNullOrEmpty(message.To);
					textMessageStatus = isSentMessage ? MessageStatus.Sent : MessageStatus.Recieved;
					break;
				}
				case MessageFormat.Motorola: {
					textMessageStatus = MessageStatus.Recieved; //can't distingish status from data in text file
					break;
				}
				default:
					throw new NotImplementedException("Unable to read " + format.ToString() + "...yet!");
			}

			TextMessage result = new TextMessage(format, message.MessageText, message.From, message.To, message.DateTime,
				textMessageStatus,
				filePath);

			return result;
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
				string fromNumber = message.From;
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
				string toNumber = message.To;
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
				sw.WriteLine(message.MessageText);
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
				string number = message.Status == MessageStatus.Recieved ? message.From : message.To;
				sw.WriteLine("Contact: " + number);

				//Date line = 2
				sw.WriteLine("Date: " + message.DateTime.ToShortDateString() + " " + message.DateTime.ToLongTimeString());

				sw.WriteLine();

				//Message line = 4
				sw.WriteLine(message.MessageText);

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
