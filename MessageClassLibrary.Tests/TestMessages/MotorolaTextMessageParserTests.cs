using System;
using MessageClassLibrary.TextMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageClassLibrary.Tests.TestMessages
{
	/// <summary>Test class for <see cref="MotorolaTextMessageParser"/></summary>
	[TestClass]
	public class MotorolaTextMessageParserTests
	{
		[TestMethod]
		public void ParseTest()
		{
			MotorolaTextMessageParser motorolaTextMessageParser = new MotorolaTextMessageParser();

			const string from = @"01234567890";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();

			const string messageText = @"This is the message text.";
			string[] motorolaMessageTextLines = new[] {string.Format("Contact: {0}", @from), string.Format("Date: {0}", dateTime), "", messageText};

			IMessage textMessage = motorolaTextMessageParser.Parse(motorolaMessageTextLines);

			IMessage expectedResult = new Message(messageText, from, null, time);

			Assert.AreEqual(expectedResult, textMessage);
		}

		[TestMethod]
		public void ParseSingleLineTest()
		{
			MotorolaTextMessageParser motorolaTextMessageParser = new MotorolaTextMessageParser();

			const string from = @"01234567890";
			DateTime time = new DateTime(2003, 12, 13, 12, 12, 26);
			string dateTime = time.ToString();

			const string messageText = @"This is the message text.";
			string motorolaMessageText = string.Format("Contact: {0}\nDate: {1}\n\n{2}", from, dateTime, messageText);
			IMessage textMessage = motorolaTextMessageParser.Parse(motorolaMessageText);

			IMessage expectedResult = new Message(messageText, from, null, time);

			Assert.AreEqual(expectedResult, textMessage);
		}
	}
}
