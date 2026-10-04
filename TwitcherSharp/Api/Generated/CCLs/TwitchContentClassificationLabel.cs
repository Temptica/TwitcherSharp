using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;

public partial class TwitchContentClassificationLabel : RefCounted, ITwitcherSharp<TwitchContentClassificationLabel>
{
    private Variant _data;
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
            Id = data.Read("id", static v => v.AsString()),
            Description = data.Read("description", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_content_classification_label.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Description != null) request.SetValue("description", Description);
        if(Name != null) request.SetValue("name", Name);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
