using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;


/// <summary> 
/// All optional parameters for TwitchAPI.GetTopGames 
/// </summary>
public partial class TwitchGetTopGamesOpt : RefCounted, ITwitcherSharp<TwitchGetTopGamesOpt>
{
    private Variant _data;
    public int? First { get; set; }
    public string? After { get; set; }
    public string? Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTopGamesOpt object.
    /// </summary> 
    public static TwitchGetTopGamesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetTopGamesOpt
        {
            First = data.ReadAsInt32("first"),
            After = data.ReadAsString("after"),
            Before = data.ReadAsString("before"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_top_games.gd", "Opt");
        if(First.HasValue) request.SetValue("first", First.Value);
        if(After != null) request.SetValue("after", After);
        if(Before != null) request.SetValue("before", Before);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
