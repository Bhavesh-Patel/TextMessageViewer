using System;
using System.Collections.Generic;
using System.Text;

namespace TextMessageViewer
{
	/// <summary>Representation of a Nokia text message.</summary>
	class NokiaTextMessage: TextMessage
	{
		/// <summary>Gets the format of this message.</summary>
		public override MessageFormat Format
		{
			get { return MessageFormat.Nokia; }
		}

		/// <summary>Initializes a new instance of the <see cref="NokiaTextMessage"/> class.</summary>
		/// <param name="_message">The message.</param>
		/// <param name="fromNumber">The from number.</param>
		/// <param name="toNumber">The to number.</param>
		/// <param name="_dateTime">The date time.</param>
		/// <param name="_sentOrRecieved">The sent or recieved status.</param>
		/// <param name="_filePath">Path of the file.</param>
		public NokiaTextMessage(string _message, string fromNumber, string toNumber, DateTime _dateTime, MessageStatus _sentOrRecieved, string _filePath)
			: base(_message, fromNumber, toNumber, _dateTime, _sentOrRecieved, _filePath)
		{
		}
	}
}
