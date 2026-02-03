using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
/// All optional parameters for TwitchAPI.BlockUser 
/// </summary>
public partial class BlockUserOpt : Resource, ITwitcherSharp<BlockUserOpt>
{
    private GodotObject _data;
	public string SourceContext { get; set; }
	public string Reason { get; set; }
    /// <summary> 
    /// Transforms the godot data into a BlockUserOpt object.
    /// </summary> 
    public static BlockUserOpt FromObject(GodotObject data)
    {
        return new BlockUserOpt
        {

			SourceContext = data.Get("source_context").AsString(),
			Reason = data.Get("reason").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_block_user_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("source_context", SourceContext);
		request.Set("reason", Reason);
		return request;
	}
}
