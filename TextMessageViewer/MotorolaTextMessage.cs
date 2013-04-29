using System;
using System.Collections.Generic;
using System.Text;

namespace TextMessageViewer
{
	/// <summary>Representation of a Motorola text message.</summary>
	class MotorolaTextMessage : TextMessage
	{
		/// <summary>Gets the format of this message.</summary>
		public override MessageFormat Format
		{
			get { return MessageFormat.Motorola; }
		}

		/// <summary>Initializes a new instance of the <see cref="MotorolaTextMessage"/> class.</summary>
		/// <param name="_message">The message.</param>
		/// <param name="fromNumber">The number.</param>
		/// <param name="_dateTime">The date time.</param>
		/// <param name="_sentOrRecieved">The sent or recieved status.</param>
		/// <param name="_filePath">Path of the file.</param>
		public MotorolaTextMessage(string _message, string fromNumber, DateTime _dateTime, MessageStatus _sentOrRecieved, string _filePath)
			:base(_message, fromNumber, null, _dateTime, _sentOrRecieved, _filePath)
		{
		}
	}
}
