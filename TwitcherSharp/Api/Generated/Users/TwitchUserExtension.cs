using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUserExtension : RefCounted, ITwitcherSharp<TwitchUserExtension>
{
    private GodotObject? _data;
    public string? Id { get; set; }
    public string? Version { get; set; }
    public string? Name { get; set; }
    public bool CanActivate { get; set; }
    public string[]? Type { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtension object.
    /// </summary> 
    public static TwitchUserExtension? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserExtension
        {
            Id = data.Get("id").AsString(),
            Version = data.Get("version").AsString(),
            Name = data.Get("name").AsString(),
            CanActivate = data.Get("can_activate").AsBool(),
            Type = data.Get("type").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Version != null) request.Set("version", Version);
        if(Name != null) request.Set("name", Name);
        request.Set("can_activate", CanActivate);
        if(Type != null) request.Set("type", new Godot.Collections.Array<string>(Type));
        return request;
    }

}
