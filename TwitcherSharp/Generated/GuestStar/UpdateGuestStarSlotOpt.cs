using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
/// All optional parameters for TwitchAPI.UpdateGuestStarSlot 
/// </summary>
public partial class UpdateGuestStarSlotOpt : Resource, ITwitcherSharp<UpdateGuestStarSlotOpt>
{
    private GodotObject _data;
	public string DestinationSlotId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateGuestStarSlotOpt object.
    /// </summary> 
    public static UpdateGuestStarSlotOpt FromObject(GodotObject data)
    {
        return new UpdateGuestStarSlotOpt
        {

			DestinationSlotId = data.Get("destination_slot_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_guest_star_slot_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("destination_slot_id", DestinationSlotId);
		return request;
	}
}
