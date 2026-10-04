using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetBroadcasterSubscriptions 
/// </summary>
public partial class TwitchGetBroadcasterSubscriptionsOpt : RefCounted, ITwitcherSharp<TwitchGetBroadcasterSubscriptionsOpt>
{
    private Variant _data;
    public string[]? UserId { get; set; }
    public string? First { get; set; }
    public string? After { get; set; }
    public string? Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBroadcasterSubscriptionsOpt object.
    /// </summary> 
    public static TwitchGetBroadcasterSubscriptionsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetBroadcasterSubscriptionsOpt
        {
            UserId = data.Read("user_id", static v => v.AsStringArray()),
            First = data.Read("first", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
            Before = data.Read("before", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", new Godot.Collections.Array<string>(UserId));
        if(First != null) request.SetValue("first", First);
        if(After != null) request.SetValue("after", After);
        if(Before != null) request.SetValue("before", Before);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
