using System;

namespace MessageClassLibrary
{
	public class Message : IMessage
	{
		public string MessageText { get; private set; }

		public string From { get; private set; }

		public string To { get; private set; }

		public DateTime DateTime { get; private set; }

		public Message(string message, string from, string to, DateTime dateTime)
		{
			if (message == null) {
				throw new ArgumentNullException("message");
			}
			if (from == null && to == null) {
				throw new InvalidOperationException("from and to can't both be null");
			}
			MessageText = message;
			From = @from;
			To = to;
			DateTime = dateTime;
		}

		// override object.Equals
		public bool Equals(IMessage other)
		{
			bool result = other.DateTime == DateTime && other.From == From && other.To == To
				&& other.MessageText == MessageText;

			return result;
		}

		public override bool Equals(object obj)
		{
			//       
			// See the full list of guidelines at
			//   http://go.microsoft.com/fwlink/?LinkID=85237  
			// and also the guidance for operator== at
			//   http://go.microsoft.com/fwlink/?LinkId=85238
			//

			bool result = false;
			if (obj == null || GetType() != obj.GetType()) {
				result = false;
			} else {
				// TODO: write your implementation of Equals() here
				IMessage other = obj as IMessage;
				result = Equals(other);
			}

			return result;
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			string hashString = MessageText + From + To + DateTime.ToString();
			int result = hashString.GetHashCode();

			return result;
		}
	}
}