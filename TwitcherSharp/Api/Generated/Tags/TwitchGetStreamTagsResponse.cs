using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchGetStreamTagsResponse : RefCounted, ITwitcherSharp<TwitchGetStreamTagsResponse>
{
    private Variant _data;
    public TwitchStreamTag[] Data { get => field ??= _data.GetArray<TwitchStreamTag>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamTagsResponse object.
    /// </summary> 
    public static TwitchGetStreamTagsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetStreamTagsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_stream_tags.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
