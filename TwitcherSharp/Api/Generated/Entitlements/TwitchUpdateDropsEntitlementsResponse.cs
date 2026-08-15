using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchUpdateDropsEntitlementsResponse : RefCounted, ITwitcherSharp<TwitchUpdateDropsEntitlementsResponse>
{
    private GodotObject _data;
    public TwitchDropsEntitlementUpdated[] Data { get => field ??= _data?.GetArray<TwitchDropsEntitlementUpdated>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateDropsEntitlementsResponse object.
    /// </summary> 
    public static TwitchUpdateDropsEntitlementsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateDropsEntitlementsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_drops_entitlements.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
