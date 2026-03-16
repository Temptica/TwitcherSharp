using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserUpdate;

public partial class TwitchUserUpdateCondition : RefCounted, ITwitcherSharpCondition<TwitchUserUpdateCondition>
{
    public string Name => nameof(TwitchUserUpdateCondition);

    /// <summary> 
    /// The user ID for the user you want update notifications for.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserUpdateCondition object.
    /// </summary> 
    public static TwitchUserUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserUpdateCondition
        {
            UserId = data.Get("user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_update.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        return request;
    }
}
