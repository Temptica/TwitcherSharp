using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;


/// <summary> 
/// All optional parameters for TwitchAPI.GetDropsEntitlements 
/// </summary>
public partial class TwitchGetDropsEntitlementsOpt : RefCounted, ITwitcherSharp<TwitchGetDropsEntitlementsOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public string? UserId { get; set; }
    public string? GameId { get; set; }
    public string? FulfillmentStatus { get; set; }
    public string? After { get; set; }
    public int? First { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetDropsEntitlementsOpt object.
    /// </summary> 
    public static TwitchGetDropsEntitlementsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetDropsEntitlementsOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
            UserId = data.Read("user_id", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            FulfillmentStatus = data.Read("fulfillment_status", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_drops_entitlements.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(UserId != null) request.SetValue("user_id", UserId);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(FulfillmentStatus != null) request.SetValue("fulfillment_status", FulfillmentStatus);
        if(After != null) request.SetValue("after", After);
        if(First.HasValue) request.SetValue("first", First.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
