using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MessageClassLibrary;

namespace MessageViewer.ViewModels
{
	/// <summary>ViewModel for multiple MessagesViewModels.</summary>
	public class CompositeMessagesViewModel : MessagesViewModel, INotifyPropertyChanged
	{
		#region Fields
		/// <summary>The current provider.</summary>
		private MessagesViewModel currentProvider; 
		#endregion

		#region Events
		/// <summary>Occurs when a property value changes.</summary>
		public event PropertyChangedEventHandler PropertyChanged; 
		#endregion

		#region Properties
		/// <summary>Gets the message providers.</summary>
		public IEnumerable<MessagesViewModel> MessageProviders { get; private set; }

		/// <summary>Gets or sets the current provider.</summary>
		public MessagesViewModel CurrentProvider
		{
			get { return currentProvider; }
			set
			{
				currentProvider = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="CompositeMessagesViewModel"/> class.</summary>
		/// <remarks>This constructor is primarily for the XAML design views.</remarks>
		public CompositeMessagesViewModel()
		{
			MessageProviders = new[] { new MessagesViewModel(), new MessagesViewModel() };
		}

		/// <summary>Initializes a new instance of the <see cref="CompositeMessagesViewModel"/> class.</summary>
		/// <param name="provider">The composite provider.</param>
		public CompositeMessagesViewModel(CompositeMessageProvider provider)
			: base(provider)
		{
			MessageProviders = provider.Providers.Select(mp =>
				mp is CompositeMessageProvider
					? (MessagesViewModel) new CompositeMessagesViewModel(mp as CompositeMessageProvider)
					: new MessagesViewModel(mp));
		} 
		#endregion

		#region Non-Public Methods
		/// <summary>Called when [property changed].</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <remarks><see cref="CallerMemberName"/> is applied to <paramref name="propertyName"/>, so it can be omitted.</remarks>
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		} 
		#endregion
	}
}
