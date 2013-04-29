using System;
using System.IO;
using MessageClassLibrary.TextMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageClassLibrary.Tests.TestMessages
{
	/// <summary>
	/// Summary description for NokiaMessageParserTests
	/// </summary>
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
			//string[] fileLines = File.ReadAllText(@"D:\Users - Manual\bhavesh\Source\Repos\TextMessageViewer\Messages\8310i\Inbox\3.vmg").Replace("\0", "").Replace("\r", "").Split(new char[] { '\n' });
			string[] fileLines = nokiaMessageText.Replace("\0", "").Replace("\r", "").Split(new char[] { '\n' });

			IMessage textMessage = nokiaTextMessageParser.Parse(fileLines);

			IMessage expectedResult = new Message(messageText, from, string.Empty, time);

			Assert.AreEqual(textMessage, expectedResult);
		}
	}
}
