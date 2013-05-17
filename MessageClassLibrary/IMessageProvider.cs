using System.Collections.Generic;

namespace MessageClassLibrary
{
	/// <summary>Interface for message provider.</summary>
	public interface IMessageProvider
	{
		/// <summary>Gets the messages.</summary>
		IEnumerable<IMessage> Messages { get; }

		/// <summary>Gets the name of the provider.</summary>
		string Name { get; }
	}
}
