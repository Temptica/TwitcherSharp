using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOffline;

public partial class TwitchStreamOfflineCondition : RefCounted, ITwitcherSharpCondition<TwitchStreamOfflineCondition>
{
    public string Name => nameof(TwitchStreamOfflineCondition);

    /// <summary> 
    /// The broadcaster user ID you want to get stream offline notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOfflineCondition object.
    /// </summary> 
    public static TwitchStreamOfflineCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchStreamOfflineCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_stream_offline.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
