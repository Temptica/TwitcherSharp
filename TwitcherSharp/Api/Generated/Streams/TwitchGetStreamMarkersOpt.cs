using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;


/// <summary> 
/// All optional parameters for TwitchAPI.GetStreamMarkers 
/// </summary>
public partial class TwitchGetStreamMarkersOpt : RefCounted, ITwitcherSharp<TwitchGetStreamMarkersOpt>
{
    private Variant _data;
    public string? UserId { get; set; }
    public string? VideoId { get; set; }
    public string? First { get; set; }
    public string? Before { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamMarkersOpt object.
    /// </summary> 
    public static TwitchGetStreamMarkersOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetStreamMarkersOpt
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            VideoId = data.Read("video_id", static v => v.AsString()),
            First = data.Read("first", static v => v.AsString()),
            Before = data.Read("before", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_stream_markers.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(VideoId != null) request.SetValue("video_id", VideoId);
        if(First != null) request.SetValue("first", First);
        if(Before != null) request.SetValue("before", Before);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
