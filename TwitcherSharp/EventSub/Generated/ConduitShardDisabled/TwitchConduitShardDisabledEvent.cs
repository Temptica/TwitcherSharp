using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ConduitShardDisabled;

public partial class TwitchConduitShardDisabledEvent : RefCounted, ITwitcherSharpEventSub<TwitchConduitShardDisabledEvent>
{
    /// <summary> 
    /// The ID of the conduit.
    /// </summary>
    public string ConduitId { get; set; }

    /// <summary> 
    /// The ID of the disabled shard.
    /// </summary>
    public string ShardId { get; set; }

    /// <summary> 
    /// The new status of the transport.
    /// </summary>
    public string Status { get; set; }

    /// <summary> 
    /// The disabled transport.
    /// </summary>
    public TwitchTransport Transport { get; set; }

    /// <summary> 
    /// websocket or webhook
    /// </summary>
    public string Method { get; set; }

    /// <summary> 
    /// Optional. Webhook callback URL. Null if method is set to websocket.
    /// </summary>
    public string Callback { get; set; }

    /// <summary> 
    /// Optional. WebSocket session ID. Null if  method is set to webhook.
    /// </summary>
    public string SessionId { get; set; }

    /// <summary> 
    /// Optional. Time that the WebSocket session connected. Null if method is set to webhook.
    /// </summary>
    public string ConnectedAt { get; set; }

    /// <summary> 
    /// Optional. Time that the WebSocket session disconnected. Null if method is set to webhook.
    /// </summary>
    public string DisconnectedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchConduitShardDisabledEvent object.
    /// </summary> 
    public static TwitchConduitShardDisabledEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchConduitShardDisabledEvent
        {
            ConduitId = data.Get("conduit_id").AsString(),
            ShardId = data.Get("shard_id").AsString(),
            Status = data.Get("status").AsString(),
            Transport = TwitchTransport.FromObject(data.Get("transport").AsGodotObject()),
            Method = data.Get("method").AsString(),
            Callback = data.Get("callback").AsString(),
            SessionId = data.Get("session_id").AsString(),
            ConnectedAt = data.Get("connected_at").AsString(),
            DisconnectedAt = data.Get("disconnected_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_conduit_shard_disabled.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("conduit_id", ConduitId);
        request.Set("shard_id", ShardId);
        request.Set("status", Status);
        request.Set("transport", Transport.ToGodotObject());
        request.Set("method", Method);
        request.Set("callback", Callback);
        request.Set("session_id", SessionId);
        request.Set("connected_at", ConnectedAt);
        request.Set("disconnected_at", DisconnectedAt);
        return request;
    }


    public partial class TwitchTransport : RefCounted, ITwitcherSharpEventSub<TwitchTransport>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTransport object.
        /// </summary> 
        public static TwitchTransport FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchTransport
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_conduit_shard_disabled.gd");
            var transportClass = script.Get("Transport").As<GDScript>();
            var request = transportClass.New().AsGodotObject();
            return request;
        }
    }
}
