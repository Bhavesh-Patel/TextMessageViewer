using System;

namespace MessageClassLibrary
{
	/// <summary>Basic message.</summary>
	public class Message : IMessage
	{
		#region Public Properties
		/// <summary>Gets the message text.</summary>
		public string MessageText { get; private set; }

		/// <summary>Gets the message origin.</summary>
		public string From { get; private set; }

		/// <summary>Gets the message target.</summary>
		public string To { get; private set; }

		/// <summary>Gets the date time of the message.</summary>
		public DateTime DateTime { get; private set; } 
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="Message"/> class.</summary>
		/// <param name="message">The message.</param>
		/// <param name="from">The From.</param>
		/// <param name="to">The To.</param>
		/// <param name="dateTime">The date and time of the message.</param>
		/// <exception cref="System.ArgumentNullException">message</exception>
		/// <exception cref="System.InvalidOperationException">from and to can't both be null</exception>
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
		#endregion

		#region Public Methods
		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(IMessage other)
		{
			bool result = other.DateTime == DateTime && other.From == From && other.To == To
				&& other.MessageText == MessageText;

			return result;
		}

		/// <summary>Determines whether the specified <see cref="System.Object" /> is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
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

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. </returns>
		public override int GetHashCode()
		{
			string hashString = MessageText + From + To + DateTime.ToString();
			int result = hashString.GetHashCode();

			return result;
		} 
		#endregion
	}
}