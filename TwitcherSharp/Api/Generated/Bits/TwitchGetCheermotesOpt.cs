using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCheermotes 
/// </summary>
public partial class TwitchGetCheermotesOpt : RefCounted, ITwitcherSharp<TwitchGetCheermotesOpt>
{
    private GodotObject? _data;
    public string? BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesOpt object.
    /// </summary> 
    public static TwitchGetCheermotesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCheermotesOpt
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        return request;
    }

}
