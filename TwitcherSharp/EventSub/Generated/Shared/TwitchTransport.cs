using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTransport : RefCounted, ITwitcherSharpEventSub<TwitchTransport>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// yes
    /// </summary>
    public string? Method { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string? Callback { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string? Secret { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string? ConnectedAt { get; set; }

    /// <summary> 
    /// no
    /// </summary>
    public string? DisconnectedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchTransport object.
    /// </summary> 
    public static TwitchTransport? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchTransport
        {
            Method = data.Get("method").AsString(),
            Callback = data.Get("callback").AsString(),
            Secret = data.Get("secret").AsString(),
            SessionId = data.Get("session_id").AsString(),
            ConnectedAt = data.Get("connected_at").AsString(),
            DisconnectedAt = data.Get("disconnected_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_transport.gd");
        var request = script.New().AsGodotObject();
        if(Method != null) request.Set("method", Method);
        if(Callback != null) request.Set("callback", Callback);
        if(Secret != null) request.Set("secret", Secret);
        if(SessionId != null) request.Set("session_id", SessionId);
        if(ConnectedAt != null) request.Set("connected_at", ConnectedAt);
        if(DisconnectedAt != null) request.Set("disconnected_at", DisconnectedAt);
        return request;
    }
}
