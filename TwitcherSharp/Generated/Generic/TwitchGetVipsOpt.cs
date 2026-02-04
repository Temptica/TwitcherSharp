using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetVips 
/// </summary>
public partial class TwitchGetVipsOpt : Resource, ITwitcherSharp<TwitchGetVipsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetVipsOpt object.
    /// </summary> 
    public static TwitchGetVipsOpt FromObject(GodotObject data)
    {
		return new TwitchGetVipsOpt
		{
			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_vips.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
