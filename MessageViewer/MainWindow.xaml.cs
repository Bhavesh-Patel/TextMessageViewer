using System.Windows;
using MessageClassLibrary;
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

			IMessageProvider textMessageProvider = new TextMessageRecursiveProvider("Nokia 6230", @"..\..\..\Messages\6230", MessageFormat.Nokia);
			IMessageProvider textMessageProvider2 = new TextMessageRecursiveProvider("Motorola V3i", @"..\..\..\Messages\V3i", MessageFormat.Motorola);
			IMessageProvider textMessageProvider3 = new TextMessageProvider("Nokia N91", @"..\..\..\Messages\N91\Inbox", MessageFormat.Nokia);
			messagesView.DataContext = new CompositeMessagesViewModel(new[] { textMessageProvider, textMessageProvider2, textMessageProvider3 });
		}
	}
}