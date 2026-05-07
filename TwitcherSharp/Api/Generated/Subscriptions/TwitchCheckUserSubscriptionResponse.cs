using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchCheckUserSubscriptionResponse : RefCounted, ITwitcherSharp<TwitchCheckUserSubscriptionResponse>
{
    private GodotObject _data;
    public TwitchUserSubscription[] Data { get => field ??= _data?.GetArray<TwitchUserSubscription>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckUserSubscriptionResponse object.
    /// </summary> 
    public static TwitchCheckUserSubscriptionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCheckUserSubscriptionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_user_subscription.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
