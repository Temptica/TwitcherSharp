using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateV2Condition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelModerateV2Condition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelModerateV2Condition);

    /// <summary> 
    /// The user ID of the broadcaster.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The user ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateV2Condition object.
    /// </summary> 
    public static TwitchChannelModerateV2Condition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModerateV2Condition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
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

    public static TwitchChannelModerateV2Condition FromDictionary(Dictionary data)
    {
        return new TwitchChannelModerateV2Condition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
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
