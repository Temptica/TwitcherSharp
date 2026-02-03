using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class EndGuestStarSessionResponse : Resource, ITwitcherSharp<EndGuestStarSessionResponse>
{
    private GodotObject _data;
	public GuestStarSession[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a EndGuestStarSessionResponse object.
    /// </summary> 
    public static EndGuestStarSessionResponse FromObject(GodotObject data)
    {
        return new EndGuestStarSessionResponse
        {

			Data = data.Get("data").As<GuestStarSession[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_guest_star_session_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
