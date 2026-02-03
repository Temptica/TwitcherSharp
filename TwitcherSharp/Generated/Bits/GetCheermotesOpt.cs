using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Bits;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCheermotes 
/// </summary>
public partial class GetCheermotesOpt : Resource, ITwitcherSharp<GetCheermotesOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCheermotesOpt object.
    /// </summary> 
    public static GetCheermotesOpt FromObject(GodotObject data)
    {
        return new GetCheermotesOpt
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
