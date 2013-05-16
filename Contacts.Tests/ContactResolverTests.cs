using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contacts.Tests
{
	[TestClass]
	public class ContactResolverTests
	{
		[TestInitialize]
		public void Setup()
		{
			// TODO: this is pretty crap - should use mocking framework to augment
			//			ContactsProvider such that it doesn't read the contacts from disk
			System.Environment.CurrentDirectory =
				@"D:\Users - Manual\bhavesh\Source\Repos\TextMessageViewer\MessageClassLibrary.Tests\bin\Debug";
		}

		[TestMethod]
		public void Resolve11DigitPhoneNumber()
		{
			const string number = "07903306151";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual("Nisha", resolveContactName);
		}

		[TestMethod]
		public void ResolvePhoneNumberStartingWithPlusAndInternationalCountryCode()
		{
			const string number = "+447903306151";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual("Nisha", resolveContactName);
		}

		[TestMethod]
		public void UnableToResolvePhoneNumber()
		{
			const string number = "07930230346";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual(null, resolveContactName);
		}

		[TestMethod]
		public void ResolvePhoneNumberWithInternationalContact()
		{
			const string number = "+919824341727";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual("Kajal", resolveContactName);
		}

		[TestMethod]
		public void UnableToResolvePhoneNumberWithLessThan11DigitsStartingWithPlus()
		{
			const string number = "+27777";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual(null, resolveContactName);
		}


		[TestMethod]
		public void UnableToResolvePhoneNumberWithLessThan11Digits()
		{
			const string number = "27777";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual(null, resolveContactName);
		}

		[TestMethod]
		[Ignore]
		public void ResolvePhoneNumberWithLessThan11DigitsStartingWithPlus()
		{
			// TODO: implement once using mocking framework
			const string number = "+27777";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual("T-Mobile", resolveContactName);
		}


		[TestMethod]
		[Ignore]
		public void ResolvePhoneNumberWithLessThan11Digits()
		{
			// TODO: implement once using mocking framework
			const string number = "27777";

			string resolveContactName = ContactResolver.ResolveContactName(number);

			Assert.AreEqual("T-Mobile", resolveContactName);
		}
	}
}
