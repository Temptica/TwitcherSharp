using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

/// <summary> 
///  
/// </summary>
public partial class TwitchDeleteVideosResponse : Resource, ITwitcherSharp<TwitchDeleteVideosResponse>
{
    private GodotObject _data;
	public string[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteVideosResponse object.
    /// </summary> 
    public static TwitchDeleteVideosResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchDeleteVideosResponse
		{
			Data = data.Get("data").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_videos.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}

}
