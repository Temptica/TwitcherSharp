using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatNotification;

public partial class TwitchChannelChatNotificationCondition(string broadcasterUserId, string userId) : RefCounted, ITwitcherSharpCondition<TwitchChannelChatNotificationCondition>
{
    public string Name => nameof(TwitchChannelChatNotificationCondition);

    /// <summary> 
    /// User ID of the channel to receive chat notification events for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The user ID to read chat as.
    /// </summary>
    public string UserId { get; set; } = userId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatNotificationCondition object.
    /// </summary> 
    public static TwitchChannelChatNotificationCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelChatNotificationCondition(data.Get("broadcaster_user_id").AsString(), data.Get("user_id").AsString());
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("user_id", UserId);
        return request;
    }

    public static TwitchChannelChatNotificationCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelChatNotificationCondition(data["broadcaster_user_id"].AsString(), data["user_id"].AsString())
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
