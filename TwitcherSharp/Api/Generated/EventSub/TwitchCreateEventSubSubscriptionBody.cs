using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchCreateEventSubSubscriptionBody : Resource, ITwitcherSharp<TwitchCreateEventSubSubscriptionBody>
{
    private GodotObject _data;
	public string Type { get; set; }
	public string Version { get; set; }
	public Variant Condition { get; set; }
	public TwitchTransport Transport { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionBody object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCreateEventSubSubscriptionBody
		{
			Type = data.Get("type").AsString(),
			Version = data.Get("version").AsString(),
			Condition = data.Get("condition").As<Variant>(),
			Transport = data.Get("transport").As<TwitchTransport>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("type", Type);
		request.Set("version", Version);
		request.Set("condition", Condition);
		request.Set("transport", Transport);
		return request;
	}
	
	/// <summary> 
	/// The transport details that you want Twitch to use when sending you notifications. 
	/// </summary>
	public partial class TwitchTransport : Resource, ITwitcherSharp<TwitchTransport>
	{
	    private GodotObject _data;
		public string Method { get; set; }
		public string Callback { get; set; }
		public string Secret { get; set; }
		public string SessionId { get; set; }
		public string ConduitId { get; set; }
	
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
				ConduitId = data.Get("conduit_id").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_transport.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("method", Method);
			if(Callback != null) request.Set("callback", Callback);
			if(Secret != null) request.Set("secret", Secret);
			if(SessionId != null) request.Set("session_id", SessionId);
			if(ConduitId != null) request.Set("conduit_id", ConduitId);
			return request;
		}
	
	}

}
