using System;

namespace MessageClassLibrary
{
	/// <summary>Interface for messages.</summary>
	public interface IMessage : IEquatable<IMessage>
	{
		/// <summary>Gets the message text.</summary>
		string MessageText { get; }

		/// <summary>Gets the message origin.</summary>
		string From { get; }

		/// <summary>Gets the message target.</summary>
		string To { get; }

		/// <summary>Gets the date time of the message.</summary>
		DateTime DateTime { get; }
	}
}