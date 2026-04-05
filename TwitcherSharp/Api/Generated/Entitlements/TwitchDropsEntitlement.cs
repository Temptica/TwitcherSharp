using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchDropsEntitlement : RefCounted, ITwitcherSharp<TwitchDropsEntitlement>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string BenefitId { get; set; }
    public string Timestamp { get; set; }
    public string UserId { get; set; }
    public string GameId { get; set; }
    public string FulfillmentStatus { get; set; }
    public string LastUpdated { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropsEntitlement object.
    /// </summary> 
    public static TwitchDropsEntitlement FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchDropsEntitlement
        {
            Id = data.Get("id").AsString(),
            BenefitId = data.Get("benefit_id").AsString(),
            Timestamp = data.Get("timestamp").AsString(),
            UserId = data.Get("user_id").AsString(),
            GameId = data.Get("game_id").AsString(),
            FulfillmentStatus = data.Get("fulfillment_status").AsString(),
            LastUpdated = data.Get("last_updated").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drops_entitlement.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("benefit_id", BenefitId);
        request.Set("timestamp", Timestamp);
        request.Set("user_id", UserId);
        request.Set("game_id", GameId);
        request.Set("fulfillment_status", FulfillmentStatus);
        request.Set("last_updated", LastUpdated);
        return request;
    }

}
