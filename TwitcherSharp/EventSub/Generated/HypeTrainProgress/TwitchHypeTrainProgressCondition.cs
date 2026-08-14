using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.HypeTrainProgress;

public partial class TwitchHypeTrainProgressCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchHypeTrainProgressCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchHypeTrainProgressCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Hype Train progress notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainProgressCondition object.
    /// </summary> 
    public static TwitchHypeTrainProgressCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchHypeTrainProgressCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_progress.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchHypeTrainProgressCondition FromDictionary(Dictionary data)
    {
        return new TwitchHypeTrainProgressCondition(data["broadcaster_user_id"].AsString())
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
