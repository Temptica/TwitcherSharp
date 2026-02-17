using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

/// <summary> 
/// All optional parameters for TwitchAPI.UpdateGuestStarSlot 
/// </summary>
public partial class TwitchUpdateGuestStarSlotOpt : Resource, ITwitcherSharp<TwitchUpdateGuestStarSlotOpt>
{
    private GodotObject _data;
	public string DestinationSlotId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateGuestStarSlotOpt object.
    /// </summary> 
    public static TwitchUpdateGuestStarSlotOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUpdateGuestStarSlotOpt
		{
			DestinationSlotId = data.Get("destination_slot_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_guest_star_slot.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(DestinationSlotId != null) request.Set("destination_slot_id", DestinationSlotId);
		return request;
	}

}
