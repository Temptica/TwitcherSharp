using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class GetBannedUsersResponse : Resource, ITwitcherSharp<GetBannedUsersResponse>
{
    private GodotObject _data;
	public BannedUser[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetBannedUsersResponse object.
    /// </summary> 
    public static GetBannedUsersResponse FromObject(GodotObject data)
    {
        return new GetBannedUsersResponse
        {

			Data = data.Get("data").As<BannedUser[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_banned_users_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
