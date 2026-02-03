using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUserEmotes 
/// </summary>
public partial class GetUserEmotesOpt : Resource, ITwitcherSharp<GetUserEmotesOpt>
{
    private GodotObject _data;
	public string After { get; set; }
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserEmotesOpt object.
    /// </summary> 
    public static GetUserEmotesOpt FromObject(GodotObject data)
    {
        return new GetUserEmotesOpt
        {

			After = data.Get("after").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("after", After);
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
