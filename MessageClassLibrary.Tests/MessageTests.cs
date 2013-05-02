using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageClassLibrary.Tests
{
	[TestClass]
	public class MessageTests
	{
		[TestMethod]
		public void CanGetMessageTest()
		{
			const string testText = "Test text";
			Message message = new Message(testText, string.Empty, null, DateTime.Now);

			Assert.AreEqual(message.MessageText, testText);
		}

		[TestMethod]
		public void CanGetFromTest()
		{
			const string testText = "Test from";
			Message message = new Message(string.Empty, testText, null, DateTime.Now);

			Assert.AreEqual(message.From, testText);
		}

		[TestMethod]
		public void CanGetToTest()
		{
			const string testText = "Test to";
			Message message = new Message(string.Empty, string.Empty, testText, DateTime.Now);

			Assert.AreEqual(message.To, testText);
		}

		[TestMethod]
		public void CanGetDateTimeTest()
		{
			DateTime dateTime = new DateTime(2013, 1, 1);
			Message message = new Message(string.Empty, string.Empty, null, dateTime);

			Assert.AreEqual(message.DateTime, dateTime);
		}

		[TestMethod]
		public void AreEqual()
		{
			const string messageText = "Message";
			const string @from = "from";
			const string to = "to";
			DateTime dateTime = new DateTime();
			Message message = new Message(messageText, @from, to, dateTime);
			Message message2 = new Message(messageText, @from, to, dateTime);

			Assert.AreEqual(message, message2);
		}

		[TestMethod]
		public void AreNotEqualPassingNull()
		{
			const string messageText = "Message";
			const string @from = "from";
			const string to = "to";
			DateTime dateTime = new DateTime();
			Message message = new Message(messageText, @from, to, dateTime);

			Assert.AreNotEqual(message, null);
		}

		[TestMethod]
		public void AreNotEqualPassingObject()
		{
			const string messageText = "Message";
			const string @from = "from";
			const string to = "to";
			DateTime dateTime = new DateTime();
			Message message = new Message(messageText, @from, to, dateTime);

			Assert.AreNotEqual(message, new object());
		}

		[TestMethod]
		public void ValidateHashCode()
		{
			const string messageText = "Message";
			const string @from = "from";
			const string to = "to";
			DateTime dateTime = new DateTime();
			Message message = new Message(messageText, @from, to, dateTime);
			int hashCode = message.GetHashCode();

			string hashString = message.MessageText + message.From + message.To + message.DateTime.ToString();
			int expectedHashCode = hashString.GetHashCode();

			Assert.AreEqual(expectedHashCode, hashCode);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullValueInvalidForMessageTest()
		{
// ReSharper disable ObjectCreationAsStatement
			new Message(null, string.Empty, null, DateTime.Now);
// ReSharper restore ObjectCreationAsStatement
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void NullValuesInvalidForToAndFromTest()
		{
// ReSharper disable ObjectCreationAsStatement
			new Message(string.Empty, null, null, DateTime.Now);
// ReSharper restore ObjectCreationAsStatement
		}
	}
}
