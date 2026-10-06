using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;


/// <summary> 
/// All optional parameters for TwitchAPI.GetFollowedChannels 
/// </summary>
public partial class TwitchGetFollowedChannelsOpt : RefCounted, ITwitcherSharp<TwitchGetFollowedChannelsOpt>
{
    private Variant _data;
    public string? BroadcasterId { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetFollowedChannelsOpt object.
    /// </summary> 
    public static TwitchGetFollowedChannelsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetFollowedChannelsOpt
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_followed_channels.gd", "Opt");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
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
