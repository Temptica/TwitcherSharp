using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// All optional parameters for TwitchAPI.DeleteGuestStarSlot 
/// </summary>
public partial class TwitchDeleteGuestStarSlotOpt : Resource, ITwitcherSharp<TwitchDeleteGuestStarSlotOpt>
{
    private GodotObject _data;
	public string ShouldReinviteGuest { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteGuestStarSlotOpt object.
    /// </summary> 
    public static TwitchDeleteGuestStarSlotOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchDeleteGuestStarSlotOpt
		{
			ShouldReinviteGuest = data.Get("should_reinvite_guest").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_guest_star_slot.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(ShouldReinviteGuest != null) request.Set("should_reinvite_guest", ShouldReinviteGuest);
		return request;
	}
}
