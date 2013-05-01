using System;
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
		}

		public IMessage Message { get; private set; }
	}
}