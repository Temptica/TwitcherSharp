using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class GetVIPsResponse : Resource, ITwitcherSharp<GetVIPsResponse>
{
    private GodotObject _data;
	public UserVip[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetVIPsResponse object.
    /// </summary> 
    public static GetVIPsResponse FromObject(GodotObject data)
    {
        return new GetVIPsResponse
        {

			Data = data.Get("data").As<UserVip[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_v_i_ps_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
