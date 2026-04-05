using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchUpdateDropsEntitlementsResponse : RefCounted, ITwitcherSharp<TwitchUpdateDropsEntitlementsResponse>
{
    private GodotObject _data;
    public TwitchDropsEntitlementUpdated[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateDropsEntitlementsResponse object.
    /// </summary> 
    public static TwitchUpdateDropsEntitlementsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchUpdateDropsEntitlementsResponse
        {
            Data = dataArray.Select(TwitchDropsEntitlementUpdated.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_drops_entitlements.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
