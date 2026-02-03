using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Videos;
 
/// <summary> 
///  
/// </summary>
public partial class DeleteVideosResponse : Resource, ITwitcherSharp<DeleteVideosResponse>
{
    private GodotObject _data;
	public string[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DeleteVideosResponse object.
    /// </summary> 
    public static DeleteVideosResponse FromObject(GodotObject data)
    {
        return new DeleteVideosResponse
        {

			Data = data.Get("data").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_videos_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
