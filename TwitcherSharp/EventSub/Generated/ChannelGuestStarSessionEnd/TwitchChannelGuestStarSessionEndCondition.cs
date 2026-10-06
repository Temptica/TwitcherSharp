using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionEnd;

public partial class TwitchChannelGuestStarSessionEndCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelGuestStarSessionEndCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelGuestStarSessionEndCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel hosting the Guest Star Session
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The user ID of the moderator or broadcaster of the specified channel.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSessionEndCondition object.
    /// </summary> 
    public static TwitchChannelGuestStarSessionEndCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelGuestStarSessionEndCondition(data.Read("broadcaster_user_id", static v => v.AsString()), data.Read("moderator_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_end.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        request.SetValue("moderator_user_id", ModeratorUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelGuestStarSessionEndCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelGuestStarSessionEndCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
            {"moderator_user_id", ModeratorUserId},
        };
    }
}
