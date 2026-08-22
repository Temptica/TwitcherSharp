using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;

public partial class TwitchContentClassificationLabel : RefCounted, ITwitcherSharp<TwitchContentClassificationLabel>
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Name { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchContentClassificationLabel object.
    /// </summary> 
    public static TwitchContentClassificationLabel? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchContentClassificationLabel
        {
            Id = data.Get("id").AsString(),
            Description = data.Get("description").AsString(),
            Name = data.Get("name").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_content_classification_label.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Description != null) request.Set("description", Description);
        if(Name != null) request.Set("name", Name);
        return request;
    }

}
