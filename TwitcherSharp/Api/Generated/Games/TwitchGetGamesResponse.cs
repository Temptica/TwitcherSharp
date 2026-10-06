using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;

public partial class TwitchGetGamesResponse : RefCounted, ITwitcherSharp<TwitchGetGamesResponse>
{
    private Variant _data;
    public TwitchGame[] Data { get => field ??= _data.GetArray<TwitchGame>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGamesResponse object.
    /// </summary> 
    public static TwitchGetGamesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGamesResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_games.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
