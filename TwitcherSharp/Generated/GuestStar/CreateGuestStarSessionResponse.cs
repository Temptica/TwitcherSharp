using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class CreateGuestStarSessionResponse : Resource, ITwitcherSharp<CreateGuestStarSessionResponse>
{
    private GodotObject _data;
	public GuestStarSession[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateGuestStarSessionResponse object.
    /// </summary> 
    public static CreateGuestStarSessionResponse FromObject(GodotObject data)
    {
        return new CreateGuestStarSessionResponse
        {

			Data = data.Get("data").As<GuestStarSession[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_guest_star_session_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
