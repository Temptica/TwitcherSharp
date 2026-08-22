using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchCategory : RefCounted, ITwitcherSharp<TwitchCategory>
{
    private GodotObject? _data;
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
            BoxArtUrl = data.Get("box_art_url").AsString(),
            Name = data.Get("name").AsString(),
            Id = data.Get("id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_category.gd");
        var request = script.Call("new").AsGodotObject();
        if(BoxArtUrl != null) request.Set("box_art_url", BoxArtUrl);
        if(Name != null) request.Set("name", Name);
        if(Id != null) request.Set("id", Id);
        return request;
    }

}
