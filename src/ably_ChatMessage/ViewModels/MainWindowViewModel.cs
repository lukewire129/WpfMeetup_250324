using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace ably_ChatMessage.ViewModels;

public class Login
{
    public bool logIn { get; set; } = true; // true : log In, false ; log Out
    public string Id { get; set; }
}
public partial class MainWindowViewModel : ViewModelBase
{
    private readonly LoginViewModel _loginViewModel;
    private readonly ChannelViewModel _channelViewModel;
    private readonly ChannelRoomViewModel _channelRoomViewModel;
    [ObservableProperty] private ViewModelBase contentView;

    private Login _login;
    public MainWindowViewModel(LoginViewModel loginViewModel,
                               ChannelViewModel channelViewModel,
                               ChannelRoomViewModel channelRoomViewModel)
    {
        _loginViewModel = loginViewModel;
        _channelViewModel = channelViewModel;
        _channelRoomViewModel = channelRoomViewModel;
        ContentView = _loginViewModel;
        WeakReferenceMessenger.Default.Register<Login>(this, (recipient, message) =>
        {
            if (message.logIn == false)
            {
                _login = null;
                this.ContentView = _loginViewModel;
                return;
            }
            _login = message;
            
            this.ContentView  = _channelViewModel;
        });

        WeakReferenceMessenger.Default.Register<ChannelInfo>(this, async (recipient,message) =>
        {
            await _channelRoomViewModel.Load(_login, message);
            this.ContentView  = _channelRoomViewModel;
        });
    }
}