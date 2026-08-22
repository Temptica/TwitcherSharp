using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Goals;

public partial class TwitchGoalsCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchGoalsCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchGoalsCondition);

    /// <summary> 
    /// The ID of the broadcaster to get notified about. The ID must match the user_id in the OAuth access token.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchGoalsCondition object.
    /// </summary> 
    public static TwitchGoalsCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGoalsCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_goals.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchGoalsCondition FromDictionary(Dictionary data)
    {
        return new TwitchGoalsCondition(data["broadcaster_user_id"].AsString())
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
