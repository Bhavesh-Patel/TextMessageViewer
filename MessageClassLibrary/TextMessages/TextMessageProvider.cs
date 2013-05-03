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

		public string Name { get; private set; }

		public TextMessageProvider(string name, string path, MessageFormat format)
		{
			Name = name;
			Path = path;
			MessageFormat messageFormat = format;
			IMessageParser messageParser = messageFormat == MessageFormat.Motorola ? (IMessageParser) new MotorolaTextMessageParser() : new NokiaTextMessageParser();
			textMessageReader = new TextMessageReader { MessageParser = messageParser };
		}

		private IEnumerable<IMessage> CreateTextMessages(string path)
		{
			IEnumerable<IMessage> result = textMessageReader.ReadTextMessages(path);

			return result;
		}
	}
}