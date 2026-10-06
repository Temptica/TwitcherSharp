using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchCreateStreamMarkerBody : RefCounted, ITwitcherSharp<TwitchCreateStreamMarkerBody>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string? Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateStreamMarkerBody object.
    /// </summary> 
    public static TwitchCreateStreamMarkerBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateStreamMarkerBody
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            Description = data.Read("description", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_stream_marker.gd", "Body");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(Description != null) request.SetValue("description", Description);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
