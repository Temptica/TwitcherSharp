using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchDropsEntitlement : RefCounted, ITwitcherSharp<TwitchDropsEntitlement>
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string BenefitId { get; set; } = null!;
    public string Timestamp { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string FulfillmentStatus { get; set; } = null!;
    public string LastUpdated { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchDropsEntitlement object.
    /// </summary> 
    public static TwitchDropsEntitlement? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDropsEntitlement
        {
            Id = data.Get("id").AsString(),
            BenefitId = data.Get("benefit_id").AsString(),
            Timestamp = data.Get("timestamp").AsString(),
            UserId = data.Get("user_id").AsString(),
            GameId = data.Get("game_id").AsString(),
            FulfillmentStatus = data.Get("fulfillment_status").AsString(),
            LastUpdated = data.Get("last_updated").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drops_entitlement.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BenefitId != null) request.Set("benefit_id", BenefitId);
        if(Timestamp != null) request.Set("timestamp", Timestamp);
        if(UserId != null) request.Set("user_id", UserId);
        if(GameId != null) request.Set("game_id", GameId);
        if(FulfillmentStatus != null) request.Set("fulfillment_status", FulfillmentStatus);
        if(LastUpdated != null) request.Set("last_updated", LastUpdated);
        return request;
    }

}
