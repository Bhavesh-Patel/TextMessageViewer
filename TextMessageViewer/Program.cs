using System;
using System.Windows.Forms;

namespace TextMessageViewer
{
	/// <summary>Summary description for Program.</summary>
	public class Program
	{
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new MainForm());
		}
	}
}
