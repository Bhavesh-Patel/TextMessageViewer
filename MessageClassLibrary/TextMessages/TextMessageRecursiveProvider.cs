using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemPath = System.IO.Path;

namespace MessageClassLibrary.TextMessages
{
	/// <summary>Recursive folder Text Message provider.</summary>
	/// <remarks>Creates a message provider for each of the directories within folder path.</remarks>
	public class TextMessageRecursiveProvider : CompositeMessageProvider
	{
		#region Properties
		/// <summary>Gets or sets the top most directory path.</summary>
		private string Path { get; set; }

		/// <summary>Gets or sets the message format.</summary>
		private MessageFormat Format { get; set; } 
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="TextMessageRecursiveProvider"/> class.</summary>
		/// <param name="name">The name.</param>
		/// <param name="path">The directory path.</param>
		/// <param name="format">The format.</param>
		public TextMessageRecursiveProvider(string name, string path, MessageFormat format)
			: base(name)
		{
			Path = path;
			Format = format;
			CreateProviders(Path);
		} 
		#endregion

		#region Non-Public Methods
		/// <summary>Creates the providers for each of the subfolders of path.</summary>
		/// <param name="path">The path.</param>
		private void CreateProviders(string path)
		{
			IEnumerable<string> directories = Directory.GetDirectories(path);
			IEnumerable<TextMessageProvider> textMessageProviders =
				directories.Select(directory => new TextMessageProvider(SystemPath.GetFileName(directory), directory, Format));
			AddRange(textMessageProviders);
		} 
		#endregion
	}
}
