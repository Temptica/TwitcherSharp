using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatSettingsUpdate;

public partial class TwitchChannelChatSettingsUpdateCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelChatSettingsUpdateCondition>
{
    public string Name => nameof(TwitchChannelChatSettingsUpdateCondition);

    /// <summary> 
    /// User ID of the channel to receive chat settings update events for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The user ID to read chat as.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatSettingsUpdateCondition object.
    /// </summary> 
    public static TwitchChannelChatSettingsUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelChatSettingsUpdateCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            UserId = data.Get("user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_settings_update.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("user_id", UserId);
        return request;
    }

    public static TwitchChannelChatSettingsUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelChatSettingsUpdateCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
            UserId = data["user_id"].AsString(),
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
