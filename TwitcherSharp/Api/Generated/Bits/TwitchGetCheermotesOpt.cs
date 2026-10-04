using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCheermotes 
/// </summary>
public partial class TwitchGetCheermotesOpt : RefCounted, ITwitcherSharp<TwitchGetCheermotesOpt>
{
    private Variant _data;
    public string? BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesOpt object.
    /// </summary> 
    public static TwitchGetCheermotesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCheermotesOpt
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_cheermotes.gd", "Opt");
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
