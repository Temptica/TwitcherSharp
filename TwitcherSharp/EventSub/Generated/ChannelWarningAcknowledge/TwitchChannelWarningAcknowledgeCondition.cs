using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelWarningAcknowledge;

public partial class TwitchChannelWarningAcknowledgeCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelWarningAcknowledgeCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelWarningAcknowledgeCondition);

    /// <summary> 
    /// The User ID of the broadcaster.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The User ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelWarningAcknowledgeCondition object.
    /// </summary> 
    public static TwitchChannelWarningAcknowledgeCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelWarningAcknowledgeCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_warning_acknowledge.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchChannelWarningAcknowledgeCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelWarningAcknowledgeCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
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
