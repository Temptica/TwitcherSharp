using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ConduitShardDisabled;

public partial class TwitchConduitShardDisabledEvent : RefCounted, ITwitcherSharpEventSub<TwitchConduitShardDisabledEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the conduit.
    /// </summary>
    public string? ConduitId { get; set; }

    /// <summary> 
    /// The ID of the disabled shard.
    /// </summary>
    public string? ShardId { get; set; }

    /// <summary> 
    /// The new status of the transport.
    /// </summary>
    public string? Status { get; set; }

    /// <summary> 
    /// Defines the transport details that you want Twitch to use when sending you event notifications.
    /// </summary>
    public TwitchTransport? Transport { get => field ??= _data.Get<TwitchTransport>("transport"); set; }

    /// <summary> 
    /// websocket or webhook
    /// </summary>
    public string? Method { get; set; }

    /// <summary> 
    /// Optional. Webhook callback URL. Null if method is set to websocket.
    /// </summary>
    public string? Callback { get; set; }

    /// <summary> 
    /// Optional. WebSocket session ID. Null if  method is set to webhook.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary> 
    /// Optional. Time that the WebSocket session connected. Null if method is set to webhook.
    /// </summary>
    public string? ConnectedAt { get; set; }

    /// <summary> 
    /// Optional. Time that the WebSocket session disconnected. Null if method is set to webhook.
    /// </summary>
    public string? DisconnectedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchConduitShardDisabledEvent object.
    /// </summary> 
    public static TwitchConduitShardDisabledEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchConduitShardDisabledEvent
        {
            ConduitId = data.Read("conduit_id", static v => v.AsString()),
            ShardId = data.Read("shard_id", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
            Method = data.Read("method", static v => v.AsString()),
            Callback = data.Read("callback", static v => v.AsString()),
            SessionId = data.Read("session_id", static v => v.AsString()),
            ConnectedAt = data.Read("connected_at", static v => v.AsString()),
            DisconnectedAt = data.Read("disconnected_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_conduit_shard_disabled.gd", "Event");
        if(ConduitId != null) request.SetValue("conduit_id", ConduitId);
        if(ShardId != null) request.SetValue("shard_id", ShardId);
        if(Status != null) request.SetValue("status", Status);
        if(Transport != null) request.SetObject("transport", Transport);
        if(Method != null) request.SetValue("method", Method);
        if(Callback != null) request.SetValue("callback", Callback);
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
