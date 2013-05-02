using System.Collections.Generic;

namespace MessageClassLibrary.TextMessages
{
	public class TextMessageProvider : IMessageProvider
	{
		private IEnumerable<IMessage> messages;

		private readonly IMessageReader textMessageReader;

		private string Path { get; set; }

		public IEnumerable<IMessage> Messages
		{
			get { return messages ?? (messages = CreateTextMessages(Path)); }
		}

		public TextMessageProvider(string path, MessageFormat format)
		{
			Path = path;
			MessageFormat messageFormat = format;
			IMessageParser messageParser = messageFormat == MessageFormat.Motorola ? (IMessageParser) new MotorolaTextMessageParser() : new NokiaTextMessageParser();
			textMessageReader = new TextMessageReader { MessageParser = messageParser };
		}

		protected virtual IEnumerable<IMessage> CreateTextMessages(string path)
		{
			IEnumerable<IMessage> result = textMessageReader.ReadTextMessages(path);

			return result;
		}
	}
}