using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class StreamMarkers : Resource, ITwitcherSharp<StreamMarkers>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserName { get; set; }
	public string UserLogin { get; set; }
	public Videos[] Videos { get; set; }
    /// <summary> 
    /// Transforms the godot data into a StreamMarkers object.
    /// </summary> 
    public static StreamMarkers FromObject(GodotObject data)
    {
        return new StreamMarkers
        {

			UserId = data.Get("user_id").AsString(),
			UserName = data.Get("user_name").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			Videos = data.Get("videos").As<Videos[]>(),
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
