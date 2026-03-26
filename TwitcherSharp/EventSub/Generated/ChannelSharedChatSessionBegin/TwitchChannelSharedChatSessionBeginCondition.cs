using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionBegin;

public partial class TwitchChannelSharedChatSessionBeginCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSharedChatSessionBeginCondition>
{
    public string Name => nameof(TwitchChannelSharedChatSessionBeginCondition);

    /// <summary> 
    /// The User ID of the channel to receive shared chat session begin events for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionBeginCondition object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSharedChatSessionBeginCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_begin.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSharedChatSessionBeginCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSharedChatSessionBeginCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
