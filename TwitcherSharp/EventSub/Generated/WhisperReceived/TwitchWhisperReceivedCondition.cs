using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.WhisperReceived;

public partial class TwitchWhisperReceivedCondition : RefCounted, ITwitcherSharpCondition<TwitchWhisperReceivedCondition>
{
    public string Name => nameof(TwitchWhisperReceivedCondition);

    /// <summary> 
    /// The user_id of the person receiving whispers.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWhisperReceivedCondition object.
    /// </summary> 
    public static TwitchWhisperReceivedCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchWhisperReceivedCondition
        {
            UserId = data.Get("user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        return request;
    }

    public static TwitchWhisperReceivedCondition FromDictionary(Dictionary data)
    {
        return new TwitchWhisperReceivedCondition
        {
            UserId = data["user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"user_id", UserId},
        };
    }
}
