using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserUpdate;

public partial class TwitchChannelSuspiciousUserUpdateCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSuspiciousUserUpdateCondition>
{
    public string Name => nameof(TwitchChannelSuspiciousUserUpdateCondition);

    /// <summary> 
    /// The ID of a user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The broadcaster you want to get chat unban request notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSuspiciousUserUpdateCondition object.
    /// </summary> 
    public static TwitchChannelSuspiciousUserUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSuspiciousUserUpdateCondition
        {
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_update.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSuspiciousUserUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSuspiciousUserUpdateCondition
        {
            ModeratorUserId = data["moderator_user_id"].AsString(),
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"moderator_user_id", ModeratorUserId},
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
