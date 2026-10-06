using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;


/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelFollowers 
/// </summary>
public partial class TwitchGetChannelFollowersOpt : RefCounted, ITwitcherSharp<TwitchGetChannelFollowersOpt>
{
    private Variant _data;
    public string? UserId { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelFollowersOpt object.
    /// </summary> 
    public static TwitchGetChannelFollowersOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelFollowersOpt
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_followers.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(First.HasValue) request.SetValue("first", First.Value);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
