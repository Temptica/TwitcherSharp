using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Videos;
 
/// <summary> 
///  
/// </summary>
public partial class GetVideosResponse : Resource, ITwitcherSharp<GetVideosResponse>
{
    private GodotObject _data;
	public Video[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetVideosResponse object.
    /// </summary> 
    public static GetVideosResponse FromObject(GodotObject data)
    {
        return new GetVideosResponse
        {

			Data = data.Get("data").As<Video[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_videos_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
