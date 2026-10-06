using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUserExtension : RefCounted, ITwitcherSharp<TwitchUserExtension>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool CanActivate { get; set; }
    public string[] Type { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtension object.
    /// </summary> 
    public static TwitchUserExtension? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserExtension
        {
            Id = data.Read("id", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
            CanActivate = data.Read("can_activate", static v => v.AsBool()),
            Type = data.Read("type", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_extension.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Version != null) request.SetValue("version", Version);
        if(Name != null) request.SetValue("name", Name);
        request.SetValue("can_activate", CanActivate);
        if(Type != null) request.SetValue("type", new Godot.Collections.Array<string>(Type));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
