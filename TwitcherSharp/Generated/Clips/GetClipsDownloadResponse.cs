using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
///  
/// </summary>
public partial class GetClipsDownloadResponse : Resource, ITwitcherSharp<GetClipsDownloadResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetClipsDownloadResponse object.
    /// </summary> 
    public static GetClipsDownloadResponse FromObject(GodotObject data)
    {
        return new GetClipsDownloadResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips_download_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
