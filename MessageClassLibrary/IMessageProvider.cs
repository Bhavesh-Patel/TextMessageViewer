using System.Collections.Generic;

namespace MessageClassLibrary
{
	public interface IMessageProvider
	{
		IEnumerable<IMessage> Messages { get; }
	}
}
