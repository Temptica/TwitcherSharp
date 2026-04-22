using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelModerateCondition>
{
    public string Name => nameof(TwitchChannelModerateCondition);

    /// <summary> 
    /// The user ID of the broadcaster.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The user ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateCondition object.
    /// </summary> 
    public static TwitchChannelModerateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelModerateCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchChannelModerateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelModerateCondition
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
