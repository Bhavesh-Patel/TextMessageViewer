using System;
using System.Collections.Generic;
using System.Text;

namespace TextMessageViewer
{
	class MobilePhone : MessageFolder
	{
		#region Fields
		protected MessageFormat format;

		private string path;

		public string Path
		{
			get { return path; }
		}
	
		#endregion

		#region Public Properties
		public MessageFormat Format
		{
			get { return format; }
		}
		#endregion

		#region Constructors
		public MobilePhone(string _name, MessageFormat _format, string _path)
			: base(_name)
		{
			format = _format;
			path = _path;
		}
		#endregion

		#region Public Methods
		public override string RetrievePath()
		{
			return path + "\\" + name + "\\";
		}

		public List<TextMessage> RetrieveAllMessages()
		{
			List<TextMessage> result = new List<TextMessage>();
			foreach (MessageFolder folder in folders) {
				result.AddRange(folder.Messages);
			}

			return result;
		}
		#endregion
	}
}
