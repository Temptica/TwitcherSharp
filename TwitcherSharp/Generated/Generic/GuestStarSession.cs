using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class GuestStarSession : Resource, ITwitcherSharp<GuestStarSession>
{
    private GodotObject _data;
	public string Id { get; set; }
	public Guest[] Guests { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GuestStarSession object.
    /// </summary> 
    public static GuestStarSession FromObject(GodotObject data)
    {
        return new GuestStarSession
        {

			Id = data.Get("id").AsString(),
			Guests = data.Get("guests").As<Guest[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest_star_session.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("guests", Guests);
		return request;
	}
}
