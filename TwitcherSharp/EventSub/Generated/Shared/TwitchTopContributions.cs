using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTopContributions : Resource, ITwitcherSharpEventSub<TwitchTopContributions>
{
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
    public TwitchType[] Type { get; set; }

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
        var typeArray = data.Get("type").AsGodotArray<GodotObject>();
        return new TwitchTopContributions
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Type = typeArray.Select(TwitchType.FromObject).ToArray(),
            Total = data.Get("total").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_top_contributions.gd");
        var twitchTopContributionsClass = script.Get("TwitchTopContributions").AsGodotObject();
        var request = twitchTopContributionsClass.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("type", Type);
        request.Set("total", Total);
        return request;
    }

    public partial class TwitchType : Resource, ITwitcherSharpEventSub<TwitchType>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchType object.
        /// </summary> 
        public static TwitchType FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchType
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_top_contributions.gd");
            var typeClass = script.Get("Type").AsGodotObject();
            var request = typeClass.Call("new").AsGodotObject();
            return request;
        }
    }
}
