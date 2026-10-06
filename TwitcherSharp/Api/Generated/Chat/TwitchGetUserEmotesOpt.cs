using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUserEmotes 
/// </summary>
public partial class TwitchGetUserEmotesOpt : RefCounted, ITwitcherSharp<TwitchGetUserEmotesOpt>
{
    private Variant _data;
    public string? After { get; set; }
    public string? BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesOpt object.
    /// </summary> 
    public static TwitchGetUserEmotesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserEmotesOpt
        {
            After = data.Read("after", static v => v.AsString()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_emotes.gd", "Opt");
        if(After != null) request.SetValue("after", After);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
