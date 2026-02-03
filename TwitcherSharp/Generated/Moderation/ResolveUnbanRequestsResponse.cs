using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class ResolveUnbanRequestsResponse : Resource, ITwitcherSharp<ResolveUnbanRequestsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ResolveUnbanRequestsResponse object.
    /// </summary> 
    public static ResolveUnbanRequestsResponse FromObject(GodotObject data)
    {
        return new ResolveUnbanRequestsResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_resolve_unban_requests_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
