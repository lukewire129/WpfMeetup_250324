using System;
using Avalonia.Media.Imaging;

namespace ChatMessage.Models;

public class MessageModel
{
    public string Text { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public Bitmap Profile { get; set; }
}

public class MeMessageModel : MessageModel
{
    public MeMessageModel()
    {
        var uri = new Uri($"avares://ChatMessage/Assets/me.png");
        Profile = new Bitmap(Avalonia.Platform.AssetLoader.Open(uri));
    }
}
public class YouMessageModel : MessageModel
{
    public YouMessageModel()
    {
        var uri = new Uri($"avares://ChatMessage/Assets/you.png");
        Profile = new Bitmap(Avalonia.Platform.AssetLoader.Open(uri));
    }
}