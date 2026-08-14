using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatClear;

public partial class TwitchChannelChatClearCondition(string broadcasterUserId, string userId) : RefCounted, ITwitcherSharpCondition<TwitchChannelChatClearCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelChatClearCondition);

    /// <summary> 
    /// User ID of the channel to receive chat clear events for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The user ID to read chat as.
    /// </summary>
    public string UserId { get; set; } = userId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatClearCondition object.
    /// </summary> 
    public static TwitchChannelChatClearCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatClearCondition(data.Get("broadcaster_user_id").AsString(), data.Get("user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_clear.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("user_id", UserId);
        return request;
    }

    public static TwitchChannelChatClearCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelChatClearCondition(data["broadcaster_user_id"].AsString(), data["user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
            {"user_id", UserId},
        };
    }
}
