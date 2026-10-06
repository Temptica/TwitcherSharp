using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchUpdateDropsEntitlementsResponse : RefCounted, ITwitcherSharp<TwitchUpdateDropsEntitlementsResponse>
{
    private Variant _data;
    public TwitchDropsEntitlementUpdated[] Data { get => field ??= _data.GetArray<TwitchDropsEntitlementUpdated>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateDropsEntitlementsResponse object.
    /// </summary> 
    public static TwitchUpdateDropsEntitlementsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateDropsEntitlementsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_drops_entitlements.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
