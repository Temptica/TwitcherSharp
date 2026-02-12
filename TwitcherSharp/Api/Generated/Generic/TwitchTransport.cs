using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The transport details used to send the notifications. 
/// </summary>
public partial class TwitchTransport : Resource, ITwitcherSharp<TwitchTransport>
{
    private GodotObject _data;
	public string Method { get; set; }
	public string Callback { get; set; }
	public string SessionId { get; set; }
	public string ConnectedAt { get; set; }
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
			SessionId = data.Get("session_id").AsString(),
			ConnectedAt = data.Get("connected_at").AsString(),
			DisconnectedAt = data.Get("disconnected_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_transport.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("method", Method);
		if(Callback != null) request.Set("callback", Callback);
		if(SessionId != null) request.Set("session_id", SessionId);
		if(ConnectedAt != null) request.Set("connected_at", ConnectedAt);
		if(DisconnectedAt != null) request.Set("disconnected_at", DisconnectedAt);
		return request;
	}
}
