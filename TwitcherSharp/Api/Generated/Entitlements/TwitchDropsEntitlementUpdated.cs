using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchDropsEntitlementUpdated : RefCounted, ITwitcherSharp<TwitchDropsEntitlementUpdated>
{
    private Variant _data;
    public string Status { get; set; } = null!;
    public string[] Ids { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchDropsEntitlementUpdated object.
    /// </summary> 
    public static TwitchDropsEntitlementUpdated? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDropsEntitlementUpdated
        {
            Status = data.ReadAsString("status"),
            Ids = data.ReadAsStringArray("ids"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_drops_entitlement_updated.gd");
        if(Status != null) request.SetValue("status", Status);
        if(Ids != null) request.SetValue("ids", new Godot.Collections.Array<string>(Ids));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
