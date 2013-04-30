using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageClassLibrary.TextMessages
{
	public class NokiaTextMessageParser : IMessageParser
	{
		public IMessage Parse(IEnumerable<string> lines)
		{
			//removing \0 (null) and \r
			List<string> items = new List<string>(lines.Select(s => s.Replace("\0", "").Replace("\r", "")));

			int index = 0, maxIndex = items.Count;

			//find first line starting with TEL:
			while (index < maxIndex && !items[index].StartsWith("TEL:"))
				index++;

			//From number line
			string fromNum = items[index].Substring(4);

			//change between version 3 and 2.1: only single number stored
			//for backward compatibility try to find 2nd number, if first was empty.
			string toNum = String.Empty;
			if (fromNum == "") {
				while (index < maxIndex && !items[++index].StartsWith("TEL:"))
					;
				//index++;
				//To number line
				toNum = items[index].Substring(4);
			}

			//find line starting with Date:
			while (index < maxIndex && !items[index].StartsWith("Date:"))
				index++;

			//Date line
			DateTime dt = DateTime.Parse(items[index].Substring(5));

			//Message line
			string message = items[++index];
			string tmp = items[++index];
			while (index + 1 < maxIndex && tmp != null && !tmp.StartsWith("END"))//checking for multi line messages
			{
				message += Environment.NewLine + tmp;
				tmp = items[++index];
			}
			IMessage result = new Message(message, fromNum, toNum, dt);

			return result;
		}

		public IMessage Parse(string line)
		{
			string[] strings = line.Split(new[] { '\r', '\n', });

			IMessage result = Parse(strings);

			return result;
		}
	}
}