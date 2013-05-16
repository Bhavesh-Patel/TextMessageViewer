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

			IMessageProvider textMessageProvider = new TextMessageRecursiveProvider("Nokia 6230", @"..\..\..\Resources\Messages\6230", MessageFormat.Nokia);
			IMessageProvider textMessageProvider2 = new TextMessageRecursiveProvider("Motorola V3i", @"..\..\..\Resources\Messages\V3i", MessageFormat.Motorola);
			IMessageProvider textMessageProvider3 = new TextMessageProvider("Nokia N91", @"..\..\..\Resources\Messages\N91\Inbox", MessageFormat.Nokia);
			CompositeMessageProvider compositeMessageProvider = new CompositeMessageProvider("All", textMessageProvider, textMessageProvider2, textMessageProvider3);
			messagesView.DataContext = new CompositeMessagesViewModel(compositeMessageProvider);
		}
	}
}