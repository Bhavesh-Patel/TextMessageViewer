using System;
using MessageClassLibrary.TextMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageClassLibrary.Tests.TestMessages
{
	/// <summary>Test class for <see cref="NokiaTextMessageParser"/></summary>
	[TestClass]
	public class NokiaTextMessageParserTests
	{
		[TestMethod]
		public void ParseTest()
		{
			NokiaTextMessageParser nokiaTextMessageParser = new NokiaTextMessageParser();

			string messageText = @"This is the message text.";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();
			string from = @"01234567890";
			string nokiaMessageText = string.Format(@"






TEL:{0}





TEL:



Date:{1}
{2}
", from, dateTime, messageText);
			//string[] fileLines = File.ReadAllText(@"D:\Users - Manual\bhavesh\Source\Repos\TextMessageViewer\Resources\Messages\8310i\Inbox\3.vmg").Replace("\0", "").Replace("\r", "").Split(new char[] { '\n' });
			string[] fileLines = nokiaMessageText.Split(new char[] { '\n' });

			IMessage textMessage = nokiaTextMessageParser.Parse(fileLines);

			IMessage expectedResult = new Message(messageText, from, string.Empty, time);

			Assert.AreEqual(textMessage, expectedResult);
		}

		[TestMethod]
		public void ParseToNumberTest()
		{
			NokiaTextMessageParser nokiaTextMessageParser = new NokiaTextMessageParser();

			string messageText = @"This is the message text.";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();
			string to = @"01234567890";
			string nokiaMessageText = string.Format(@"






TEL:





TEL:{0}



Date:{1}
{2}
", to, dateTime, messageText);
			//string[] fileLines = File.ReadAllText(@"D:\Users - Manual\bhavesh\Source\Repos\TextMessageViewer\Resources\Messages\8310i\Inbox\3.vmg").Replace("\0", "").Replace("\r", "").Split(new char[] { '\n' });
			string[] fileLines = nokiaMessageText.Split(new char[] { '\n' });

			IMessage textMessage = nokiaTextMessageParser.Parse(fileLines);

			IMessage expectedResult = new Message(messageText, string.Empty, to, time);

			Assert.AreEqual(textMessage, expectedResult);
		}

		[TestMethod]
		public void NewFormatParseTest()
		{
			NokiaTextMessageParser nokiaTextMessageParser = new NokiaTextMessageParser();
			string messageText = @"This is the message text.";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();
			string from = @"01234567890";
			string nokiaMessageText = string.Format(@"BEGIN:VMSG
VERSION:1.1
X-IRMC-STATUS:READ
X-IRMC-BOX:INBOX
BEGIN:VCARD
VERSION:2.1
N:
TEL:{0}
END:VCARD
BEGIN:VENV
BEGIN:VBODY
Date:{1}
{2}
END:VBODY
END:VENV
END:VMSG
",from,dateTime, messageText);
			string[] fileLines = nokiaMessageText.Split(new char[] { '\n' });

			IMessage textMessage = nokiaTextMessageParser.Parse(fileLines);

			IMessage expectedResult = new Message(messageText, from, string.Empty, time);

			Assert.AreEqual(textMessage, expectedResult);
		}

		[TestMethod]
		public void NewFormatMultilineParseTest()
		{
			NokiaTextMessageParser nokiaTextMessageParser = new NokiaTextMessageParser();
			string messageText = @"This is the message text
with multiple lines";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();
			string from = @"01234567890";
			string nokiaMessageText = string.Format(@"BEGIN:VMSG
VERSION:1.1
X-IRMC-STATUS:READ
X-IRMC-BOX:INBOX
BEGIN:VCARD
VERSION:2.1
N:
TEL:{0}
END:VCARD
BEGIN:VENV
BEGIN:VBODY
Date:{1}
{2}
END:VBODY
END:VENV
END:VMSG
", from, dateTime, messageText);
			string[] fileLines = nokiaMessageText.Split(new char[] { '\n' });

			IMessage textMessage = nokiaTextMessageParser.Parse(fileLines);

			IMessage expectedResult = new Message(messageText, from, string.Empty, time);

			Assert.AreEqual(textMessage, expectedResult);
		}

		[TestMethod]
		public void NewFormatSingleLineParseTest()
		{
			NokiaTextMessageParser nokiaTextMessageParser = new NokiaTextMessageParser();
			string messageText = @"This is the message text.";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();
			string from = @"01234567890";
			string nokiaMessageText = string.Format("BEGIN:VMSG\nVERSION:1.1\nX-IRMC-STATUS:READ\nX-IRMC-BOX:INBOX\nBEGIN:VCARD\nVERSION:2.1\nN:\nTEL:{0}\nEND:VCARD\nBEGIN:VENV\nBEGIN:VCARD\nVERSION:2.1\nN:\nTEL:\nEND:VCARD\nBEGIN:VENV\nBEGIN:VBODY\nDate:{1}\n{2}\nEND:VBODY\nEND:VENV\nEND:VENV\nEND:VMSG\n", from, dateTime, messageText);

			IMessage textMessage = nokiaTextMessageParser.Parse(nokiaMessageText);

			IMessage expectedResult = new Message(messageText, from, string.Empty, time);

			Assert.AreEqual(textMessage, expectedResult);
		}
	}
}
