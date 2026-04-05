using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;


/// <summary> 
/// All optional parameters for TwitchAPI.GetFollowedChannels 
/// </summary>
public partial class TwitchGetFollowedChannelsOpt : RefCounted, ITwitcherSharp<TwitchGetFollowedChannelsOpt>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetFollowedChannelsOpt object.
    /// </summary> 
    public static TwitchGetFollowedChannelsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetFollowedChannelsOpt
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
