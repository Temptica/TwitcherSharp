using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class GetUnbanRequestsResponse : Resource, ITwitcherSharp<GetUnbanRequestsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUnbanRequestsResponse object.
    /// </summary> 
    public static GetUnbanRequestsResponse FromObject(GodotObject data)
    {
        return new GetUnbanRequestsResponse
        {

			Data = data.Get("data").As<Data[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_unban_requests_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
