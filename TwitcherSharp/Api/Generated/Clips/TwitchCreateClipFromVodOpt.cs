using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;


/// <summary> 
/// All optional parameters for TwitchAPI.CreateClipFromVod 
/// </summary>
public partial class TwitchCreateClipFromVodOpt : Resource, ITwitcherSharp<TwitchCreateClipFromVodOpt>
{
    private GodotObject _data;
	public double? Duration { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipFromVodOpt object.
    /// </summary> 
    public static TwitchCreateClipFromVodOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCreateClipFromVodOpt
		{
			Duration = data.Get("duration").AsDouble(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_from_vod.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(Duration.HasValue) request.Set("duration", Duration.Value);
		return request;
	}

}
