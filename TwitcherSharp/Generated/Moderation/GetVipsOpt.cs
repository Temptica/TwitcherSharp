using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetVips 
/// </summary>
public partial class GetVipsOpt : Resource, ITwitcherSharp<GetVipsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetVipsOpt object.
    /// </summary> 
    public static GetVipsOpt FromObject(GodotObject data)
    {
        return new GetVipsOpt
        {

			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_vips_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
