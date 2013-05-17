using System.Collections.Generic;

namespace MessageClassLibrary.TextMessages
{
	/// <summary>Text Message provider.</summary>
	public class TextMessageProvider : IMessageProvider
	{
		#region Fields
		/// <summary>The messages</summary>
		private IEnumerable<IMessage> messages;

		/// <summary>The message reader</summary>
		private readonly IMessageReader textMessageReader;
		#endregion

		#region Properties
		/// <summary>Gets or sets the path to the message file.</summary>
		private string Path { get; set; }

		/// <summary>Gets the messages.</summary>
		public IEnumerable<IMessage> Messages
		{
			get { return messages ?? (messages = CreateTextMessages(Path)); }
		}

		/// <summary>Gets the name of the provider.</summary>
		public string Name { get; private set; } 
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="TextMessageProvider"/> class.</summary>
		/// <param name="name">The name.</param>
		/// <param name="path">The path.</param>
		/// <param name="format">The message format.</param>
		public TextMessageProvider(string name, string path, MessageFormat format)
		{
			Name = name;
			Path = path;
			MessageFormat messageFormat = format;
			IMessageParser messageParser = messageFormat == MessageFormat.Motorola ? (IMessageParser) new MotorolaTextMessageParser() : new NokiaTextMessageParser();
			textMessageReader = new TextMessageReader { MessageParser = messageParser };
		} 
		#endregion

		#region Non-Public Methods
		/// <summary>Creates the text messages.</summary>
		/// <param name="path">The path.</param>
		/// <returns>Messages create from the files in the given path directory.</returns>
		private IEnumerable<IMessage> CreateTextMessages(string path)
		{
			IEnumerable<IMessage> result = textMessageReader.ReadTextMessages(path);

			return result;
		} 
		#endregion
	}
}