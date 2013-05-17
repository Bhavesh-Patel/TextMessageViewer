using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MessageClassLibrary.TextMessages
{
	/// <summary>Text message reader.</summary>
	public class TextMessageReader : IMessageReader
	{
		#region Properties
		public IMessageParser MessageParser { get; set; } 
		#endregion

		#region Public Methods
		/// <summary>Reads the text message at the given path.</summary>
		/// <param name="path">The file path.</param>
		/// <returns>A message composed from the file at the given path.</returns>
		public IMessage ReadTextMessage(string path)
		{
			string[] readAllLines = File.ReadAllLines(path);
			IMessage result = MessageParser.Parse(readAllLines);

			return result;
		}

		/// <summary>Reads all the text messages from the given directory path.</summary>
		/// <param name="path">The directory path.</param>
		/// <returns>Messages composed from the files within the given directory path.</returns>
		public IEnumerable<IMessage> ReadTextMessages(string path)
		{
			IEnumerable<string> files = Directory.EnumerateFiles(path);

			IEnumerable<IMessage> result = files.Select(ReadTextMessage);

			return result;
		} 
		#endregion
	}
}