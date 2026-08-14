using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchDropsEntitlementUpdated : RefCounted, ITwitcherSharp<TwitchDropsEntitlementUpdated>
{
    private GodotObject? _data;
    public string? Status { get; set; }
    public string[]? Ids { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropsEntitlementUpdated object.
    /// </summary> 
    public static TwitchDropsEntitlementUpdated? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDropsEntitlementUpdated
        {
            Status = data.Get("status").AsString(),
            Ids = data.Get("ids").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drops_entitlement_updated.gd");
        var request = script.Call("new").AsGodotObject();
        if(Status != null) request.Set("status", Status);
        if(Ids != null) request.Set("ids", new Godot.Collections.Array<string>(Ids));
        return request;
    }

}
