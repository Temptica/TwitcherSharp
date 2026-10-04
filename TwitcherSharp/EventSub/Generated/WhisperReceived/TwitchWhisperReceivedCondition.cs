using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.WhisperReceived;

public partial class TwitchWhisperReceivedCondition(string userId) : RefCounted, ITwitcherSharpCondition<TwitchWhisperReceivedCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchWhisperReceivedCondition);

    /// <summary> 
    /// The user_id of the person receiving whispers.
    /// </summary>
    public string UserId { get; set; } = userId;

    /// <summary> 
    /// Transforms the godot data into a TwitchWhisperReceivedCondition object.
    /// </summary> 
    public static TwitchWhisperReceivedCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchWhisperReceivedCondition(data.Read("user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd", "Condition");
        request.SetValue("user_id", UserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchWhisperReceivedCondition FromDictionary(Dictionary data)
    {
        return new TwitchWhisperReceivedCondition(data["user_id"].AsString())
        {
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
