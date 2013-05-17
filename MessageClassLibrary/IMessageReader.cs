using System.Collections.Generic;

namespace MessageClassLibrary
{
	/// <summary>Interface for message reader.</summary>
	/// <remarks>Message readers should read files from disk and create messages.</remarks>
	interface IMessageReader
	{
		/// <summary>Reads the text message at the given path.</summary>
		/// <param name="path">The file path.</param>
		/// <returns>A message composed from the file at the given path.</returns>
		IMessage ReadTextMessage(string path);

		/// <summary>Reads all the text messages from the given directory path.</summary>
		/// <param name="path">The directory path.</param>
		/// <returns>Messages composed from the files within the given directory path.</returns>
		IEnumerable<IMessage> ReadTextMessages(string path);
	}
}
