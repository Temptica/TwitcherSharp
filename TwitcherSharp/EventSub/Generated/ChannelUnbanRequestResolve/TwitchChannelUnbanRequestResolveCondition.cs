using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestResolve;

public partial class TwitchChannelUnbanRequestResolveCondition(string moderatorUserId, string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelUnbanRequestResolveCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelUnbanRequestResolveCondition);

    /// <summary> 
    /// The ID of the user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// The ID of the broadcaster you want to get unban request resolution notifications for. Maximum: 1.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestResolveCondition object.
    /// </summary> 
    public static TwitchChannelUnbanRequestResolveCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUnbanRequestResolveCondition(data.Read("moderator_user_id", static v => v.AsString()), data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_resolve.gd", "Condition");
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

    public static TwitchChannelUnbanRequestResolveCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelUnbanRequestResolveCondition(data["moderator_user_id"].AsString(), data["broadcaster_user_id"].AsString())
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
