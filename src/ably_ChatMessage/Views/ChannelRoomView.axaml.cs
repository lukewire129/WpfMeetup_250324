using System.Collections.Specialized;
using ably_ChatMessage.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ably_ChatMessage.Views;

public partial class ChannelRoomView : UserControl
{
    public ChannelRoomView()
    {
        InitializeComponent();
        this.Loaded += (sender, args) =>
        {
            ((ChannelRoomViewModel)this.DataContext).Messages.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Viewer.ScrollToEnd();
                }
            };
        };
    }
}