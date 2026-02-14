using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchStreamMarkers : Resource, ITwitcherSharp<TwitchStreamMarkers>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserName { get; set; }
	public string UserLogin { get; set; }
	public TwitchVideos[] Videos { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamMarkers object.
    /// </summary> 
    public static TwitchStreamMarkers FromObject(GodotObject data)
    {
        if(data == null) return null;
		var videosArray = data.Get("videos").AsGodotArray<GodotObject>();
		return new TwitchStreamMarkers
		{
			UserId = data.Get("user_id").AsString(),
			UserName = data.Get("user_name").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			Videos = videosArray.Select(TwitchVideos.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_markers.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_name", UserName);
		request.Set("user_login", UserLogin);
		request.Set("videos", Videos);
		return request;
	}
}
