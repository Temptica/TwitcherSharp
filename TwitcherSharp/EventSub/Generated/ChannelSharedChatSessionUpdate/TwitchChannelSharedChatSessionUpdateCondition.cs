using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionUpdate;

public partial class TwitchChannelSharedChatSessionUpdateCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSharedChatSessionUpdateCondition>
{
    public string Name => nameof(TwitchChannelSharedChatSessionUpdateCondition);

    /// <summary> 
    /// The User ID of the channel to receive shared chat session update events for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionUpdateCondition object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSharedChatSessionUpdateCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_update.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSharedChatSessionUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSharedChatSessionUpdateCondition
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
