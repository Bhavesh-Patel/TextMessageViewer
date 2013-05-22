using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageClassLibrary.TextMessages
{
	/// <summary>Parser of Motorola text message files.</summary>
	public class MotorolaTextMessageParser : IMessageParser
	{
		#region Public Methods
		/// <summary>Parses the specified lines.</summary>
		/// <param name="lines">The lines.</param>
		/// <returns>A <see cref="IMessage" /> composed from the given lines.</returns>
		public IMessage Parse(IEnumerable<string> lines)
		{
			string[] strings = lines.Select(s => s.Replace("\0", "")).ToArray();
			string contact = strings[0].Substring("Contact: ".Length);
			string dateTimeString = strings[1].Substring("Date: ".Length);
			DateTime dateTime = DateTime.Parse(dateTimeString);
			string message = string.Join(Environment.NewLine, strings.Skip(3));

			IMessage result = new Message(message, contact, null, dateTime);

			return result;
		}

		/// <summary>Parses the specified line.</summary>
		/// <param name="line">The line.</param>
		/// <returns>A <see cref="IMessage" /> composed from the given line.</returns>
		public IMessage Parse(string line)
		{
			string[] strings = line.Split(new[] { '\r', '\n', });

			IMessage result = Parse(strings);

			return result;
		} 
		#endregion
	}
}