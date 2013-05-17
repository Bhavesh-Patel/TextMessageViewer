using System.Collections.Generic;
using System.Linq;

namespace MessageClassLibrary
{
	/// <summary>A composite message provider.</summary>
	public class CompositeMessageProvider : IMessageProvider
	{
		#region Properties
		/// <summary>Gets the messages.</summary>
		public IEnumerable<IMessage> Messages
		{
			get
			{
				IEnumerable<IMessage> result = CreateMessages();
				return result;
			}
		}

		/// <summary>Gets the name of the provider.</summary>
		public string Name { get; private set; }

		/// <summary>Gets the providers.</summary>
		public IEnumerable<IMessageProvider> Providers { get; private set; }
		#endregion

		#region Constructors
		public CompositeMessageProvider(string name, params IMessageProvider[] providers)
		{
			Name = name;
			Providers = providers;
		} 
		#endregion

		#region Public Methods
		/// <summary>Adds the specified provider.</summary>
		/// <param name="provider">The provider.</param>
		public void Add(IMessageProvider provider)
		{
			AddRange(new[] { provider });
		}

		/// <summary>Adds the elements of the specified collection.</summary>
		/// <param name="providers">The providers.</param>
		public void AddRange(IEnumerable<IMessageProvider> providers)
		{
			Providers = Providers.Union(providers);
		} 
		#endregion

		#region Non-Public Methods
		/// <summary>Creates the messages.</summary>
		/// <returns>Messages from all providers.</returns>
		private IEnumerable<IMessage> CreateMessages()
		{
			IEnumerable<IMessage> result = Providers.SelectMany(p => p.Messages);
			return result;
		} 
		#endregion
	}
}
