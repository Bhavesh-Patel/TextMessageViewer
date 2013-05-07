﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MessageClassLibrary;

namespace MessageViewer.ViewModels
{
	public class MessagesViewModel
	{
		public IMessageProvider Provider { get; private set; }

		public ObservableCollection<MessageViewModel> Messages { get; set; }

		public MessageViewModel CurrentMessage { get; set; }

		public string Name { get { return Provider == null ? "<NO NAME>" : Provider.Name; } }

		public MessagesViewModel()
		{
			Messages = new ObservableCollection<MessageViewModel>();
			for (int i = 0; i < 5; i++) {
				MessageViewModel messageViewModel = new MessageViewModel(new Message("Message" + i, "From" + i, "To" + i, DateTime.Now));
				Messages.Add(messageViewModel);
			}
			CurrentMessage = Messages.First();
		}

		public MessagesViewModel(IMessageProvider provider)
		{
			this.Provider = provider;
			CreateMessageViewModels();
		}

		private void CreateMessageViewModels()
		{
			IEnumerable<IMessage> messages = Provider.Messages;

			IEnumerable<MessageViewModel> messageViewModels =
				messages.OrderBy(t => t.DateTime).Select(t => new MessageViewModel(t));
			Messages = new ObservableCollection<MessageViewModel>(messageViewModels);
		}
	}
}
