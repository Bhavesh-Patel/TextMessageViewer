using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using Bhavesh.WindowsControlLibrary.CollectionViewers;

namespace TextMessageViewer
{
	class Contacts
	{
		/// <summary>Cache of loaded contacts, keyed by number.</summary>
		private static Dictionary<string, string> contacts = new Dictionary<string, string>();

		private static ContactsViewer viewer;

		/// <summary>Populate the contacts member, with vcf files from the contactsDir. Keyed by number.</summary>
		static Contacts()
		{
			string contactDir = ConfigurationSettings.AppSettings["Contacts"];
			Hashtable contactsTmp = vCardReader.vCardReader.ReadVCardDirectory(contactDir);

			//extract numbers from contact details
			foreach (string contactName in contactsTmp.Keys) {
				//get contact details
				Hashtable contactDetails = (Hashtable) contactsTmp[contactName];
				if (contactDetails.ContainsKey("TEL")) {
					//get contact numbers, if they have any
					Hashtable contactNumbers = (Hashtable) contactDetails["TEL"];
					foreach (Hashtable numberCategory in contactNumbers.Values) {
						//contacts can have multiple categories of numbers (HOME, WORK, etc)
						foreach (string[] contactCategoryNumbers in numberCategory.Values) {
							foreach (string contactNumber in contactCategoryNumbers) {
								string convertedNumber = contactNumber;
								//TODO: perhaps the following should be performed within vCardReader
								//if number starts with a '+(44)', remove it and replace with a '0'
								if (convertedNumber.IndexOf('+') != -1) {
									convertedNumber = "0" + convertedNumber.Substring(convertedNumber.Length - 10);
								}
								//store the number as a key with value of the contact name
								contacts[convertedNumber] = contactName;
							}
						}
					}
				}
			}
		}

		/// <summary>Retrieves the name of contact given a number</summary>
		/// <remarks>Will check contacts using preceding '0' and '+44'.</remarks>
		/// <param name="number">The number.</param>
		/// <returns>Name of the contact, if one is found.</returns>
		public static string RetrieveName(string number)
		{
			return RetrieveName(number, true);
		}

		/// <summary>Retrieves the name of contact given a number</summary>
		/// <param name="number">The number.</param>
		/// <param name="tryAlternatives">True to tru using preceding '0' and '+44' to find a match.</param>
		/// <returns>Name of the contact, if one is found.</returns>
		private static string RetrieveName(string number, bool tryAlternatives)
		{
			string name = null;
			contacts.TryGetValue(number, out name);

			if (name == null && tryAlternatives) {
				if (number.StartsWith("+") && number.Length > 10) {
					string numberStartingWith0 = "0" + number.Substring(number.Length - 10);
					name = Contacts.RetrieveName(numberStartingWith0, false);//use false to not enter an infinite loop
				} else if (number.StartsWith("0") && number.Length > 10) {
					string numberStartingWithPlus44 = "+44" + number.Substring(number.Length - 10);
					name = Contacts.RetrieveName(numberStartingWithPlus44, true);//use false to not enter an infinite loop
				}
			}

			return name;
		}

		public static List<string> RetrieveContacts()
		{
			List<string> result = new List<string>();
			foreach (KeyValuePair<string,string> contact in contacts) {
				result.Add(contact.Value + "(" + contact.Key + ")");
			}

			return result;
		}

		/// <summary>Shows the contacts collection.</summary>
		public static void ShowContacts()
		{
			//only create the form once, and (re-)show 
			if (viewer == null) {
				viewer = new ContactsViewer(contacts);
			}
			viewer.Show();
			viewer.Focus();
		}
	}
}
