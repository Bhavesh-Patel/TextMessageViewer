using System;

namespace MessageClassLibrary
{
	public interface IMessage : IEquatable<IMessage>
	{
		string MessageText { get; }

		string From { get; }

		string To { get; }

		DateTime DateTime { get; }
	}
}