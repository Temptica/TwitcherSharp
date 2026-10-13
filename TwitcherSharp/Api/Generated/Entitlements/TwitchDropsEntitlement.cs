using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchDropsEntitlement : RefCounted, ITwitcherSharp<TwitchDropsEntitlement>
{
    private Variant _data;
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
            Id = data.ReadAsString("id"),
            BenefitId = data.ReadAsString("benefit_id"),
            Timestamp = data.ReadAsString("timestamp"),
            UserId = data.ReadAsString("user_id"),
            GameId = data.ReadAsString("game_id"),
            FulfillmentStatus = data.ReadAsString("fulfillment_status"),
            LastUpdated = data.ReadAsString("last_updated"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_drops_entitlement.gd");
        if(Id != null) request.SetValue("id", Id);
        if(BenefitId != null) request.SetValue("benefit_id", BenefitId);
        if(Timestamp != null) request.SetValue("timestamp", Timestamp);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(FulfillmentStatus != null) request.SetValue("fulfillment_status", FulfillmentStatus);
        if(LastUpdated != null) request.SetValue("last_updated", LastUpdated);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
