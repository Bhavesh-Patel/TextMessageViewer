using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MessageClassLibrary.TextMessages
{
	public class TextMessageRecursiveProvider : TextMessageProvider
	{
		public TextMessageRecursiveProvider(string path, MessageFormat format)
			: base(path, format)
		{
		}

		protected override IEnumerable<IMessage> CreateTextMessages(string path)
		{
			IEnumerable<string> directories = Directory.GetDirectories(path);
			IEnumerable<IMessage> result = directories.SelectMany(base.CreateTextMessages);

			return result;
		}
	}
}
