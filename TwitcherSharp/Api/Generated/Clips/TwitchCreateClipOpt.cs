using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;


/// <summary> 
/// All optional parameters for TwitchAPI.CreateClip 
/// </summary>
public partial class TwitchCreateClipOpt : RefCounted, ITwitcherSharp<TwitchCreateClipOpt>
{
    private GodotObject? _data;
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
            Title = data.Get("title").AsString(),
            Duration = data.Get("duration").AsDouble(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Title != null) request.Set("title", Title);
        if(Duration.HasValue) request.Set("duration", Duration.Value);
        return request;
    }

}
