using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;


/// <summary> 
/// All optional parameters for TwitchAPI.GetEventsubSubscriptions 
/// </summary>
public partial class TwitchGetEventsubSubscriptionsOpt : RefCounted, ITwitcherSharp<TwitchGetEventsubSubscriptionsOpt>
{
    private GodotObject _data;
    public string Status { get; set; }
    public string Type { get; set; }
    public string UserId { get; set; }
    public string SubscriptionId { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEventsubSubscriptionsOpt object.
    /// </summary> 
    public static TwitchGetEventsubSubscriptionsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetEventsubSubscriptionsOpt
        {
            Status = data.Get("status").AsString(),
            Type = data.Get("type").AsString(),
            UserId = data.Get("user_id").AsString(),
            SubscriptionId = data.Get("subscription_id").AsString(),
            After = data.Get("after").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_eventsub_subscriptions.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Status != null) request.Set("status", Status);
        if(Type != null) request.Set("type", Type);
        if(UserId != null) request.Set("user_id", UserId);
        if(SubscriptionId != null) request.Set("subscription_id", SubscriptionId);
        if(After != null) request.Set("after", After);
        return request;
    }

}
