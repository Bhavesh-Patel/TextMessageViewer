using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MessageClassLibrary;
using MessageClassLibrary.TextMessages;

namespace TextMessageViewerWPF.ViewModels
{
	public class TextMessagesViewModel
	{
		public ObservableCollection<TextMessageViewModel> TextMessages { get; set; }

		public TextMessageViewModel CurrentTextMessage { get; set; }

		public TextMessagesViewModel()
		{
			const string path = @"..\..\..\Messages\V3i\Inbox";
			TextMessageReader textMessageReader = new TextMessageReader { MessageParser = new MotorolaTextMessageParser() };
			IEnumerable<IMessage> readTextMessages = textMessageReader.ReadTextMessages(path);
			IEnumerable<TextMessageViewModel> textMessageViewModels =
				readTextMessages.OrderBy(t => t.DateTime).Select(t => new TextMessageViewModel(t));
			TextMessages = new ObservableCollection<TextMessageViewModel>(textMessageViewModels);
		}
	}
}
