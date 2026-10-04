using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;

public partial class TwitchGame : RefCounted, ITwitcherSharp<TwitchGame>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BoxArtUrl { get; set; } = null!;
    public string IgdbId { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGame object.
    /// </summary> 
    public static TwitchGame? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGame
        {
            Id = data.Read("id", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
            BoxArtUrl = data.Read("box_art_url", static v => v.AsString()),
            IgdbId = data.Read("igdb_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_game.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Name != null) request.SetValue("name", Name);
        if(BoxArtUrl != null) request.SetValue("box_art_url", BoxArtUrl);
        if(IgdbId != null) request.SetValue("igdb_id", IgdbId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
