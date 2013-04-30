using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MessageClassLibrary.TextMessages
{
	public class TextMessageReader : IMessageReader
	{
		public IMessageParser MessageParser { get; set; }

		public IMessage ReadTextMessage(string path)
		{
			string[] readAllLines = File.ReadAllLines(path);
			IMessage result = MessageParser.Parse(readAllLines);

			return result;
		}

		public IEnumerable<IMessage> ReadTextMessages(string path)
		{
			IEnumerable<string> files = Directory.EnumerateFiles(path);

			IEnumerable<IMessage> result = files.Select(ReadTextMessage);

			return result;
		}
	}
}