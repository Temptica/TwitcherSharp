using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetGuestStarInvitesResponse : Resource, ITwitcherSharp<TwitchGetGuestStarInvitesResponse>
{
    private GodotObject _data;
	public TwitchGuestStarInvite[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGuestStarInvitesResponse object.
    /// </summary> 
    public static TwitchGetGuestStarInvitesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetGuestStarInvitesResponse
		{
			Data = dataArray.Select(TwitchGuestStarInvite.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_guest_star_invites.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
