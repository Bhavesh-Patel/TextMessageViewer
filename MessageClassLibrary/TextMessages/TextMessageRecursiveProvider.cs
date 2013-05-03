using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemPath = System.IO.Path;

namespace MessageClassLibrary.TextMessages
{
	public class TextMessageRecursiveProvider : CompositeMessageProvider
	{
		private string Path { get; set; }

		private MessageFormat Format { get; set; }

		public TextMessageRecursiveProvider(string name, string path, MessageFormat format)
			: base(name)
		{
			Path = path;
			Format = format;
		}

		protected override IEnumerable<IMessage> CreateMessages()
		{
			IEnumerable<IMessage> result = CreateTextMessages(Path);

			return result;
		}

		private IEnumerable<IMessage> CreateTextMessages(string path)
		{
			IEnumerable<string> directories = Directory.GetDirectories(path);
			IEnumerable<TextMessageProvider> textMessageProviders =
				directories.Select(directory => new TextMessageProvider(SystemPath.GetDirectoryName(directory), directory, Format));
			AddRange(textMessageProviders);

			IEnumerable<IMessage> result = base.CreateMessages();

			return result;
		}
	}
}
