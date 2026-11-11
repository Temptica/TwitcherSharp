using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ShoutoutReceived;

public partial class TwitchShoutoutReceivedCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchShoutoutReceivedCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchShoutoutReceivedCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to receive notifications about when they receive a Shoutout.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The ID of the broadcaster that received the Shoutout or one of the broadcaster's moderators.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchShoutoutReceivedCondition object.
    /// </summary> 
    public static TwitchShoutoutReceivedCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchShoutoutReceivedCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_shoutout_received.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchShoutoutReceivedCondition FromDictionary(Dictionary data)
    {
        return new TwitchShoutoutReceivedCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
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
