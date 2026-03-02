using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUserEmotes 
/// </summary>
public partial class TwitchGetUserEmotesOpt : Resource, ITwitcherSharp<TwitchGetUserEmotesOpt>
{
    private GodotObject _data;
    public string After { get; set; }
    public string BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesOpt object.
    /// </summary> 
    public static TwitchGetUserEmotesOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetUserEmotesOpt
        {
            After = data.Get("after").AsString(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(After != null) request.Set("after", After);
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        return request;
    }

}
