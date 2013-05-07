using System.Windows;
using System.Windows.Controls;
using MessageViewer.ViewModels;

namespace MessageViewer.Views
{
	/// <summary>
	/// Interaction logic for CompositeMessagesView.xaml
	/// </summary>
	public partial class CompositeMessagesView : UserControl
	{
		public CompositeMessagesView()
		{
			InitializeComponent();
		}

		private void TreeViewItem_OnSelected(object sender, RoutedEventArgs e)
		{
			CompositeMessagesViewModel messagesViewModel = DataContext as CompositeMessagesViewModel;
			messagesViewModel.CurrentProvider = ((TreeView) sender).SelectedItem as MessagesViewModel;
		}
	}
}
