using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchBroadcasterSubscription : RefCounted, ITwitcherSharp<TwitchBroadcasterSubscription>
{
    private GodotObject? _data;
    public string? BroadcasterId { get; set; }
    public string? BroadcasterLogin { get; set; }
    public string? BroadcasterName { get; set; }
    public string? GifterId { get; set; }
    public string? GifterLogin { get; set; }
    public string? GifterName { get; set; }
    public bool IsGift { get; set; }
    public string? PlanName { get; set; }
    public string? Tier { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBroadcasterSubscription object.
    /// </summary> 
    public static TwitchBroadcasterSubscription? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBroadcasterSubscription
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            GifterId = data.Get("gifter_id").AsString(),
            GifterLogin = data.Get("gifter_login").AsString(),
            GifterName = data.Get("gifter_name").AsString(),
            IsGift = data.Get("is_gift").AsBool(),
            PlanName = data.Get("plan_name").AsString(),
            Tier = data.Get("tier").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_broadcaster_subscription.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(GifterId != null) request.Set("gifter_id", GifterId);
        if(GifterLogin != null) request.Set("gifter_login", GifterLogin);
        if(GifterName != null) request.Set("gifter_name", GifterName);
        request.Set("is_gift", IsGift);
        if(PlanName != null) request.Set("plan_name", PlanName);
        if(Tier != null) request.Set("tier", Tier);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserName != null) request.Set("user_name", UserName);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        return request;
    }

}
