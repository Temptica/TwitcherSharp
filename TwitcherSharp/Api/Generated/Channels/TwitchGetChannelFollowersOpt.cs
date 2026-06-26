using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;


/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelFollowers 
/// </summary>
public partial class TwitchGetChannelFollowersOpt : RefCounted, ITwitcherSharp<TwitchGetChannelFollowersOpt>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelFollowersOpt object.
    /// </summary> 
    public static TwitchGetChannelFollowersOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelFollowersOpt
        {
            UserId = data.Get("user_id").AsString(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_followers.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
