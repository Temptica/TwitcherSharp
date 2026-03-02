using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchCreateStreamMarkerBody : Resource, ITwitcherSharp<TwitchCreateStreamMarkerBody>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateStreamMarkerBody object.
    /// </summary> 
    public static TwitchCreateStreamMarkerBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCreateStreamMarkerBody
        {
            UserId = data.Get("user_id").AsString(),
            Description = data.Get("description").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_stream_marker.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        if(Description != null) request.Set("description", Description);
        return request;
    }

}
