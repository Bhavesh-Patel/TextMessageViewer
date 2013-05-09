using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MessageClassLibrary;

namespace MessageViewer.ViewModels
{
	public class CompositeMessagesViewModel : MessagesViewModel, INotifyPropertyChanged
	{
		private MessagesViewModel currentProvider;

		public IEnumerable<MessagesViewModel> MessageProviders { get; set; }

		public MessagesViewModel CurrentProvider
		{
			get { return currentProvider; }
			set
			{
				currentProvider = value;
				OnPropertyChanged();
			}
		}

		public CompositeMessagesViewModel()
		{
			MessageProviders = new[] { new MessagesViewModel(), new MessagesViewModel() };
		}

		public CompositeMessagesViewModel(CompositeMessageProvider provider)
			: base(provider)
		{
			MessageProviders = provider.Providers.Select(mp =>
				mp is CompositeMessageProvider
					? (MessagesViewModel) new CompositeMessagesViewModel(mp as CompositeMessageProvider)
					: new MessagesViewModel(mp));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
