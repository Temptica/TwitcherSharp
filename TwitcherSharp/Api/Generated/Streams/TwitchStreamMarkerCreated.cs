using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStreamMarkerCreated : RefCounted, ITwitcherSharp<TwitchStreamMarkerCreated>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string CreatedAt { get; set; }
    public int PositionSeconds { get; set; }
    public string Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamMarkerCreated object.
    /// </summary> 
    public static TwitchStreamMarkerCreated FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchStreamMarkerCreated
        {
            Id = data.Get("id").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            PositionSeconds = data.Get("position_seconds").AsInt32(),
            Description = data.Get("description").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_marker_created.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("created_at", CreatedAt);
        request.Set("position_seconds", PositionSeconds);
        request.Set("description", Description);
        return request;
    }

}
