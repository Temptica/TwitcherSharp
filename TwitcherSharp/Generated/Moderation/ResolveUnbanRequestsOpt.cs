using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.ResolveUnbanRequests 
/// </summary>
public partial class ResolveUnbanRequestsOpt : Resource, ITwitcherSharp<ResolveUnbanRequestsOpt>
{
    private GodotObject _data;
	public string ResolutionText { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ResolveUnbanRequestsOpt object.
    /// </summary> 
    public static ResolveUnbanRequestsOpt FromObject(GodotObject data)
    {
        return new ResolveUnbanRequestsOpt
        {

			ResolutionText = data.Get("resolution_text").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_resolve_unban_requests_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("resolution_text", ResolutionText);
		return request;
	}
}
