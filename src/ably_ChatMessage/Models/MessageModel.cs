using System;

namespace ably_ChatMessage.Models;

public class MessageModel
{
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime Time { get; set; }
}

public class MeMessageModel :MessageModel
{
    
}
public class YouMessageModel :MessageModel
{
    
}
