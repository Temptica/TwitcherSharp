using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreateClipResponse : Resource, ITwitcherSharp<TwitchCreateClipResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipResponse object.
    /// </summary> 
    public static TwitchCreateClipResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateClipResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
