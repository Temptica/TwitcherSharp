using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Raids;


/// <summary> 
/// All optional parameters for TwitchAPI.StartARaid 
/// </summary>
public partial class TwitchStartARaidOpt : RefCounted, ITwitcherSharp<TwitchStartARaidOpt>
{
    private GodotObject _data;
    public string FromBroadcasterId { get; set; }
    public string ToBroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartARaidOpt object.
    /// </summary> 
    public static TwitchStartARaidOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchStartARaidOpt
        {
            FromBroadcasterId = data.Get("from_broadcaster_id").AsString(),
            ToBroadcasterId = data.Get("to_broadcaster_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_a_raid.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(FromBroadcasterId != null) request.Set("from_broadcaster_id", FromBroadcasterId);
        if(ToBroadcasterId != null) request.Set("to_broadcaster_id", ToBroadcasterId);
        return request;
    }

}
