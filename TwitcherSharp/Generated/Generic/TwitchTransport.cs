using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
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
		request.Set("callback", Callback);
		request.Set("session_id", SessionId);
		request.Set("connected_at", ConnectedAt);
		request.Set("disconnected_at", DisconnectedAt);
		return request;
	}
}
