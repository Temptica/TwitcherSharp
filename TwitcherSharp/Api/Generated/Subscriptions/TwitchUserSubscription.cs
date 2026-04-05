using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchUserSubscription : RefCounted, ITwitcherSharp<TwitchUserSubscription>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string BroadcasterLogin { get; set; }
    public string BroadcasterName { get; set; }
    public string GifterId { get; set; }
    public string GifterLogin { get; set; }
    public string GifterName { get; set; }
    public bool IsGift { get; set; }
    public string Tier { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserSubscription object.
    /// </summary> 
    public static TwitchUserSubscription FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserSubscription
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            GifterId = data.Get("gifter_id").AsString(),
            GifterLogin = data.Get("gifter_login").AsString(),
            GifterName = data.Get("gifter_name").AsString(),
            IsGift = data.Get("is_gift").AsBool(),
            Tier = data.Get("tier").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_subscription.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("broadcaster_login", BroadcasterLogin);
        request.Set("broadcaster_name", BroadcasterName);
        if(GifterId != null) request.Set("gifter_id", GifterId);
        if(GifterLogin != null) request.Set("gifter_login", GifterLogin);
        if(GifterName != null) request.Set("gifter_name", GifterName);
        request.Set("is_gift", IsGift);
        request.Set("tier", Tier);
        return request;
    }

}
