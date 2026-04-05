using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchUserExtensionOverlayUpdate : RefCounted, ITwitcherSharp<TwitchUserExtensionOverlayUpdate>
{
    private GodotObject _data;
    public bool Active { get; set; }
    public string Id { get; set; }
    public string Version { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionOverlayUpdate object.
    /// </summary> 
    public static TwitchUserExtensionOverlayUpdate FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserExtensionOverlayUpdate
        {
            Active = data.Get("active").AsBool(),
            Id = data.Get("id").AsString(),
            Version = data.Get("version").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_overlay_update.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("active", Active);
        if(Id != null) request.Set("id", Id);
        if(Version != null) request.Set("version", Version);
        return request;
    }

}
