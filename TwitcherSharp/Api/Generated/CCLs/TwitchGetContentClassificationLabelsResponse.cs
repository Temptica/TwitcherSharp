using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;

public partial class TwitchGetContentClassificationLabelsResponse : RefCounted, ITwitcherSharp<TwitchGetContentClassificationLabelsResponse>
{
    private GodotObject? _data;
    public TwitchContentClassificationLabel[] Data { get => field ??= _data?.GetArray<TwitchContentClassificationLabel>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetContentClassificationLabelsResponse object.
    /// </summary> 
    public static TwitchGetContentClassificationLabelsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetContentClassificationLabelsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_content_classification_labels.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
