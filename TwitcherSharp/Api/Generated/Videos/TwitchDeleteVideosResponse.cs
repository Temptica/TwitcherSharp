using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

public partial class TwitchDeleteVideosResponse : RefCounted, ITwitcherSharp<TwitchDeleteVideosResponse>
{
    private Variant _data;
    public string[] Data { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteVideosResponse object.
    /// </summary> 
    public static TwitchDeleteVideosResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDeleteVideosResponse
        {
            Data = data.Read("data", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_delete_videos.gd", "Response");
        if(Data != null) request.SetValue("data", new Godot.Collections.Array<string>(Data));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
