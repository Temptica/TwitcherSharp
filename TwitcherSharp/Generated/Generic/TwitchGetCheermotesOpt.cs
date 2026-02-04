using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCheermotes 
/// </summary>
public partial class TwitchGetCheermotesOpt : Resource, ITwitcherSharp<TwitchGetCheermotesOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesOpt object.
    /// </summary> 
    public static TwitchGetCheermotesOpt FromObject(GodotObject data)
    {
		return new TwitchGetCheermotesOpt
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
