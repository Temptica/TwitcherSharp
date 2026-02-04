using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUserBlockList 
/// </summary>
public partial class TwitchGetUserBlockListOpt : Resource, ITwitcherSharp<TwitchGetUserBlockListOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserBlockListOpt object.
    /// </summary> 
    public static TwitchGetUserBlockListOpt FromObject(GodotObject data)
    {
		return new TwitchGetUserBlockListOpt
		{
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_block_list.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
