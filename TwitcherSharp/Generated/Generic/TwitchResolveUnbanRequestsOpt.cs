using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.ResolveUnbanRequests 
/// </summary>
public partial class TwitchResolveUnbanRequestsOpt : Resource, ITwitcherSharp<TwitchResolveUnbanRequestsOpt>
{
    private GodotObject _data;
	public string ResolutionText { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchResolveUnbanRequestsOpt object.
    /// </summary> 
    public static TwitchResolveUnbanRequestsOpt FromObject(GodotObject data)
    {
		return new TwitchResolveUnbanRequestsOpt
		{
			ResolutionText = data.Get("resolution_text").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("resolution_text", ResolutionText);
		return request;
	}
}
