using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOnline;

public partial class TwitchStreamOnlineCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchStreamOnlineCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchStreamOnlineCondition);

    /// <summary> 
    /// The broadcaster user ID you want to get stream online notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOnlineCondition object.
    /// </summary> 
    public static TwitchStreamOnlineCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamOnlineCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_stream_online.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchStreamOnlineCondition FromDictionary(Dictionary data)
    {
        return new TwitchStreamOnlineCondition(data["broadcaster_user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
