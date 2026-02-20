using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitShardsResponse : Resource, ITwitcherSharp<TwitchUpdateConduitShardsResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchErrors[] Errors { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsResponse object.
    /// </summary> 
    public static TwitchUpdateConduitShardsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		var errorsArray = data.Get("errors").AsGodotArray<GodotObject>();
		return new TwitchUpdateConduitShardsResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Errors = errorsArray.Select(TwitchErrors.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("errors", Errors);
		return request;
	}
	
	/// <summary> 
	/// List of successful shard updates. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string Id { get; set; }
		public string Status { get; set; }
		public TwitchTransport Transport { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				Id = data.Get("id").AsString(),
				Status = data.Get("status").AsString(),
				Transport = data.Get("transport").As<TwitchTransport>(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("id", Id);
			request.Set("status", Status);
			request.Set("transport", Transport);
			return request;
		}
		
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
	
	}
	
	/// <summary> 
	/// List of unsuccessful updates. 
	/// </summary>
	public partial class TwitchErrors : Resource, ITwitcherSharp<TwitchErrors>
	{
	    private GodotObject _data;
		public string Id { get; set; }
		public string Message { get; set; }
		public string Code { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchErrors object.
	    /// </summary> 
	    public static TwitchErrors FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchErrors
			{
				Id = data.Get("id").AsString(),
				Message = data.Get("message").AsString(),
				Code = data.Get("code").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_errors.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("id", Id);
			request.Set("message", Message);
			request.Set("code", Code);
			return request;
		}
	
	}

}
