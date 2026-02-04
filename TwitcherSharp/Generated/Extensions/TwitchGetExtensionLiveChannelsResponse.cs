using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetExtensionLiveChannelsResponse : Resource, ITwitcherSharp<TwitchGetExtensionLiveChannelsResponse>
{
    private GodotObject _data;
	public TwitchExtensionLiveChannel[] Data { get; set; }
	public string Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionLiveChannelsResponse object.
    /// </summary> 
    public static TwitchGetExtensionLiveChannelsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetExtensionLiveChannelsResponse
		{
			Data = dataArray.Select(TwitchExtensionLiveChannel.FromObject).ToArray(),
			Pagination = data.Get("pagination").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
