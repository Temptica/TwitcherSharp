using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOffline;

public partial class TwitchStreamOfflineCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchStreamOfflineCondition>
{
    public string Name => nameof(TwitchStreamOfflineCondition);

    /// <summary> 
    /// The broadcaster user ID you want to get stream offline notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOfflineCondition object.
    /// </summary> 
    public static TwitchStreamOfflineCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchStreamOfflineCondition(data.Get("broadcaster_user_id").AsString());
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_stream_offline.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchStreamOfflineCondition FromDictionary(Dictionary data)
    {
        return new TwitchStreamOfflineCondition(data["broadcaster_user_id"].AsString())
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
