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

			TextMessageProvider textMessageProvider = new TextMessageRecursiveProvider(@"..\..\..\Messages\6230", MessageFormat.Nokia);
			messagesView.DataContext = new MessagesViewModel(textMessageProvider);
		}
	}
}