using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.HypeTrainEnd;

public partial class TwitchHypeTrainEndCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchHypeTrainEndCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchHypeTrainEndCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Hype Train end notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainEndCondition object.
    /// </summary> 
    public static TwitchHypeTrainEndCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchHypeTrainEndCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchHypeTrainEndCondition FromDictionary(Dictionary data)
    {
        return new TwitchHypeTrainEndCondition(data["broadcaster_user_id"].AsString())
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
