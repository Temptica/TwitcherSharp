using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;


/// <summary> 
/// All optional parameters for TwitchAPI.UpdateGuestStarSlot 
/// </summary>
public partial class TwitchUpdateGuestStarSlotOpt : RefCounted, ITwitcherSharp<TwitchUpdateGuestStarSlotOpt>
{
    private Variant _data;
    public string? DestinationSlotId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateGuestStarSlotOpt object.
    /// </summary> 
    public static TwitchUpdateGuestStarSlotOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateGuestStarSlotOpt
        {
            DestinationSlotId = data.Read("destination_slot_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_guest_star_slot.gd", "Opt");
        if(DestinationSlotId != null) request.SetValue("destination_slot_id", DestinationSlotId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
