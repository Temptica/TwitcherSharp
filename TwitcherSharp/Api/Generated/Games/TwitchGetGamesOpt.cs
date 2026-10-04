using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;


/// <summary> 
/// All optional parameters for TwitchAPI.GetGames 
/// </summary>
public partial class TwitchGetGamesOpt : RefCounted, ITwitcherSharp<TwitchGetGamesOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public string[]? Name { get; set; }
    public string[]? IgdbId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGamesOpt object.
    /// </summary> 
    public static TwitchGetGamesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGamesOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
            Name = data.Read("name", static v => v.AsStringArray()),
            IgdbId = data.Read("igdb_id", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_games.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(Name != null) request.SetValue("name", new Godot.Collections.Array<string>(Name));
        if(IgdbId != null) request.SetValue("igdb_id", new Godot.Collections.Array<string>(IgdbId));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
