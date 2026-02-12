using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchConduitShardDisabledEvent : Resource, ITwitcherSharpEventSub<TwitchConduitShardDisabledEvent>
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

	public static TwitchConduitShardDisabledEvent FromData(Dictionary data)
	{
	    return new TwitchConduitShardDisabledEvent
	    {
			ConduitId = data["conduit_id"].AsString(),
			ShardId = data["shard_id"].AsString(),
			Status = data["status"].AsString(),
			Transport = TwitchTransport.FromData(data["transport"].AsGodotDictionary()),
			Method = data["method"].AsString(),
			Callback = data["callback"].AsString(),
			SessionId = data["session_id"].AsString(),
			ConnectedAt = data["connected_at"].AsString(),
			DisconnectedAt = data["disconnected_at"].AsString(),
		};
	}

public partial class TwitchTransport : Resource, ITwitcherSharpEventSub<TwitchTransport>
{

	public static TwitchTransport FromData(Dictionary data)
	{
	    return new TwitchTransport
	    {
		};
	}

}

}
