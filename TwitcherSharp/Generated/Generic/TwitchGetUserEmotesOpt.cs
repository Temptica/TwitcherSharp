using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUserEmotes 
/// </summary>
public partial class TwitchGetUserEmotesOpt : Resource, ITwitcherSharp<TwitchGetUserEmotesOpt>
{
    private GodotObject _data;
	public string After { get; set; }
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesOpt object.
    /// </summary> 
    public static TwitchGetUserEmotesOpt FromObject(GodotObject data)
    {
		return new TwitchGetUserEmotesOpt
		{
			After = data.Get("after").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("after", After);
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
