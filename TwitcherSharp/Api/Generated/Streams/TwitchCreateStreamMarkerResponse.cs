using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchCreateStreamMarkerResponse : RefCounted, ITwitcherSharp<TwitchCreateStreamMarkerResponse>
{
    private GodotObject _data;
    public TwitchStreamMarkerCreated[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateStreamMarkerResponse object.
    /// </summary> 
    public static TwitchCreateStreamMarkerResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCreateStreamMarkerResponse
        {
            Data = dataArray.Select(TwitchStreamMarkerCreated.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_stream_marker.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
