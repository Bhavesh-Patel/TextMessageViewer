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
			messagesView.DataContext = new MessagesViewModel(textMessageProvider);
		}
	}
}