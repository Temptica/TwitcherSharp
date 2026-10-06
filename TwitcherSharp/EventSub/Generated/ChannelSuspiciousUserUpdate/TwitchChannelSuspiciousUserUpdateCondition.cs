using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserUpdate;

public partial class TwitchChannelSuspiciousUserUpdateCondition(string moderatorUserId, string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelSuspiciousUserUpdateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelSuspiciousUserUpdateCondition);

    /// <summary> 
    /// The ID of a user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// The broadcaster you want to get chat unban request notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSuspiciousUserUpdateCondition object.
    /// </summary> 
    public static TwitchChannelSuspiciousUserUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSuspiciousUserUpdateCondition(data.Read("moderator_user_id", static v => v.AsString()), data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_update.gd", "Condition");
        request.SetValue("moderator_user_id", ModeratorUserId);
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelSuspiciousUserUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSuspiciousUserUpdateCondition(data["moderator_user_id"].AsString(), data["broadcaster_user_id"].AsString())
        {
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
