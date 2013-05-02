using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MessageClassLibrary;
using MessageClassLibrary.TextMessages;

namespace MessageViewer.ViewModels
{
	public class MessagesViewModel
	{
		public ObservableCollection<MessageViewModel> Messages { get; set; }

		public MessageViewModel CurrentMessage { get; set; }

		public MessagesViewModel()
		{
			Messages = new ObservableCollection<MessageViewModel>();
			for (int i = 0; i < 5; i++) {
				MessageViewModel messageViewModel = new MessageViewModel(new Message("Message" + i, "From" + i, "To" + i, DateTime.Now));
				Messages.Add(messageViewModel);
			}
			CurrentMessage = Messages.First();
		}

		public MessagesViewModel(string path, MessageFormat format)
		{
			CreateMessages(path, format);
		}

		private void CreateMessages(string path, MessageFormat format)
		{
			TextMessageProvider provider = new TextMessageProvider(path, format);

			IEnumerable<IMessage> messages = provider.Messages;

			IEnumerable<MessageViewModel> messageViewModels =
				messages.OrderBy(t => t.DateTime).Select(t => new MessageViewModel(t));
			Messages = new ObservableCollection<MessageViewModel>(messageViewModels);
		}
	}
}
