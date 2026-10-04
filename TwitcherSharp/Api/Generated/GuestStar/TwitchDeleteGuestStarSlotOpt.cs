using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;


/// <summary> 
/// All optional parameters for TwitchAPI.DeleteGuestStarSlot 
/// </summary>
public partial class TwitchDeleteGuestStarSlotOpt : RefCounted, ITwitcherSharp<TwitchDeleteGuestStarSlotOpt>
{
    private Variant _data;
    public string? ShouldReinviteGuest { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteGuestStarSlotOpt object.
    /// </summary> 
    public static TwitchDeleteGuestStarSlotOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDeleteGuestStarSlotOpt
        {
            ShouldReinviteGuest = data.Read("should_reinvite_guest", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_delete_guest_star_slot.gd", "Opt");
        if(ShouldReinviteGuest != null) request.SetValue("should_reinvite_guest", ShouldReinviteGuest);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
