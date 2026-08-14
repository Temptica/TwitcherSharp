using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;

public partial class TwitchGame : RefCounted, ITwitcherSharp<TwitchGame>
{
    private GodotObject? _data;
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? BoxArtUrl { get; set; }
    public string? IgdbId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGame object.
    /// </summary> 
    public static TwitchGame? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGame
        {
            Id = data.Get("id").AsString(),
            Name = data.Get("name").AsString(),
            BoxArtUrl = data.Get("box_art_url").AsString(),
            IgdbId = data.Get("igdb_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Name != null) request.Set("name", Name);
        if(BoxArtUrl != null) request.Set("box_art_url", BoxArtUrl);
        if(IgdbId != null) request.Set("igdb_id", IgdbId);
        return request;
    }

}
