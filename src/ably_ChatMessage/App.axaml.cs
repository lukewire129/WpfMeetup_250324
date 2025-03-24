using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using ably_ChatMessage.Services;
using Avalonia.Markup.Xaml;
using ably_ChatMessage.ViewModels;
using ably_ChatMessage.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ably_ChatMessage;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var serviceProvider = BuildDiContainer();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Create and show MainWindow, passing the DI container as a parameter
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            var mainWindowViewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
    
    private ServiceProvider BuildDiContainer()
    {
        var services = new ServiceCollection();

        // Register services
        services.AddSingleton<MainWindow>();
        // Register ViewModels and other dependencies
        
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<ChannelViewModel>();
        services.AddSingleton<ChannelRoomViewModel>();
        
        services.AddSingleton<AblyRealtimeService>();
        string apiBaseUrl = "https://yog880ks0gossskc4w0css44.jojangwon.com";
        services.AddSingleton(new AblyTokenService(apiBaseUrl));

        return services.BuildServiceProvider();
    }
}