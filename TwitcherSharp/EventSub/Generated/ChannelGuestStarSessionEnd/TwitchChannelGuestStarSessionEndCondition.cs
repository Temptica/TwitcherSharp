using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionEnd;

public partial class TwitchChannelGuestStarSessionEndCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelGuestStarSessionEndCondition>
{
    private GodotObject _data;
    
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
    public static TwitchChannelGuestStarSessionEndCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelGuestStarSessionEndCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_end.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
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
