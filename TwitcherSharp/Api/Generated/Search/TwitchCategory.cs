using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchCategory : RefCounted, ITwitcherSharp<TwitchCategory>
{
    private Variant _data;
    public string BoxArtUrl { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCategory object.
    /// </summary> 
    public static TwitchCategory? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCategory
        {
            BoxArtUrl = data.Read("box_art_url", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_category.gd");
        if(BoxArtUrl != null) request.SetValue("box_art_url", BoxArtUrl);
        if(Name != null) request.SetValue("name", Name);
        if(Id != null) request.SetValue("id", Id);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
