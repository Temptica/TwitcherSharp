using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetExtensionConfigurationSegmentResponse : Resource, ITwitcherSharp<TwitchGetExtensionConfigurationSegmentResponse>
{
    private GodotObject _data;
	public TwitchExtensionConfigurationSegment[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionConfigurationSegmentResponse object.
    /// </summary> 
    public static TwitchGetExtensionConfigurationSegmentResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetExtensionConfigurationSegmentResponse
		{
			Data = dataArray.Select(TwitchExtensionConfigurationSegment.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_configuration_segment.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchExtensionConfigurationSegment : Resource, ITwitcherSharp<TwitchExtensionConfigurationSegment>
	{
	    private GodotObject _data;
		public string Segment { get; set; }
		public string BroadcasterId { get; set; }
		public string Content { get; set; }
		public string Version { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchExtensionConfigurationSegment object.
	    /// </summary> 
	    public static TwitchExtensionConfigurationSegment FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchExtensionConfigurationSegment
			{
				Segment = data.Get("segment").AsString(),
				BroadcasterId = data.Get("broadcaster_id").AsString(),
				Content = data.Get("content").AsString(),
				Version = data.Get("version").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_configuration_segment.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("segment", Segment);
			if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
			request.Set("content", Content);
			request.Set("version", Version);
			return request;
		}
	
	}

}
