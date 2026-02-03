using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class GetUserBlockListResponse : Resource, ITwitcherSharp<GetUserBlockListResponse>
{
    private GodotObject _data;
	public UserBlockList[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserBlockListResponse object.
    /// </summary> 
    public static GetUserBlockListResponse FromObject(GodotObject data)
    {
        return new GetUserBlockListResponse
        {

			Data = data.Get("data").As<UserBlockList[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_block_list_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
