using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class GetGuestStarInvitesResponse : Resource, ITwitcherSharp<GetGuestStarInvitesResponse>
{
    private GodotObject _data;
	public GuestStarInvite[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGuestStarInvitesResponse object.
    /// </summary> 
    public static GetGuestStarInvitesResponse FromObject(GodotObject data)
    {
        return new GetGuestStarInvitesResponse
        {

			Data = data.Get("data").As<GuestStarInvite[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_guest_star_invites_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
