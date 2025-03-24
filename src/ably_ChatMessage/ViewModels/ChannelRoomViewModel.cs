using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ably_ChatMessage.Models;
using ably_ChatMessage.Services;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IO.Ably;

namespace ably_ChatMessage.ViewModels;

public partial class ChannelRoomViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<MessageModel> messages = new();
    [ObservableProperty] private string message;
    private readonly AblyRealtimeService _ablyService;

    public ChannelRoomViewModel(AblyRealtimeService ablyService)
    {
        _ablyService = ablyService;
    }

    private ChannelInfo _channelInfo;
    private Login _login;
    public async Task Load(Login login, ChannelInfo channelInfo)
    {
        _login = login;
        _channelInfo = channelInfo;
        var channelName = channelInfo.Name;
        var useRewind = channelInfo.UseRewind;
        var useHistory = channelInfo.UseHistory;
        
        var channel = _ablyService.SubscribeToChannel(channelName, useRewind, "1");

        if (useHistory)
        {
            var resultPage = await channel.HistoryAsync(new PaginatedRequestParams { Direction = QueryDirection.Forwards });
            foreach (var message in resultPage.Items)
            {
                if (_login.Id == message.ClientId)
                {
                    this.Messages.Add(new MeMessageModel()
                    {
                        Name = message.ClientId,
                        Text = (string)message.Data,
                        Time = message.Timestamp.Value.DateTime,
                    });
                    continue;
                }
                this.Messages.Add(new YouMessageModel()
                {
                    Name = message.ClientId,
                    Text = (string)message.Data,
                    Time = message.Timestamp.Value.DateTime,
                });
            }
        }

        _ablyService.MessageReceived -= OnMessageReceived; // 기존 핸들러 제거
        _ablyService.MessageReceived += OnMessageReceived; // 새로 핸들러 등록
    }
    
    private void OnMessageReceived(string name, object data)
    {
        if (name != "message")
            return;
        var messageModel = (MessageModel)data;
        Dispatcher.UIThread.Invoke(() =>
        {
            if (_login.Id == messageModel.Name)
            {
                this.Messages.Add(new MeMessageModel()
                {
                    Name = messageModel.Name,
                    Text = messageModel.Text,
                    Time = messageModel.Time
                });
                return;
            }
            this.Messages.Add(new YouMessageModel()
            {
                Name = messageModel.Name,
                Text = messageModel.Text,
                Time = messageModel.Time
            });
        });
    }

    [RelayCommand]
    private async Task Send()
    {
        await _ablyService.PublishMessageAsync("message", Message);
        Message = null;
    }
}