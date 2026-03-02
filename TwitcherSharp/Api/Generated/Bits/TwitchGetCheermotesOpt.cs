using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCheermotes 
/// </summary>
public partial class TwitchGetCheermotesOpt : Resource, ITwitcherSharp<TwitchGetCheermotesOpt>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesOpt object.
    /// </summary> 
    public static TwitchGetCheermotesOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetCheermotesOpt
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
        };
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
