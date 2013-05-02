using System.Windows;
using MessageClassLibrary.TextMessages;
using MessageViewer.ViewModels;

namespace MessageViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			messagesView.DataContext = new MessagesViewModel(@"..\..\..\Messages\V3i\Inbox", MessageFormat.Motorola);
		}
	}
}