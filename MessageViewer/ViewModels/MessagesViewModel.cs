using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MessageClassLibrary;

namespace MessageViewer.ViewModels
{
	/// <summary>ViewModel for messages.</summary>
	public class MessagesViewModel
	{
		#region Properties
		/// <summary>Gets the provider.</summary>
		public IMessageProvider Provider { get; private set; }

		/// <summary>Gets or sets the messages.</summary>
		public ObservableCollection<MessageViewModel> Messages { get; set; }

		/// <summary>Gets or sets the current message.</summary>
		public MessageViewModel CurrentMessage { get; set; }

		/// <summary>Gets the name.</summary>
		public string Name { get { return Provider == null ? "<NO NAME>" : Provider.Name; } } 
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="MessagesViewModel"/> class.</summary>
		/// <remarks>This constructor is primarily for the XAML design views.</remarks>
		public MessagesViewModel()
		{
			Messages = new ObservableCollection<MessageViewModel>();
			for (int i = 0; i < 5; i++) {
				MessageViewModel messageViewModel = new MessageViewModel(new Message("Message" + i, "From" + i, "To" + i, DateTime.Now));
				Messages.Add(messageViewModel);
			}
			CurrentMessage = Messages.First();
		}

		/// <summary>Initializes a new instance of the <see cref="MessagesViewModel"/> class.</summary>
		/// <param name="provider">The provider.</param>
		public MessagesViewModel(IMessageProvider provider)
		{
			this.Provider = provider;
			CreateMessageViewModels();
		} 
		#endregion

		#region Non-Public Methods
		/// <summary>Creates the message view models using the messages from the provider.</summary>
		private void CreateMessageViewModels()
		{
			IEnumerable<IMessage> messages = Provider.Messages;

			IEnumerable<MessageViewModel> messageViewModels =
				messages.OrderBy(t => t.DateTime).Select(t => new MessageViewModel(t));
			Messages = new ObservableCollection<MessageViewModel>(messageViewModels);
		} 
		#endregion
	}
}
