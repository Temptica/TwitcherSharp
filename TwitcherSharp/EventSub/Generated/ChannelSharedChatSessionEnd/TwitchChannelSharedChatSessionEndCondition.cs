using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionEnd;

public partial class TwitchChannelSharedChatSessionEndCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSharedChatSessionEndCondition>
{
    public string Name => nameof(TwitchChannelSharedChatSessionEndCondition);

    /// <summary> 
    /// The User ID of the channel to receive shared chat session end events for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionEndCondition object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionEndCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSharedChatSessionEndCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_end.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSharedChatSessionEndCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSharedChatSessionEndCondition
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
