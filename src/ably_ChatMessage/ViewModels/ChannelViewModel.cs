using System;
using System.Threading.Tasks;
using ably_ChatMessage.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using IO.Ably.Realtime;

namespace ably_ChatMessage.ViewModels;

public class ChannelInfo
{
    public string Name { get; set; }
    public bool UseRewind { get; set; } = false;
    public bool UseHistory { get; set; }= false;
}
public partial class ChannelViewModel : ViewModelBase
{
    private readonly AblyRealtimeService _ablyService;

    [ObservableProperty] private string channelName = "test-channel";
    [ObservableProperty] private bool useRewind;
    [ObservableProperty] private bool useHistory =true;

    public ChannelViewModel(AblyRealtimeService ablyService)
    {
        _ablyService = ablyService;
        _ablyService.ConnectionStateChanged += (state, reason) =>
        {
            if (state == ConnectionState.Failed || state == ConnectionState.Disconnected)
            {
                WeakReferenceMessenger.Default.Send(new Login()
                {
                    logIn = false
                });
            }
        };
        _ablyService.Connect();
    }

    [RelayCommand]
    private void ChannelEntry()
    {
        if (String.IsNullOrWhiteSpace(ChannelName))
        {
            return;
        }
        WeakReferenceMessenger.Default.Send(new ChannelInfo()
        {
            Name = ChannelName,
            UseRewind = UseRewind,
            UseHistory = UseHistory
        });
    }
}