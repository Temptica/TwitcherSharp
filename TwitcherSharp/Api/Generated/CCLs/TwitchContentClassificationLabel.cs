using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;

public partial class TwitchContentClassificationLabel : RefCounted, ITwitcherSharp<TwitchContentClassificationLabel>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchContentClassificationLabel object.
    /// </summary> 
    public static TwitchContentClassificationLabel FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchContentClassificationLabel
        {
            Id = data.Get("id").AsString(),
            Description = data.Get("description").AsString(),
            Name = data.Get("name").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_content_classification_label.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("description", Description);
        request.Set("name", Name);
        return request;
    }

}
