using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchUserSubscription : RefCounted, ITwitcherSharp<TwitchUserSubscription>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string? GifterId { get; set; }
    public string? GifterLogin { get; set; }
    public string? GifterName { get; set; }
    public bool IsGift { get; set; }
    public string Tier { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserSubscription object.
    /// </summary> 
    public static TwitchUserSubscription? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserSubscription
        {
            BroadcasterId = data.ReadAsString("broadcaster_id"),
            BroadcasterLogin = data.ReadAsString("broadcaster_login"),
            BroadcasterName = data.ReadAsString("broadcaster_name"),
            GifterId = data.ReadAsString("gifter_id"),
            GifterLogin = data.ReadAsString("gifter_login"),
            GifterName = data.ReadAsString("gifter_name"),
            IsGift = data.ReadAsBool("is_gift"),
            Tier = data.ReadAsString("tier"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_subscription.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(GifterId != null) request.SetValue("gifter_id", GifterId);
        if(GifterLogin != null) request.SetValue("gifter_login", GifterLogin);
        if(GifterName != null) request.SetValue("gifter_name", GifterName);
        request.SetValue("is_gift", IsGift);
        if(Tier != null) request.SetValue("tier", Tier);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
