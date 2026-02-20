using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.HypeTrainBegin;

public partial class TwitchHypeTrainBeginCondition : Resource, ITwitcherSharpCondition<TwitchHypeTrainBeginCondition>
{
    public string Name => nameof(TwitchHypeTrainBeginCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Hype Train begin notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainBeginCondition object.
    /// </summary> 
    public static TwitchHypeTrainBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchHypeTrainBeginCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_begin.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
