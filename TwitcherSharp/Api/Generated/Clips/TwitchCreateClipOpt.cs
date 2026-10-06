using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;


/// <summary> 
/// All optional parameters for TwitchAPI.CreateClip 
/// </summary>
public partial class TwitchCreateClipOpt : RefCounted, ITwitcherSharp<TwitchCreateClipOpt>
{
    private Variant _data;
    public string? Title { get; set; }
    public double? Duration { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipOpt object.
    /// </summary> 
    public static TwitchCreateClipOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateClipOpt
        {
            Title = data.Read("title", static v => v.AsString()),
            Duration = data.Read("duration", static v => v.AsDouble()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_clip.gd", "Opt");
        if(Title != null) request.SetValue("title", Title);
        if(Duration.HasValue) request.SetValue("duration", Duration.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
