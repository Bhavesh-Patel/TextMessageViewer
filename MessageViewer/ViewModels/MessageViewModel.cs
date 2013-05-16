using System;
using Contacts;
using MessageClassLibrary;

namespace MessageViewer.ViewModels
{
	public class MessageViewModel
	{
		public MessageViewModel()
		{
			Message = new Message("My Message", "FROM me", "To You", new DateTime(2013, 3, 11, 10, 00, 00));
		}

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

		public IMessage Message { get; private set; }

		public string ToContact { get; private set; }

		public string FromContact { get; private set; }
	}
}