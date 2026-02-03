using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
///  
/// </summary>
public partial class GetClipsResponse : Resource, ITwitcherSharp<GetClipsResponse>
{
    private GodotObject _data;
	public Clip[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetClipsResponse object.
    /// </summary> 
    public static GetClipsResponse FromObject(GodotObject data)
    {
        return new GetClipsResponse
        {

			Data = data.Get("data").As<Clip[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
