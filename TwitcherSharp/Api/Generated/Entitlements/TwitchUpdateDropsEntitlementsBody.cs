using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchUpdateDropsEntitlementsBody : RefCounted, ITwitcherSharp<TwitchUpdateDropsEntitlementsBody>
{
    private GodotObject? _data;
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
            EntitlementIds = data.Get("entitlement_ids").AsStringArray(),
            FulfillmentStatus = data.Get("fulfillment_status").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_drops_entitlements.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(EntitlementIds != null) request.Set("entitlement_ids", new Godot.Collections.Array<string>(EntitlementIds));
        if(FulfillmentStatus != null) request.Set("fulfillment_status", FulfillmentStatus);
        return request;
    }

}
