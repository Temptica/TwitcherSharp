using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchUserExtensionOverlay : RefCounted, ITwitcherSharp<TwitchUserExtensionOverlay>
{
    private Variant _data;
    public bool Active { get; set; }
    public string? Id { get; set; }
    public string? Version { get; set; }
    public string? Name { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionOverlay object.
    /// </summary> 
    public static TwitchUserExtensionOverlay? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserExtensionOverlay
        {
            Active = data.Read("active", static v => v.AsBool()),
            Id = data.Read("id", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_extension_overlay.gd");
        request.SetValue("active", Active);
        if(Id != null) request.SetValue("id", Id);
        if(Version != null) request.SetValue("version", Version);
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
