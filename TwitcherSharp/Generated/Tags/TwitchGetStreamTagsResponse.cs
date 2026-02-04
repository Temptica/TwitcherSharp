using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Tags;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetStreamTagsResponse : Resource, ITwitcherSharp<TwitchGetStreamTagsResponse>
{
    private GodotObject _data;
	public TwitchStreamTag[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamTagsResponse object.
    /// </summary> 
    public static TwitchGetStreamTagsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetStreamTagsResponse
		{
			Data = dataArray.Select(TwitchStreamTag.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_tags.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
