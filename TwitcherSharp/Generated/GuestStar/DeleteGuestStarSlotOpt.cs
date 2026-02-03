using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
/// All optional parameters for TwitchAPI.DeleteGuestStarSlot 
/// </summary>
public partial class DeleteGuestStarSlotOpt : Resource, ITwitcherSharp<DeleteGuestStarSlotOpt>
{
    private GodotObject _data;
	public string ShouldReinviteGuest { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DeleteGuestStarSlotOpt object.
    /// </summary> 
    public static DeleteGuestStarSlotOpt FromObject(GodotObject data)
    {
        return new DeleteGuestStarSlotOpt
        {

			ShouldReinviteGuest = data.Get("should_reinvite_guest").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_guest_star_slot_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("should_reinvite_guest", ShouldReinviteGuest);
		return request;
	}
}
