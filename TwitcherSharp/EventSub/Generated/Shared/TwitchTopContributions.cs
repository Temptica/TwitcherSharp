using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTopContributions : RefCounted, ITwitcherSharpEventSub<TwitchTopContributions>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The ID of the user that made the contribution.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user’s login name.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user’s display name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The contribution method used. Possible values are: bits — Cheering with Bits.subscription — Subscription activity like subscribing or gifting subscriptions.other — Covers other contribution methods not listed.
    /// </summary>
    public string Type { get; set; }

    /// <summary> 
    /// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
    /// </summary>
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchTopContributions object.
    /// </summary> 
    public static TwitchTopContributions FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchTopContributions
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Type = data.Get("type").AsString(),
            Total = data.Get("total").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_top_contributions.gd");
        var request = script.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("type", Type);
        request.Set("total", Total);
        return request;
    }
}
