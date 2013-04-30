using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageClassLibrary.TextMessages
{
	public class MotorolaTextMessageParser : IMessageParser
	{
		public IMessage Parse(IEnumerable<string> lines)
		{
		//	string[] strings = lines.ToArray();
		//	string contact = strings[0].Substring("Contact: ".Length);
		//	string dateTimeString = strings[1].Substring("Date: ".Length);
		//	DateTime dateTime = DateTime.Parse(dateTimeString);
		//	string message = strings[3];
		//	IMessage result = new Message(message, contact, null, dateTime);

			List<string> fileLines = new List<string>(lines.Select(s => s.Replace("\0", "")));
			//From/To number line = 1
			string contact = fileLines[0];

			//date line = 2
			string dateTime = fileLines[1];
			DateTime dt = DateTime.Parse(dateTime.Substring(5));
			string[] dateItems = dateTime.Substring(6).Split(new char[] { '/' });
			try {
				DateTime.Parse(dateTime.Substring(6));
			} catch (FormatException) {
				dateTime = "Date: " + dateItems[1] + "/" + dateItems[0] + "/" + dateItems[2];
			}

			//Message line = 4
			string message = "";
			for (int i = 3; i < fileLines.Count; i++) {
				message += fileLines[i] + Environment.NewLine;
			}
			//remove last new line character
			message = message.Substring(0, message.Length - Environment.NewLine.Length);

			string textMessageNumber = contact.Substring(9);

			IMessage result = new Message(message, textMessageNumber, null, dt);
			return result;
		}

		public IMessage Parse(string line)
		{
			string[] strings = line.Split(new[] { '\r', '\n', }, StringSplitOptions.RemoveEmptyEntries);

			IMessage result = Parse(strings);

			return result;
		}
	}
}