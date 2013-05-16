using System.Collections.Generic;
using System.Linq;
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

			Dictionary<string, MessageFormat> messageSources = new Dictionary<string, MessageFormat> {
				{"6230", MessageFormat.Nokia},
				{"7110e", MessageFormat.Nokia},
				{"7250i", MessageFormat.Nokia},
				{"7600", MessageFormat.Nokia},
				{"8310i", MessageFormat.Nokia},
				{"N91", MessageFormat.Nokia},
				{"V3i", MessageFormat.Motorola},
				//{"Written Archive", MessageFormat.Nokia},
			};

			IEnumerable<IMessageProvider> textMessageRecursiveProviders =
				messageSources.Select(
					kvp =>
						new TextMessageRecursiveProvider(kvp.Key + " " + kvp.Value.ToString(), @"..\..\..\Resources\Messages\" + kvp.Key,
							kvp.Value));
			CompositeMessageProvider compositeMessageProvider = new CompositeMessageProvider("Messages", textMessageRecursiveProviders.ToArray());
			messagesView.DataContext = new CompositeMessagesViewModel(compositeMessageProvider);
		}
	}
}