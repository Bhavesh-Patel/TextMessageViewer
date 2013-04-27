using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace TextMessageViewer
{
	/// <summary>Enumeration of different formats.</summary>
	public enum MessageFormat
	{
		/// <summary>Messages from Nokia phones.</summary>
		[MessageNameFormat("", "vmg")]
		Nokia,
		/// <summary>Messages from Motorola phones.</summary>
		[MessageNameFormat("recu", "txt")]
		Motorola
	}

	/// <summary>Contains details of each format, including file type and default prefix.</summary>
	public sealed class MessageNameFormatAttribute : Attribute
	{
		#region Fields
		/// <summary>File prefix.</summary>
		private string filePrefix;

		/// <summary>File extention.</summary>
		private string fileExtention; 
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="MessageNameFormatAttribute"/> class.</summary>
		/// <param name="_filePrefix">The file prefix.</param>
		/// <param name="_fileExtention">The file extention.</param>
		public MessageNameFormatAttribute(string _filePrefix, string _fileExtention)
		{
			filePrefix = _filePrefix;
			fileExtention = _fileExtention;
		} 
		#endregion

		#region Static Fields
		/// <summary>Cache of MessageFormat to file extenision.</summary>
		private static Dictionary<MessageFormat, string> formatFileType = new Dictionary<MessageFormat, string>();
		/// <summary>Cache of MessageFormat to standard file prefix.</summary>
		private static Dictionary<MessageFormat, string> formatFilePrefix = new Dictionary<MessageFormat, string>(); 
		#endregion

		#region Static Methods
		/// <summary>Retrieves the file extention.</summary>
		/// <param name="format">The format.</param>
		/// <returns>The file extention.</returns>
		private static string RetrieveFileExtention(MessageFormat format)
		{
			string result;
			FieldInfo fieldInfo = format.GetType().GetField(format.ToString());
			if (!formatFileType.TryGetValue(format, out result)) {
				object[] attribArray = fieldInfo.GetCustomAttributes(typeof(MessageNameFormatAttribute), false);
				if (attribArray.Length != 0) {
					MessageNameFormatAttribute attrib = attribArray[0] as MessageNameFormatAttribute;
					result = attrib.fileExtention;
					formatFileType[format] = result;
				}
			}

			return result;
		}

		/// <summary>Retrieves the file prefix.</summary>
		/// <param name="format">The format.</param>
		/// <returns>The file prefix.</returns>
		private static string RetrieveFilePrefix(MessageFormat format)
		{
			string result;
			FieldInfo fieldInfo = format.GetType().GetField(format.ToString());
			if (!formatFilePrefix.TryGetValue(format, out result)) {
				object[] attribArray = fieldInfo.GetCustomAttributes(typeof(MessageNameFormatAttribute), false);
				if (attribArray.Length != 0) {
					MessageNameFormatAttribute attrib = attribArray[0] as MessageNameFormatAttribute;
					result = attrib.filePrefix;
					formatFilePrefix[format] = result;
				}
			}

			return result;
		}

		/// <summary>Format of file name.</summary>
		/// <param name="format">The format.</param>
		/// <returns>File format.</returns>
		public static string FileFormat(MessageFormat format)
		{
			string extention = MessageNameFormatAttribute.RetrieveFileExtention(format);
			string filePrefix = MessageNameFormatAttribute.RetrieveFilePrefix(format);
			return filePrefix + "*." + extention;
		} 
		#endregion
	}
}
