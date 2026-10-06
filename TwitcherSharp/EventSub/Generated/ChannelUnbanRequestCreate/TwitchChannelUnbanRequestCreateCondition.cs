using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestCreate;

public partial class TwitchChannelUnbanRequestCreateCondition(string moderatorUserId, string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelUnbanRequestCreateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelUnbanRequestCreateCondition);

    /// <summary> 
    /// The ID of the user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// The ID of the broadcaster you want to get chat unban request notifications for. Maximum: 1.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestCreateCondition object.
    /// </summary> 
    public static TwitchChannelUnbanRequestCreateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUnbanRequestCreateCondition(data.Read("moderator_user_id", static v => v.AsString()), data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_create.gd", "Condition");
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

    public static TwitchChannelUnbanRequestCreateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelUnbanRequestCreateCondition(data["moderator_user_id"].AsString(), data["broadcaster_user_id"].AsString())
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
