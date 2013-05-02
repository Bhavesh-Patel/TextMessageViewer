using System.Collections.Generic;

namespace MessageClassLibrary.TextMessages
{
	public class TextMessageProvider : IMessageProvider
	{
		private IEnumerable<IMessage> messages;

		public string Path { get; set; }

		public MessageFormat Format { get; set; }

		public IEnumerable<IMessage> Messages
		{
			get { return messages ?? (messages = CreateTextMessages()); }
		}

		public TextMessageProvider(string path, MessageFormat format)
		{
			Path = path;
			Format = format;
		}

		private IEnumerable<IMessage> CreateTextMessages()
		{
			IMessageReader textMessageReader = new TextMessageReader {
				MessageParser =
					Format == MessageFormat.Motorola ? (IMessageParser) new MotorolaTextMessageParser() : new NokiaTextMessageParser()
			};
			IEnumerable<IMessage> result = textMessageReader.ReadTextMessages(Path);

			return result;
		}
	}
}