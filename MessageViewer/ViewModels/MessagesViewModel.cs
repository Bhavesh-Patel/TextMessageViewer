using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MessageClassLibrary;
using MessageClassLibrary.TextMessages;

namespace MessageViewer.ViewModels
{
	public class MessagesViewModel
	{
		public ObservableCollection<MessageViewModel> TextMessages { get; set; }

		public MessageViewModel CurrentMessage { get; set; }

		public MessagesViewModel()
		{
			const string path = @"..\..\..\Messages\V3i\Inbox";
			TextMessageReader textMessageReader = new TextMessageReader { MessageParser = new MotorolaTextMessageParser() };
			IEnumerable<IMessage> readTextMessages = textMessageReader.ReadTextMessages(path);
			IEnumerable<MessageViewModel> textMessageViewModels =
				readTextMessages.OrderBy(t => t.DateTime).Select(t => new MessageViewModel(t));
			TextMessages = new ObservableCollection<MessageViewModel>(textMessageViewModels);
		}
	}
}
