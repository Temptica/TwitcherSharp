using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchUserExtensionPanelUpdate : RefCounted, ITwitcherSharp<TwitchUserExtensionPanelUpdate>
{
    private Variant _data;
    public bool Active { get; set; }
    public string? Id { get; set; }
    public string? Version { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionPanelUpdate object.
    /// </summary> 
    public static TwitchUserExtensionPanelUpdate? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserExtensionPanelUpdate
        {
            Active = data.Read("active", static v => v.AsBool()),
            Id = data.Read("id", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_extension_panel_update.gd");
        request.SetValue("active", Active);
        if(Id != null) request.SetValue("id", Id);
        if(Version != null) request.SetValue("version", Version);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
