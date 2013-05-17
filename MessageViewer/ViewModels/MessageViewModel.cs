using System;
using Contacts;
using MessageClassLibrary;

namespace MessageViewer.ViewModels
{
	/// <summary>ViewModel for a <see cref="Message"/>.</summary>
	public class MessageViewModel
	{
		#region Properties
		/// <summary>Gets the message.</summary>
		public IMessage Message { get; private set; }

		/// <summary>Gets the 'to' contact.</summary>
		public string ToContact { get; private set; }

		/// <summary>Gets the 'from' contact.</summary>
		public string FromContact { get; private set; }
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="MessageViewModel"/> class.</summary>
		/// <remarks>This constructor is primarily for the XAML design views.</remarks>
		public MessageViewModel()
		{
			Message = new Message("My Message", "FROM me", "To You", new DateTime(2013, 3, 11, 10, 00, 00));
		}

		/// <summary>Initializes a new instance of the <see cref="MessageViewModel"/> class.</summary>
		/// <param name="message">The message.</param>
		public MessageViewModel(IMessage message)
		{
			Message = message;
			string @from = Message.From;
			if (@from != null) {
				string fromContact = ContactResolver.ResolveContactName(@from.Trim());
				fromContact = fromContact ?? @from;
				FromContact = fromContact;
			}
			string to = Message.To;
			if (to != null) {
				string toContact = ContactResolver.ResolveContactName(to.Trim());
				toContact = toContact ?? to;
				ToContact = toContact;
			}
		} 
		#endregion
	}
}