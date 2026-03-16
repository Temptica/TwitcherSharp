using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Goals;

public partial class TwitchGoalsCondition : RefCounted, ITwitcherSharpCondition<TwitchGoalsCondition>
{
    public string Name => nameof(TwitchGoalsCondition);

    /// <summary> 
    /// The ID of the broadcaster to get notified about. The ID must match the user_id in the OAuth access token.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGoalsCondition object.
    /// </summary> 
    public static TwitchGoalsCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGoalsCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_goals.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
