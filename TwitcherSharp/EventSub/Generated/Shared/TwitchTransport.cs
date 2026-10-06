using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTransport : RefCounted, ITwitcherSharpEventSub<TwitchTransport>
{
    private Variant _data;
    
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
            Method = data.Read("method", static v => v.AsString()),
            Callback = data.Read("callback", static v => v.AsString()),
            Secret = data.Read("secret", static v => v.AsString()),
            SessionId = data.Read("session_id", static v => v.AsString()),
            ConnectedAt = data.Read("connected_at", static v => v.AsString()),
            DisconnectedAt = data.Read("disconnected_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_transport.gd");
        if(Method != null) request.SetValue("method", Method);
        if(Callback != null) request.SetValue("callback", Callback);
        if(Secret != null) request.SetValue("secret", Secret);
        if(SessionId != null) request.SetValue("session_id", SessionId);
        if(ConnectedAt != null) request.SetValue("connected_at", ConnectedAt);
        if(DisconnectedAt != null) request.SetValue("disconnected_at", DisconnectedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
