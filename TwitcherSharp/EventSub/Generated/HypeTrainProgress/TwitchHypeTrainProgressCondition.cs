using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.HypeTrainProgress;

public partial class TwitchHypeTrainProgressCondition : RefCounted, ITwitcherSharpCondition<TwitchHypeTrainProgressCondition>
{
    public string Name => nameof(TwitchHypeTrainProgressCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Hype Train progress notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainProgressCondition object.
    /// </summary> 
    public static TwitchHypeTrainProgressCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchHypeTrainProgressCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_progress.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
