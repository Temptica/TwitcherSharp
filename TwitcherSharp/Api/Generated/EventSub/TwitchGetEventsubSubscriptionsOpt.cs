using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;


/// <summary> 
/// All optional parameters for TwitchAPI.GetEventsubSubscriptions 
/// </summary>
public partial class TwitchGetEventsubSubscriptionsOpt : RefCounted, ITwitcherSharp<TwitchGetEventsubSubscriptionsOpt>
{
    private Variant _data;
    public string? Status { get; set; }
    public string? Type { get; set; }
    public string? UserId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? ConduitId { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEventsubSubscriptionsOpt object.
    /// </summary> 
    public static TwitchGetEventsubSubscriptionsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetEventsubSubscriptionsOpt
        {
            Status = data.Read("status", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            SubscriptionId = data.Read("subscription_id", static v => v.AsString()),
            ConduitId = data.Read("conduit_id", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_eventsub_subscriptions.gd", "Opt");
        if(Status != null) request.SetValue("status", Status);
        if(Type != null) request.SetValue("type", Type);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(SubscriptionId != null) request.SetValue("subscription_id", SubscriptionId);
        if(ConduitId != null) request.SetValue("conduit_id", ConduitId);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
