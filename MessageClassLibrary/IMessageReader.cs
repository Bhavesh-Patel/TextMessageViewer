using System.Collections.Generic;

namespace MessageClassLibrary
{
	interface IMessageReader
	{
		IMessage ReadTextMessage(string path);

		IEnumerable<IMessage> ReadTextMessages(string path);
	}
}
