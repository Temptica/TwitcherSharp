using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchUserExtensionComponent : RefCounted, ITwitcherSharp<TwitchUserExtensionComponent>
{
    private Variant _data;
    public bool Active { get; set; }
    public string? Id { get; set; }
    public string? Version { get; set; }
    public string? Name { get; set; }
    public int? X { get; set; }
    public int? Y { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionComponent object.
    /// </summary> 
    public static TwitchUserExtensionComponent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserExtensionComponent
        {
            Active = data.Read("active", static v => v.AsBool()),
            Id = data.Read("id", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
            X = data.Read("x", static v => v.AsInt32()),
            Y = data.Read("y", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_extension_component.gd");
        request.SetValue("active", Active);
        if(Id != null) request.SetValue("id", Id);
        if(Version != null) request.SetValue("version", Version);
        if(Name != null) request.SetValue("name", Name);
        if(X.HasValue) request.SetValue("x", X.Value);
        if(Y.HasValue) request.SetValue("y", Y.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
