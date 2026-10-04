using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStreamMarkerCreated : RefCounted, ITwitcherSharp<TwitchStreamMarkerCreated>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public int PositionSeconds { get; set; }
    public string Description { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamMarkerCreated object.
    /// </summary> 
    public static TwitchStreamMarkerCreated? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamMarkerCreated
        {
            Id = data.Read("id", static v => v.AsString()),
            CreatedAt = data.Read("created_at", static v => v.AsString()),
            PositionSeconds = data.Read("position_seconds", static v => v.AsInt32()),
            Description = data.Read("description", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_stream_marker_created.gd");
        if(Id != null) request.SetValue("id", Id);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        request.SetValue("position_seconds", PositionSeconds);
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
