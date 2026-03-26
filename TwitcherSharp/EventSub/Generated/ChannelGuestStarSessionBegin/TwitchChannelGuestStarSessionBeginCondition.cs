using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionBegin;

public partial class TwitchChannelGuestStarSessionBeginCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelGuestStarSessionBeginCondition>
{
    public string Name => nameof(TwitchChannelGuestStarSessionBeginCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel hosting the Guest Star Session
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The user ID of the moderator or broadcaster of the specified channel.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSessionBeginCondition object.
    /// </summary> 
    public static TwitchChannelGuestStarSessionBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelGuestStarSessionBeginCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_begin.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchChannelGuestStarSessionBeginCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelGuestStarSessionBeginCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
            ModeratorUserId = data["moderator_user_id"].AsString(),
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
