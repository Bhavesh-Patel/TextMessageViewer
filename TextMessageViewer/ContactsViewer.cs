using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bhavesh.WindowsControlLibrary.CollectionViewers;

namespace TextMessageViewer
{
	/// <summary>Displays contacts keyed by name, and phone number values.</summary>
	public partial class ContactsViewer : KeyValuePairCollectionViewer<string, string>
	{
		/// <summary>Initializes a new instance of the <see cref="ContactsViewer"/> class.</summary>
		/// <param name="contacts">The contacts keyed by number with name values.</param>
		public ContactsViewer(Dictionary<string, string> contacts)
			: base(contacts)
		{
			InitializeComponent();
		}

		/// <summary>Displays the contacts.</summary>
		/// <remarks>Switchs key(number) and value(name).</remarks>
		protected override void DisplayCollection()
		{
			foreach (KeyValuePair<string, string> contact in collection) {
				listview.Items.Add(new ListViewItem(new string[] { contact.Value, contact.Key }));
			}
		}
	}
}