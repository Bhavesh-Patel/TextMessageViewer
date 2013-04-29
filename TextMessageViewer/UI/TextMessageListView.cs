using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Bhavesh.Utilities;
using MessageClassLibrary.TextMessages;

namespace TextMessageViewer
{
	/// <summary>A ListView containg <see cref="TextMessageListViewItem"/>s, used to display a collection of <see cref="TextMessage"/>s.</summary>
	public partial class TextMessageListView : ListView
	{
		#region Events
		/// <summary>Occurs when text message list view item updated.</summary>
		public event EventHandler<AfterTextMessageItemUpdateEventArgs> AfterTextMessageItemUpdate; 
		#endregion

		#region Fields
		/// <summary>List view sorter.</summary>
		private DateTimeListViewColumnSorter lvwColumnSorter; 
		#endregion

		#region Construtors
		/// <summary>Initializes a new instance of the <see cref="TextMessageListView"/> class.</summary>
		public TextMessageListView()
		{
			InitializeComponent();
			SetupListViewSorter();
		}

		/// <summary>Initializes a new instance of the <see cref="TextMessageListView"/> class.</summary>
		/// <param name="container">The container.</param>
		public TextMessageListView(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
			SetupListViewSorter();
		} 
		#endregion

		#region Public Methods
		/// <summary>Presents form to edit and then update the currently selected text message within the ListView.</summary>
		/// <returns>True, when changes are committed, false, otherwise.</returns>
		public bool EditTextMessage()
		{
			bool result = false;
			if (SelectedItems.Count > 0) {
				TextMessageListViewItem lvi = SelectedItems[0] as TextMessageListViewItem;
				TextMessage message = lvi.Message;
				string filePath = message.FilePath;
				NewEditMessage form = new NewEditMessage(message);

				if (form.ShowDialog(this) != DialogResult.Cancel) {
					TextMessageListViewItem lvi2 = new TextMessageListViewItem(form.Message);
					Items.Insert(lvi.Index, lvi2);
					lvi.Remove();
					Sort();
					result = true;
					AfterTextMessageItemUpdateEventArgs args = new AfterTextMessageItemUpdateEventArgs(lvi, lvi2);
					OnAfterTextMessageItemUpdate(args);
				}
			}
			return result;
		}

		#endregion

		#region Non-Public Methods
		/// <summary>Setups the list view sorter.</summary>
		/// <remarks>Uses the indexes of the date and time columns to initialise a <see cref="DateTimeListViewColumnSorter"/>.</remarks>
		private void SetupListViewSorter()
		{
			lvwColumnSorter = new DateTimeListViewColumnSorter(colHDate.Index, colHTime.Index);
			ListViewItemSorter = lvwColumnSorter;
		}

		/// <summary>Starts to edit the activated TextMessage.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TextMessageListView_ItemActivate(object sender, EventArgs e)
		{
			EditTextMessage();
		}

		/// <summary>Sorts the list view.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.ColumnClickEventArgs"/> instance containing the event data.</param>
		private void TextMessageListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListViewColumnSorter.SortListView(this, e.Column);
		}

		/// <summary>Raises the <see cref="E:AfterTextMessageItemUpdate"/> event.</summary>
		/// <param name="e">The <see cref="TextMessageViewer.AfterTextMessageItemUpdateEventArgs"/> instance containing the event data.</param>
		protected virtual void OnAfterTextMessageItemUpdate(AfterTextMessageItemUpdateEventArgs e)
		{
			if (AfterTextMessageItemUpdate != null) {
				AfterTextMessageItemUpdate(this, e);
			}
		} 
		#endregion
	}

	/// <summary>Event argument after a <see cref="TextMessageListViewItem"/>, containing the old item and the new item.</summary>
	public class AfterTextMessageItemUpdateEventArgs : EventArgs
	{
		/// <summary>Old, un-editted ListViewItem.</summary>
		private ListViewItem oldItem;

		/// <summary>New, editted ListViewItem.</summary>
		private ListViewItem newItem;

		/// <summary>Gets the old, un-editted ListViewItem.</summary>
		public ListViewItem OldItem
		{
			get { return oldItem; }
		}

		/// <summary>Gets the new, editted ListViewItem.</summary>
		public ListViewItem NewItem
		{
			get { return newItem; }
		}

		/// <summary>Initializes a new instance of the <see cref="AfterTextMessageItemUpdateEventArgs"/> class.</summary>
		/// <param name="_oldItem">The old, un-editted ListViewItem.</param>
		/// <param name="_newItem">The new, editted ListViewItem.</param>
		public AfterTextMessageItemUpdateEventArgs(ListViewItem _oldItem, ListViewItem _newItem)
			: base()
		{
			oldItem = _oldItem;
			newItem = _newItem;
		}
	}
}
