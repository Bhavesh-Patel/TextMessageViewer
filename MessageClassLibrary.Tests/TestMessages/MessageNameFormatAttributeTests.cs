using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageClassLibrary.TextMessages;

namespace MessageClassLibrary.Tests.TestMessages
{
	/// <summary>Test class for <see cref="MessageNameFormatAttribute"/></summary>
	[TestClass]
	public class MessageNameFormatAttributeTests
	{
		[TestMethod]
		public void FileFormatTest()
		{
			string motorolaMessageFormat = MessageNameFormatAttribute.FileFormat(MessageFormat.Motorola);
			const string expectedMessageFormat = "recu*.txt";

			Assert.AreEqual(expectedMessageFormat, motorolaMessageFormat);
		}
	}
}
