using System.Collections.Generic;

namespace MessageClassLibrary
{
	public interface IMessageParser
	{
		IMessage Parse(IEnumerable<string> lines);

		IMessage Parse(string line);
	}
}
