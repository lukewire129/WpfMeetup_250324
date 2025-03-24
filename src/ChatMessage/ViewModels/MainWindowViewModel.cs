using System;
using System.Collections.ObjectModel;
using ChatMessage.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatMessage.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<MessageModel> messages;
    public MainWindowViewModel()
    {
        this.Messages = new();

        DateTime dt = DateTime.Now; 
        this.Messages.Add(new MeMessageModel()
        {
            Name = "Jack Raymonds",
            Text = "Hey Grace, how`s it going?",
            Time = dt
        });
        this.Messages.Add(new YouMessageModel()
        {
            Name = "Grace Miller",
            Text = "Hi Jack! I'm doing well, thanks. Can't wait for the weekend!",
            Time = dt
        });
        this.Messages.Add(new MeMessageModel()
        {
            Name = "Jack Raymonds",
            Text = "I know, right? Weekend plans are the best. Anyexciting plans on your end?",
            Time = dt
        });
        this.Messages.Add(new YouMessageModel()
        {
            Name = "Grace Miller",
            Text = "Absolutely! I'm thinking of going for a hike on Saturday. How about you?",
            Time = dt
        });
        this.Messages.Add(new MeMessageModel()
        {
            Name = "Jack Raymonds",
            Text = "Hiking sounds amazing! I might catch up on some reading and also meet up with a fewfriends on Sunday.",
            Time = dt
        });
        this.Messages.Add(new YouMessageModel()
        {
            Name = "Grace Miller",
            Text = "That sounds like a great plan! Excited \ud83d\ude03",
            Time = dt
        });
        this.Messages.Add(new MeMessageModel()
        {
            Name = "Jack Raymonds",
            Text = "Can't wait for the weekend!",
            Time = dt
        });
    }
}