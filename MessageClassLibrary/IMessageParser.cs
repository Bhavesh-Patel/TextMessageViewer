using System.Collections.Generic;

namespace MessageClassLibrary
{
	/// <summary>Interface for message parser.</summary>
	public interface IMessageParser
	{
		/// <summary>Parses the specified lines.</summary>
		/// <param name="lines">The lines.</param>
		/// <returns>A <see cref="IMessage"/> composed from the given lines.</returns>
		IMessage Parse(IEnumerable<string> lines);

		/// <summary>Parses the specified line.</summary>
		/// <param name="line">The line.</param>
		/// <returns>A <see cref="IMessage"/> composed from the given line.</returns>
		IMessage Parse(string line);
	}
}
