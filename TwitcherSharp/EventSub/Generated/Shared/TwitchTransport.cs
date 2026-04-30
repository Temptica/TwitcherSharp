using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTransport : RefCounted, ITwitcherSharpEventSub<TwitchTransport>
{
    /// <summary> 
    /// yes
    /// </summary>
    public string Method { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string Callback { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string Secret { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string SessionId { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string ConnectedAt { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string DisconnectedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchTransport object.
    /// </summary> 
    public static TwitchTransport FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchTransport
        {
            Method = data.Get("method").AsString(),
            Callback = data.Get("callback").AsString(),
            Secret = data.Get("secret").AsString(),
            SessionId = data.Get("session_id").AsString(),
            ConnectedAt = data.Get("connected_at").AsString(),
            DisconnectedAt = data.Get("disconnected_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_transport.gd");
        var request = script.New().AsGodotObject();
        request.Set("method", Method);
        request.Set("callback", Callback);
        request.Set("secret", Secret);
        request.Set("session_id", SessionId);
        request.Set("connected_at", ConnectedAt);
        request.Set("disconnected_at", DisconnectedAt);
        return request;
    }
}
