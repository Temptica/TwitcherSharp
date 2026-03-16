using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserMessage;

public partial class TwitchChannelSuspiciousUserMessageCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSuspiciousUserMessageCondition>
{
    public string Name => nameof(TwitchChannelSuspiciousUserMessageCondition);

    /// <summary> 
    /// The ID of a user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// User ID of the channel to receive chat message events for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSuspiciousUserMessageCondition object.
    /// </summary> 
    public static TwitchChannelSuspiciousUserMessageCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSuspiciousUserMessageCondition
        {
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
