using System;
using MessageClassLibrary;

namespace TextMessageViewerWPF.ViewModels
{
	public class TextMessageViewModel
	{
		private IMessage textMessage;
		
		public TextMessageViewModel()
		{
			TextMessage = new Message("My Message", "FROM me", "To You", new DateTime(2013, 3, 11, 10, 00, 00));
		}

		public TextMessageViewModel(IMessage textMessage)
		{
			TextMessage = textMessage;
		}

		public IMessage TextMessage
		{
			get { return textMessage; }
			private set { textMessage = value; }
		}
		
		
	}
}