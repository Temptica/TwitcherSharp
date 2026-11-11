using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;


/// <summary> 
/// All optional parameters for TwitchAPI.DeleteGuestStarSlot 
/// </summary>
public partial class TwitchDeleteGuestStarSlotOpt : RefCounted, ITwitcherSharp<TwitchDeleteGuestStarSlotOpt>
{
    private GodotObject? _data;
    public bool? ShouldReinviteGuest { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteGuestStarSlotOpt object.
    /// </summary> 
    public static TwitchDeleteGuestStarSlotOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDeleteGuestStarSlotOpt
        {
            ShouldReinviteGuest = data.Get("should_reinvite_guest").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_guest_star_slot.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(ShouldReinviteGuest.HasValue) request.Set("should_reinvite_guest", ShouldReinviteGuest.Value);
        return request;
    }

}
