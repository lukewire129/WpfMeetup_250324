using System;
using System.Threading.Tasks;
using ably_ChatMessage.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ably_ChatMessage.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly AblyTokenService _tokenService;
    private readonly AblyRealtimeService _ablyService;
    [ObservableProperty] private string id = "user1@bmw.net";
    [ObservableProperty] private string password ="password1";

    public LoginViewModel(AblyTokenService tokenService, 
                          AblyRealtimeService ablyService)
    {
        _tokenService = tokenService;
        _ablyService = ablyService;
    }
    [RelayCommand]
    private async Task Login()
    {
        if (String.IsNullOrWhiteSpace(id) || String.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("아이디 패스워드");
            return;
        }

        try
        {
            var loginResponse = await _tokenService.LoginAsync(id, password);
            await _ablyService.InitializeAsync(loginResponse.User.UserId);
            WeakReferenceMessenger.Default.Send(new Login()
            {
                logIn = true,
                Id = id
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}