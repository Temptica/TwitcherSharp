using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchAutomodMessageHoldCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchAutomodMessageHoldCondition);

    /// <summary> 
    /// User ID of the broadcaster (channel).
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// User ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageHoldCondition object.
    /// </summary> 
    public static TwitchAutomodMessageHoldCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodMessageHoldCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchAutomodMessageHoldCondition FromDictionary(Dictionary data)
    {
        return new TwitchAutomodMessageHoldCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
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
