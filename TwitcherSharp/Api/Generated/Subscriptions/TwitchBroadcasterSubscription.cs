using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchBroadcasterSubscription : RefCounted, ITwitcherSharp<TwitchBroadcasterSubscription>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string GifterId { get; set; } = null!;
    public string GifterLogin { get; set; } = null!;
    public string GifterName { get; set; } = null!;
    public bool IsGift { get; set; }
    public string PlanName { get; set; } = null!;
    public string Tier { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserLogin { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchBroadcasterSubscription object.
    /// </summary> 
    public static TwitchBroadcasterSubscription? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBroadcasterSubscription
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            GifterId = data.Read("gifter_id", static v => v.AsString()),
            GifterLogin = data.Read("gifter_login", static v => v.AsString()),
            GifterName = data.Read("gifter_name", static v => v.AsString()),
            IsGift = data.Read("is_gift", static v => v.AsBool()),
            PlanName = data.Read("plan_name", static v => v.AsString()),
            Tier = data.Read("tier", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_broadcaster_subscription.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(GifterId != null) request.SetValue("gifter_id", GifterId);
        if(GifterLogin != null) request.SetValue("gifter_login", GifterLogin);
        if(GifterName != null) request.SetValue("gifter_name", GifterName);
        request.SetValue("is_gift", IsGift);
        if(PlanName != null) request.SetValue("plan_name", PlanName);
        if(Tier != null) request.SetValue("tier", Tier);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
