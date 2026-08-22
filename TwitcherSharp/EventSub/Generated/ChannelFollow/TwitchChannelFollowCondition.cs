using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelFollow;

public partial class TwitchChannelFollowCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelFollowCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelFollowCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get follow notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The ID of the moderator of the channel you want to get follow notifications for. If you have authorization from the broadcaster rather than a moderator, specify the broadcaster’s user ID here.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelFollowCondition object.
    /// </summary> 
    public static TwitchChannelFollowCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelFollowCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_follow.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchChannelFollowCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelFollowCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
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
