using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchUserExtensionOverlay : RefCounted, ITwitcherSharp<TwitchUserExtensionOverlay>
{
    private GodotObject _data;
    public bool Active { get; set; }
    public string Id { get; set; }
    public string Version { get; set; }
    public string Name { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionOverlay object.
    /// </summary> 
    public static TwitchUserExtensionOverlay FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserExtensionOverlay
        {
            Active = data.Get("active").AsBool(),
            Id = data.Get("id").AsString(),
            Version = data.Get("version").AsString(),
            Name = data.Get("name").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_overlay.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("active", Active);
        if(Id != null) request.Set("id", Id);
        if(Version != null) request.Set("version", Version);
        if(Name != null) request.Set("name", Name);
        return request;
    }

}
