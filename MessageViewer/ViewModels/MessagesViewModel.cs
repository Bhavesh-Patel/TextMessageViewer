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
			const string path = @"..\..\..\Messages\V3i\Inbox";
			TextMessageReader textMessageReader = new TextMessageReader { MessageParser = new MotorolaTextMessageParser() };
			IEnumerable<IMessage> messages = textMessageReader.ReadTextMessages(path);
			IEnumerable<MessageViewModel> messageViewModels =
				messages.OrderBy(t => t.DateTime).Select(t => new MessageViewModel(t));
			Messages = new ObservableCollection<MessageViewModel>(messageViewModels);
		}
	}
}
