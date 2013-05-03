using System.Collections.Generic;
using System.Linq;

namespace MessageClassLibrary
{
	public class CompositeMessageProvider: IMessageProvider
	{
		public IEnumerable<IMessage> Messages
		{
			get
			{
				IEnumerable<IMessage> result = CreateMessages();
				return result;
			}
		}

		protected virtual IEnumerable<IMessage> CreateMessages()
		{
			IEnumerable<IMessage> result = Providers.SelectMany(p => p.Messages);
			return result;
		}

		protected IEnumerable<IMessageProvider> Providers { get; private set; }

		public CompositeMessageProvider(params IMessageProvider[] providers)
		{
			Providers = providers;
		}

		public void Add(IMessageProvider provider)
		{
			AddRange(new[] {provider});
		}

		public void AddRange(IEnumerable<IMessageProvider> providers)
		{
			Providers = Providers.Union(providers);
		}

	}
}
