using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class GetExtensionLiveChannelsResponse : Resource, ITwitcherSharp<GetExtensionLiveChannelsResponse>
{
    private GodotObject _data;
	public ExtensionLiveChannel[] Data { get; set; }
	public string Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionLiveChannelsResponse object.
    /// </summary> 
    public static GetExtensionLiveChannelsResponse FromObject(GodotObject data)
    {
        return new GetExtensionLiveChannelsResponse
        {

			Data = data.Get("data").As<ExtensionLiveChannel[]>(),
			Pagination = data.Get("pagination").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
