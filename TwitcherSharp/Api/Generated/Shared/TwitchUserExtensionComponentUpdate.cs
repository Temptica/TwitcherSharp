using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchUserExtensionComponentUpdate : RefCounted, ITwitcherSharp<TwitchUserExtensionComponentUpdate>
{
    private Variant _data;
    public bool Active { get; set; }
    public string? Id { get; set; }
    public string? Version { get; set; }
    public int? X { get; set; }
    public int? Y { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionComponentUpdate object.
    /// </summary> 
    public static TwitchUserExtensionComponentUpdate? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserExtensionComponentUpdate
        {
            Active = data.Read("active", static v => v.AsBool()),
            Id = data.Read("id", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
            X = data.Read("x", static v => v.AsInt32()),
            Y = data.Read("y", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_extension_component_update.gd");
        request.SetValue("active", Active);
        if(Id != null) request.SetValue("id", Id);
        if(Version != null) request.SetValue("version", Version);
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
