using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTopContributions : RefCounted, ITwitcherSharpEventSub<TwitchTopContributions>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the user that made the contribution.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user’s login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The contribution method used. Possible values are: bits — Cheering with Bits.subscription — Subscription activity like subscribing or gifting subscriptions.other — Covers other contribution methods not listed.
    /// </summary>
    public string? Type { get; set; }

    /// <summary> 
    /// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
    /// </summary>
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchTopContributions object.
    /// </summary> 
    public static TwitchTopContributions? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchTopContributions
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            Total = data.Read("total", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_top_contributions.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Type != null) request.SetValue("type", Type);
        request.SetValue("total", Total);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
