using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class GetGuestStarSessionResponse : Resource, ITwitcherSharp<GetGuestStarSessionResponse>
{
    private GodotObject _data;
	public GuestStarSession[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGuestStarSessionResponse object.
    /// </summary> 
    public static GetGuestStarSessionResponse FromObject(GodotObject data)
    {
        return new GetGuestStarSessionResponse
        {

			Data = data.Get("data").As<GuestStarSession[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_guest_star_session_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
