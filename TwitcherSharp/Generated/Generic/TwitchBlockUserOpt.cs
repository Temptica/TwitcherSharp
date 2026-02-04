using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.BlockUser 
/// </summary>
public partial class TwitchBlockUserOpt : Resource, ITwitcherSharp<TwitchBlockUserOpt>
{
    private GodotObject _data;
	public string SourceContext { get; set; }
	public string Reason { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchBlockUserOpt object.
    /// </summary> 
    public static TwitchBlockUserOpt FromObject(GodotObject data)
    {
		return new TwitchBlockUserOpt
		{
			SourceContext = data.Get("source_context").AsString(),
			Reason = data.Get("reason").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_block_user.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("source_context", SourceContext);
		request.Set("reason", Reason);
		return request;
	}
}
