using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

public partial class TwitchDeleteVideosResponse : RefCounted, ITwitcherSharp<TwitchDeleteVideosResponse>
{
    private GodotObject? _data;
    public string[]? Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteVideosResponse object.
    /// </summary> 
    public static TwitchDeleteVideosResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDeleteVideosResponse
        {
            Data = data.Get("data").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_videos.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<string>(Data));
        return request;
    }

}
