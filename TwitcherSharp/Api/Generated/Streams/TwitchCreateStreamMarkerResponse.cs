using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

/// <summary> 
///  
/// </summary>
public partial class TwitchCreateStreamMarkerResponse : Resource, ITwitcherSharp<TwitchCreateStreamMarkerResponse>
{
    private GodotObject _data;
	public TwitchStreamMarkerCreated[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateStreamMarkerResponse object.
    /// </summary> 
    public static TwitchCreateStreamMarkerResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateStreamMarkerResponse
		{
			Data = dataArray.Select(TwitchStreamMarkerCreated.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_stream_marker.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchStreamMarkerCreated : Resource, ITwitcherSharp<TwitchStreamMarkerCreated>
	{
	    private GodotObject _data;
		public string Id { get; set; }
		public string CreatedAt { get; set; }
		public int PositionSeconds { get; set; }
		public string Description { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchStreamMarkerCreated object.
	    /// </summary> 
	    public static TwitchStreamMarkerCreated FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchStreamMarkerCreated
			{
				Id = data.Get("id").AsString(),
				CreatedAt = data.Get("created_at").AsString(),
				PositionSeconds = data.Get("position_seconds").AsInt32(),
				Description = data.Get("description").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_marker_created.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("id", Id);
			request.Set("created_at", CreatedAt);
			request.Set("position_seconds", PositionSeconds);
			request.Set("description", Description);
			return request;
		}
	
	}

}
