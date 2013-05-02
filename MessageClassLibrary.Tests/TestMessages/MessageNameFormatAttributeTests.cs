using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageClassLibrary.TextMessages;

namespace MessageClassLibrary.Tests.TestMessages
{
	/// <summary>Summary description for MessageNameFormatAttributeTests</summary>
	[TestClass]
	public class MessageNameFormatAttributeTests
	{
		[TestMethod]
		public void FileFormatTest()
		{
			string motorolaMessageFormat = MessageNameFormatAttribute.FileFormat(MessageFormat.Motorola);
			string expectedMessageFormat = "recu*.txt";

			Assert.AreEqual(expectedMessageFormat, motorolaMessageFormat);
		}
	}
}
