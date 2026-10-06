using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchUpdateDropsEntitlementsBody : RefCounted, ITwitcherSharp<TwitchUpdateDropsEntitlementsBody>
{
    private Variant _data;
    public string[]? EntitlementIds { get; set; }
    public string? FulfillmentStatus { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateDropsEntitlementsBody object.
    /// </summary> 
    public static TwitchUpdateDropsEntitlementsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateDropsEntitlementsBody
        {
            EntitlementIds = data.Read("entitlement_ids", static v => v.AsStringArray()),
            FulfillmentStatus = data.Read("fulfillment_status", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_drops_entitlements.gd", "Body");
        if(EntitlementIds != null) request.SetValue("entitlement_ids", new Godot.Collections.Array<string>(EntitlementIds));
        if(FulfillmentStatus != null) request.SetValue("fulfillment_status", FulfillmentStatus);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
